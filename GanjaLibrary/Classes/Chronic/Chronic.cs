using GanjaLibrary.Classes.Items;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;
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
        // Growing related variables.
        public int Age { get; set; }
        public int FloweringAge { get; internal set; }
        public int DryingAge { get; internal set; }
        public int SeedingAge { get; internal set; }
        public int MaxHealth { get; private set; }

        public double CBD { get; internal set; }
        public double THC { get; internal set; }
        public double Yield { get; private set; }
        public double MaxYield { get; private set; }
        public double Quality { get; private set; }
        public double Health { get; internal set; }
        public double Height { get; set; }

        // Washing related variables.
        public double WashCount { get; internal set; }
        public double SolventRatio { get; internal set; }
        public double ExtractedOils { get; internal set; }
        public double RemainingOils { get; internal set; }
        public double WashRemains { get; internal set; }
        public double Trimmings { get; set; }

        // Growing related variables.
        public Water Water { get; internal set; }
        public Stage Stage { get; set; }
        public Food Food { get; internal set; }
        public Light Light { get; internal set; }

        public Dictionary<Stage, Water> WaterNeed { get; internal set; }
        public Dictionary<Stage, Light> LightNeed { get; internal set; }

        // Static to generate a random number.
        public static Random randgen = new Random();
        #endregion

        #region constructors
        public Chronic() : base("Chronic", "Base type of weed", 0, 0)
        {
            // Required variables for growing
            Age = 0;
            SeedingAge = randgen.Next(1, 7);
            FloweringAge = randgen.Next(50, 60);
            DryingAge = randgen.Next(6, 10);
            MaxHealth = 100;

            CBD = 0.15;
            THC = 0.10;
            MaxYield = 150;
            Yield = 0;
            Quality = 10;
            Health = 0;
            Height = 0;

            Water = Water.None;
            Stage = Stage.Seed;
            Food = Food.None;
            Light = Light.None;

            // Required for washing.
            WashCount = 0;
            SolventRatio = 0;
            Trimmings = 0;
            ExtractedOils = randgen.Next(75, 85);
            RemainingOils = 100 - ExtractedOils;

            // Create a dict for changing water need per stage.
            WaterNeed = new Dictionary<Stage, Water>()
            {
                { Stage.Seed, Water.Low },
                { Stage.Clone, Water.Low },
                { Stage.Vegetative, Water.Low },
                { Stage.Flowering, Water.Medium },
                { Stage.Dead, Water.None },
            };

            // Create a dict for changing light need per stage.
            LightNeed = new Dictionary<Stage, Light>()
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
        // What to do when plant grows.
        public IChronic Grow(Water water, Light light, Food food)
        {
            if (Stage == Stage.Vegetative || Stage == Stage.Seed || Stage == Stage.Clone || Stage == Stage.Flowering)
            {
                Age++;
                AdjustHealth(water, light, food);
                AdjustQuality(water, light, food);

                if (Stage != Stage.Seed)
                {
                    AdjustHeight(water, light, food, Stage);
                    AdjustCompost(water, light, food, Stage);
                }

                if (Stage == Stage.Flowering)
                {
                    AdjustYield(water, light, food);
                    AdjustTHC(FloweringAge, 5);
                    AdjustCBD(FloweringAge, 5);
                }

                var isAdvanced = AdvanceStage(light);
            }
            return this;
        }

        // What to do when harvesting the plant.
        public IChronic Harvest()
        {
            IChronic harvest = null;

            if (Stage == Stage.Flowering)
            {
                if (Age >= (FloweringAge - 5) && Age <= FloweringAge + 5)
                {
                    // Check if plant has reached optimal flowering age.
                    if (Age == FloweringAge)
                        Yield *= 1.05;
                    // Check the health of the plant and give bonus accordingly.
                    else if (Health >= 0 && Health <= 50)
                        Yield *= 1.01;
                    else if (Health > 50 && Health <= 90)
                        Yield *= 1.02;
                    else if (Health > 90 && Health <= 100)
                        Yield *= 1.05;
                }

                // Causes a lot of stress for the plant.
                // Also since we cut the plant, set height to 10 cm.                
                Health = 0;
                Age = 0;
                Height = 10;

                harvest = DeepClone();

                // After cloning reduce the yield and trimmings.
                Yield = 0;
                Trimmings = 0;

                // Cutting does not kill, set to clone stage.
                Stage = Stage.Clone;

                // Different stage and height for the clone.
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

        // What to do when curing the plant.
        public IChronic Cure()
        {
            if (Stage == Stage.Curing)
            {
                Age++;
                // Adjust THC/CBD with the optimalAge and variance in mind
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

            if (CBD > THC)
                Value = (Quality * Yield) * CBD;
            else
                Value = (Quality * Yield) * THC;

            return this;
        }

        // To switch from a drying to curing stage.
        // The real life action means storing it in a mason jar (Wecking).
        public IChronic Weck()
        {
            if (Stage == Stage.Drying)
            {
                Age = 0;
                Stage = Stage.Curing;
            }

            return this;
        }

        public IChronic Wash(IChemical chemical, IContainer container)
        {
            // For every gram of weed, require 3 ml of solvent to wash with (1:3)
            SolventRatio = (Yield + Trimmings) * 3;
            
            // Check if there's enough chemicals for a wash.
            if (SolventRatio <= chemical.Contents)
            {
                if (WashCount == 0)
                {
                    // Increase the stackable quantity
                    MaxStackableQuantity = (int)Yield + (int)Trimmings;

                    // Remove the required solvent ratio from the bottle of chemicals.
                    chemical.Contents -= SolventRatio;

                    // Extract the CBD or THC from the entire yield.
                    if (THC > CBD)
                        Yield += Trimmings * THC;
                    if (CBD > THC)
                        Yield += Trimmings * CBD;

                    // Calculate a remainder before we modify the yield.
                    WashRemains = (Yield + Trimmings) * (RemainingOils / 100);
                    // Remove ~80% of the THC during the first wash.
                    Yield += Trimmings * (ExtractedOils / 100);
                    Stage = Stage.Washing;
                    WashCount++;
                }

                if (WashCount == 1)
                {
                    // Add the remainder to the yield.
                    Yield += WashRemains;
                    WashCount++;
                }

                // Washing any more will dissolve the green bits, thus reducing the oil quality.
                if (WashCount > 1)
                {
                    Quality *= 0.95;
                    WashCount++;
                }
            }

            return this;
        }

        public IChronic Filter(IContainer originContainer, IContainer destContainer, IItem filter)
        {
            // Filter the plant remains from the solvent.
            // Depending on the type of solvent and the contents (ie. denatured alcohol) have different effects.
            // Requires filters, two containers for transfer/sifting.
            if (Stage == Stage.Washing)
            {

            }
            return this;
        }

        public IChronic Heat()
        {
            /* 
            Heat away the chemical solvent. Some chemicals can vaporize in open air without heat.
            Might even be a better idea in the first place...
            Requires: ventilation/open air and time or a heat source like a gasburner or stove.
            */
            return this;
        }

        #endregion

        #region Plant Biology
        // Adjust plant health if watered, lighted and fed.
        private void AdjustHealth(Water water, Light light, Food food)
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

        // Adjust plant height if watered and lighted.
        private void AdjustHeight(Water water, Light light, Food food, Stage stage)
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

        // Adjust plant compost amount. Compost in this sense means bits of the plant you'll have to cut off.
        private void AdjustCompost(Water water, Light light, Food food, Stage stage)
        {
            if (stage == Stage.Vegetative || stage == Stage.Flowering || stage == Stage.Seed || stage == Stage.Clone)
            {
                if (water == Water)
                    Trimmings += 1.5;
                else
                    Trimmings -= 1.5;

                if (light == Light)
                    Trimmings += 1.5;
                else
                    Trimmings -= 1.5;

                if (food == Food)
                    Trimmings += 1.5;
                else
                    Trimmings -= 1.5;

                if (stage == Stage.Dead)
                    Trimmings -= 2;

                if (Trimmings < 0)
                    Trimmings = 0;
            }
        }

        // Quality improvement algorithm.
        private void AdjustQuality(Water water, Light light, Food food)                     
        {
            // Plant has to be very healthy
            if (Health > 50)                                                               
            {
                // Always get some quality improvement.
                if (water == Water && light == Light)                                       
                {
                    Quality *= 1.01;

                    if (food == Food.Low)
                        Quality *= 1.01;

                    else if (food == Food.Medium)
                        Quality *= 1.02;

                    else if (food == Food.High)
                        Quality *= 1.03;
                }
            }
        }

        // How the plant enhances through growth stages.    
        public bool AdvanceStage(Light light)                                               
        {
            var hasAdvanced = false;

            // Die if quality is bad.
            if (Health <= GameSettings.Default.DeathThreshold)                                                              
            {
                Stage = Stage.Dead;
                if (Died != null)
                {
                    Died(this, new EventArgs());
                }
                hasAdvanced = true;
            }

            // Advance from seed to vegetative.
            if (Age == SeedingAge && Health >= 0)                                                          
            {
                Stage = Stage.Vegetative;
                hasAdvanced = true;
            }

            // Advance if 3 weeks are reached and light requirement is triggered.
            if (Age >= 21 && (light == LightNeed[Stage.Flowering]))                         
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

        // Adjust the actual yield of the plant.
        private void AdjustYield(Water water, Light light, Food food)          
        {
            // If plant is flowering and has not reached flowering age, increase yield.
            if (Yield <= MaxYield && Age >= FloweringAge)       
            {
                // Depending on the height, health and resources received adjust yield.
                if (water == Water)                                                         
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

            // If flowering age has gone by, decrease yield.
            else if (Age > FloweringAge)                        
            {
                Yield *= 0.95;
            }

            else return;
        }

        // Adjust THC % of the plant.
        private void AdjustTHC(int optimalAge, int variance)
        {
            // Low health decreases THC content.
            if (Health < 0)                              
                THC -= 0.000025;
            // High health increases THC content.
            if (Health >= 0 && Health <= 50)                 
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

        // Adjust CBD % of the plant.
        private void AdjustCBD(int optimalAge, int variance)                                                 
        {
            // Low health lowers CBD content.
            if (Health < 0)                                 
                CBD -= 0.00015;
            // High health increases CBD content.
            if (Health >= 0 && Health <= 50)                 
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

        // Printing out all the changing variables so we can track progress.
        public virtual void Print()                                                        
        {
            Console.WriteLine(string.Format("GUID: {0}", Id));
            Console.WriteLine(string.Format("Stage: {0}", Stage));
            Console.WriteLine(string.Format("Age: {0}     \t\t\tName: {1}", Age, Name));
            Console.WriteLine(string.Format("Seeding Age: {0} \t\t\tFlowering Age: {1}", SeedingAge, FloweringAge));
            Console.WriteLine(string.Format("Water: {0}  \t\t\tLight: {1}", Water, Light));
            Console.WriteLine(string.Format("Food: {0} \t\t\tHealth: {1}", Food, Health));
            Console.WriteLine(string.Format("CBD: {0}%  \t\t\tTHC: {1}%", CBD * 100, THC * 100));
            Console.WriteLine(string.Format("Height: {0} \t\tQuality: {1}", Height, Quality));
            Console.WriteLine(string.Format("Yield: {0} \t\tCompost: {1}", Yield, Trimmings));

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