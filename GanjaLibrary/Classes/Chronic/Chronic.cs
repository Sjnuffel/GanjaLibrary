using GanjaLibrary.Classes.Items;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Statics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GanjaLibrary.Classes
{
    [Serializable]
    public class Chronic : Item, IChronic
    {
        #region Properties
        public int Age { get; set; }
        public int FloweringAge { get; internal set; }
        public int DryingAge { get; internal set; }
        public int SeedingAge { get; internal set; }
        public int MaxHealth { get; private set; }

        public double CBD { get; internal set; }
        public double THC { get; internal set; }
        public double Yield { get; private set; }
        public double MaxYield { get; private set; }
        public double BaseQuality { get; private set; }
        public double ActualQuality { get; private set; }
        public double Health { get; internal set; }
        public double Height { get; set; }

        public Water Water { get; internal set; }
        public Stage Stage { get; set; }
        public Food Food { get; internal set; }
        public Light Light { get; internal set; }

        public Dictionary<Stage, Water> WaterNeed { get; internal set; }
        public Dictionary<Stage, Light> LightNeed { get; internal set; }

        public static Random randgen = new Random();
        #endregion

        #region constructors
        public Chronic() : base("Chronic", "Base type of weed", 0, 0)
        {
            Age = 0;

            FloweringAge = randgen.Next(50, 60);
            DryingAge = randgen.Next(6, 10);

            SeedingAge = 1;
            MaxHealth = 100;

            CBD = 0.15;
            THC = 0.10;
            MaxYield = 150;
            Yield = 0;
            BaseQuality = 10;
            ActualQuality = BaseQuality;
            Health = 0;
            Height = 0;

            Water = Water.None;
            Stage = Stage.Seed;
            Food = Food.None;
            Light = Light.None;

            WaterNeed = new Dictionary<Stage, Water>()                                      // Create a dict for changing water need per stage.
            {
                { Stage.Seed, Water.Low },
                { Stage.Clone, Water.Low },
                { Stage.Vegetative, Water.Low },
                { Stage.Flowering, Water.Medium },
                { Stage.Dead, Water.None },
            };

            LightNeed = new Dictionary<Stage, Light>()                                      // Create a dict for changing light need per stage.
            {
                { Stage.Seed, Light.None },
                { Stage.Clone, Light.Spring },
                { Stage.Vegetative, Light.Spring },
                { Stage.Flowering, Light.Summer },
                { Stage.Dead, Light.None },
            };
        }

        public Chronic(string name) : this()
        {
            Name = name;
        }

        public Chronic(string name, Water water, Light light, Food food) : this(name)
        {
            Water = water;
            Light = light;
            Food = food;
        }
        #endregion

        public event EventHandler Died;

        #region Processing functions
        public IChronic Grow(Water water, Light light, Food food)                           // What to do when plant grows.
        {
            if (Stage == Stage.Vegetative || Stage == Stage.Seed || Stage == Stage.Clone || Stage == Stage.Flowering)
            {
                Age++;
                AdjustHealth(water, light, food);
                AdjustHeight(water, light, food, Stage);
                AdjustQuality(water, light, food);
                AdjustYield(water, light, food, Stage);

                if (Stage == Stage.Flowering)
                {
                    AdjustTHC(FloweringAge, 5);
                    AdjustCBD(FloweringAge, 5);
                }

                var isAdvanced = AdvanceStage(light);
            }
            return this;
        }

        public IChronic Harvest()                                                          // What to do when harvesting the plant.
        {
            IChronic harvest = null;

            if (Stage == Stage.Flowering)
            {
                if (Age >= (FloweringAge - 5) && Age <= FloweringAge + 5)
                {
                    if (Age == FloweringAge)                                                    // Check if plant has reached optimal flowering age.
                        Yield *= 1.05;
                    else if (Health >= 0 && Health <= 50)                                       // Check the health of the plant and give bonus accordingly.
                        Yield *= 1.01;
                    else if (Health > 50 && Health <= 90)
                        Yield *= 1.02;
                    else if (Health > 90 && Health <= 100)
                        Yield *= 1.05;
                }

                // Causes a lot of stress for the plant.
                Health = 0;
                Age = 0;

                harvest = DeepClone();

                Height = 10;                                                          // Since we cut the plant, set height to 10 cm.
                Stage = Stage.Clone;                                                        // Cutting does not kill, reduce to clone stage.
                Yield = 0;

                harvest.Stage = Stage.Drying;
                harvest.Height -= 10;
            }

            return harvest;
        }

        public IChronic Dry()
        {
            if (Stage == Stage.Drying)
            {
                Age++;
                AdjustTHC(DryingAge, 2);
                AdjustCBD(DryingAge, 2);
            }
            return this;
        }

        public IChronic Cure()
        {
            if (Stage == Stage.Curing)
            {
                Age++;
                AdjustTHC(14, 1);
                AdjustCBD(14, 1);
            }
            return this;
        }

        public IChronic Finish()
        {
            if (Stage == Stage.Flowering || Stage == Stage.Curing || Stage == Stage.Drying)
            {
                Stage = Stage.Finished;
                Yield *= 0.55;
            }

            Value = (ActualQuality * Yield) * THC;

            return this;
        }

        public IChronic Weck()
        {
            if (Stage == Stage.Drying)
            {
                Age = 0;
                Stage = Stage.Curing;
            }

            return this;
        }

        #endregion

        #region Plant Biology
        private void AdjustHealth(Water water, Light light, Food food)                         // Adjust plant health if watered, lighted and fed.
        {
            if (Stage == Stage.Dead)
            {
                Health = GameSettings.Default.DeathThreshold;
            }
            else
            {
                if (water == Water && Health <= MaxHealth)
                    Health++;
                else
                    Health--;

                if (light == Light && Health <= MaxHealth)
                    Health++;
                else
                    Health--;

                if (food == Food && food != Food.None && Health <= MaxHealth)
                    Health++;
            }
        }

        private void AdjustHeight(Water water, Light light, Food food, Stage stage)         // Adjust plant height if watered and lighted.
        {
            // Check if plant is alive and no longer a seed.
            if (stage == Stage.Vegetative || stage == Stage.Flowering || stage == Stage.Clone)
            {
                if (water == Water)
                    Height += 0.75;
                else
                    Height -= 0.75;

                if (light == Light)
                    Height += 0.75;
                else
                    Height -= 0.75;

                // No penalty for lack of food, just bonus growth.
                if (food == Food.Low || food == Food.Medium || food == Food.High)
                    Height++;
            }

            else if (stage == Stage.Dead)
                Height -= 0.75;

            else if (stage == Stage.Seed)
                Height = 0;

            if (Height < 0)
                Height = 0;

        }

        private void AdjustQuality(Water water, Light light, Food food)                     // Quality improvement algorithm.
        {
            if (Health > 50)                                                               // Plant has to be very healthy
            {
                if (water == Water && light == Light)                                       // Always get some quality improvement.
                {
                    ActualQuality *= 1.01;

                    if (food == Food.Low)
                        ActualQuality *= 1.01;

                    else if (food == Food.Medium)
                        ActualQuality *= 1.02;

                    else if (food == Food.High)
                        ActualQuality *= 1.03;
                }
            }
        }

        public bool AdvanceStage(Light light)                                               // How the plant enhances through growth stages.    
        {
            var hasAdvanced = false;

            if (Health <= GameSettings.Default.DeathThreshold)                                                               // Die if quality is bad.
            {
                Stage = Stage.Dead;
                if (Died != null)
                {
                    Died(this, new EventArgs());
                }
                hasAdvanced = true;
            }

            if (Age == SeedingAge && Health >= 0)                                                          // Advance from seed to vegetative.
            {
                Stage = Stage.Vegetative;
                hasAdvanced = true;
            }

            if (Age >= 21 && (light == LightNeed[Stage.Flowering]))                         // Advance if 3 weeks are reached and light requirement is triggered.
            {
                if (Stage == Stage.Vegetative || Stage == Stage.Clone)
                {
                    hasAdvanced = true;
                    Stage = Stage.Flowering;
                }
            }

            if (hasAdvanced)
            {
                Light = LightNeed[Stage];
                Water = WaterNeed[Stage];
            }

            return hasAdvanced;
        }

        private void AdjustYield(Water water, Light light, Food food, Stage stage)          // Adjust the actual yield of the plant.
        {
            if (stage == Stage.Flowering && Yield <= MaxYield && Age <= FloweringAge)       // If plant is flowering and has not reached flowering age, increase yield.
            {
                if (water == Water)                                                         // Depending on the height, health and resources received adjust yield.
                    Yield++;
                if (light == Light)
                    Yield++;
                if (food == Food)
                    Yield += 2;
                if (Height >= 0 || Height <= 50)
                    Yield += 0.25;
                else if (Height >= 51 || Height <= 100)
                    Yield += 0.5;
                else if (Height >= 101 || Height <= 150)
                    Yield += 0.75;
                else if (Height >= 151 || Height <= 200)
                    Yield += 1;
                if (Health < 0)
                    Yield -= 2;
                else if (Health >= 0 && Health <= 50)
                    Yield += 0.25;
                else if (Health > 50 && Health <= 100)
                    Yield += 0.25;
            }

            else if (stage == Stage.Flowering && Age > FloweringAge)                        // If flowering age has gone by, decrease yield.
            {
                Yield *= 0.95;
            }

            else return;
        }

        private void AdjustTHC(int optimalAge, int variance)                                                 // Adjust THC % of the plant.
        {
            if (Health < 0)                              // Low health decreases THC content.
                THC -= 0.000025;
            if (Health >= 0 && Health <= 50)                 // High health increases THC content.
                THC += 0.000015;
            if (Health > 50 && Health <= 100)
                THC += 0.000020;
            if (Health > 0)
                THC += 0.000025;

            if (Age < (optimalAge - variance))
                THC -= 0.000015;
            if (Age >= (optimalAge - variance) && Age >= (optimalAge + variance))
                THC += 0.000015;
            if (Age > optimalAge + variance)
                THC -= 0.000015;
        }

        private void AdjustCBD(int optimalAge, int variance)                                                 // Adjust CBD % of the plant.
        {
            if (Health < 0)                                 // Low health lowers CBD content.
                CBD -= 0.00015;
            if (Health >= 0 && Health <= 50)                 // High health increases CBD content.
                CBD += 0.00015;
            if (Health > 50 && Health <= 100)
                CBD += 0.00025;
            if (Health > 100)
                CBD += 0.00035;

            if (Age < (optimalAge - variance))
                CBD -= 0.00015;
            if (Age >= (optimalAge - variance) && Age >= (optimalAge + variance))
                CBD += 0.00025;
            if (Age > optimalAge + variance)
                CBD -= 0.00015;
        }

        #endregion

        public virtual void Print()                                                         // Printing out all the changing variables so we can track progress.
        {
            Console.WriteLine(string.Format("Name: {0}  \nStage: {1} \nGUID: {2}", Name, Stage, Id));
            Console.WriteLine(string.Format("Age: {0} \tFlowering age: {1} \tSeeding Age: {2};", Age, FloweringAge, SeedingAge));
            Console.WriteLine(string.Format("Water: {0} \tFood: {1} \t\tLight: {2}", Water, Food, Light));
            Console.WriteLine(string.Format("CBD: {0}%; \tTHC: {1}%", CBD * 100, THC * 100));

            Console.WriteLine(string.Format("\nActual Height: {0} centimeters", Height));
            Console.WriteLine(string.Format("Actual Yield: {0} grams", Yield));
            Console.WriteLine(string.Format("Base Quality: {0} \t\t Actual Quality: {1}", BaseQuality, ActualQuality));
            Console.WriteLine(string.Format("Health: {0}", Health));

            if (Globals.Debug)
            {
                Console.WriteLine(string.Format("CBD content: {0}%; THC: {1}%", CBD * 100, THC * 100));
                Console.WriteLine(string.Format("Expected Yield: {0}", MaxYield));
                Console.WriteLine(string.Format("Height: {0}", Height));
            }
        }

        public IChronic DeepClone()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(memoryStream) as IChronic;
            }
        }
    }
}