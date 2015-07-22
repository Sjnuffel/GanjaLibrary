﻿using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Statics;
using System;
using System.Collections.Generic;

namespace GanjaLibrary.Classes
{
    public class Chronic : IChronic
    {
        public string Name { get; internal set; }

        public int Age { get; internal set; }
        public int FloweringAge { get; internal set; }
        public int SeedingAge { get; internal set; }
        public int MaxHealth { get; private set; }

        public double CBD { get; internal set; }
        public double THC { get; internal set; }
        public double Yield { get; private set; }
        public double MaxYield { get; private set; }
        public double BaseQuality { get; private set; }
        public double ActualQuality { get; private set; }
        public double Health { get; internal set; }
        public double ActualHeight { get; private set; }

        public Height Height { get; internal set; }
        public Water Water { get; internal set; }
        public Stage Stage { get; internal set; }
        public Food Food { get; internal set; }
        public Light Light { get; internal set; }

        public Dictionary<Stage, Water> WaterNeed { get; internal set; }
        public Dictionary<Stage, Light> LightNeed { get; internal set; }
        
        public Guid ID { get; internal set; }

        // Add a random method.
        public static Random randgen = new Random();

        // Add a random decimal method.
        public static decimal NextDecimal(Random randgen, decimal from, decimal to)
        {
            byte fromScale = new System.Data.SqlTypes.SqlDecimal(from).Scale;
            byte toScale = new System.Data.SqlTypes.SqlDecimal(to).Scale;

            byte scale = (byte)(fromScale + toScale);
            if (scale > 28)
                scale = 28;

            decimal r = new decimal(randgen.Next(), randgen.Next(), randgen.Next(), false, scale);
            if (Math.Sign(from) == Math.Sign(to) || from == 0 || to == 0)
                return decimal.Remainder(r, to - from) + from;

            bool getFromNegativeRange = (double)from + randgen.NextDouble() * ((double)to - (double)from) < 0;
            return getFromNegativeRange ? decimal.Remainder(r, -from) + from : decimal.Remainder(r, to);

        }

        public Chronic()
        {
            // Set base variables.
            ID = Guid.NewGuid();
            Name = "Chronic";
            Age = 0;
            FloweringAge = randgen.Next(50, 60);

            SeedingAge = 1;
            MaxHealth = 200;

            CBD = 0.15;
            THC = 0.10;
            MaxYield = 75;
            Yield = 0;
            BaseQuality = 10;
            ActualQuality = BaseQuality;
            Health = 45;
            ActualHeight = 0;

            Height = Height.Short;
            Water = Water.Nothing;
            Stage = Stage.Seed;
            Food = Food.None;
            Light = Light.Off;

            // Create a dict for changing water need per stage.
            WaterNeed = new Dictionary<Stage, Water>()
            {
                { Stage.Seed, Water.Low },
                { Stage.Clone, Water.Low },
                { Stage.Vegetative, Water.Low },
                { Stage.Flowering, Water.Medium },
                { Stage.Dead, Water.Nothing },
            };

            // Create a dict for changing light need per stage.
            LightNeed = new Dictionary<Stage, Light>()
            {
                { Stage.Seed, Light.Off },
                { Stage.Clone, Light.Spring },
                { Stage.Vegetative, Light.Spring },
                { Stage.Flowering, Light.Summer },
                { Stage.Dead, Light.Off },
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

        public event EventHandler Died;

        // What to do when plant grows.
        public IChronic Grow(Water water, Light light, Food food)
        {
            Age++;
            AdjustHealth(water, light, food);
            AdjustHeight(water, light, food, Stage);
            AdjustQuality(water, light, food);
            AdjustYield(water, light, food, Stage);
            AdjustTHC(Stage);
            AdjustCBD(Stage);
            var isAdvanced = AdvanceStage(light);

            return this;
        }

        // Adjust plant health if watered, lighted and fed.
        private void AdjustHealth(Water water, Light light, Food food)
        {
            if (water == Water && Health <= MaxHealth)
                Health++;
            else
                Health--;

            if (light == Light && Health <= MaxHealth)
                Health++;
            else
                Health--;

            if (food == Food && Health <= MaxHealth)
                Health++;
            else
                Health--;
        }

        // Adjust plant height if watered and lighted.
        private void AdjustHeight(Water water, Light light, Food food, Stage stage)
        {
            // Check if plant is alive and no longer a seed.
            if (stage == Stage.Vegetative || stage == Stage.Flowering || stage == Stage.Clone)
            {
                if (water == Water)
                    ActualHeight += 0.75;
                else
                    ActualHeight -= 0.75;

                if (light == Light)
                    ActualHeight += 0.75;
                else
                    ActualHeight -= 0.75;

                // No penalty for lack of food, just bonus growth.
                if (food == Food.Low || food == Food.Medium || food == Food.High)
                    ActualHeight++;
            }

            else if (stage == Stage.Dead)
                ActualHeight += 0.75;

            else if (stage == Stage.Seed)
                ActualHeight = 0;
        }

        // Quality improvement algorithm.
        private void AdjustQuality(Water water, Light light, Food food)
        {
            // Plant has to be very healthy
            if (Health > 150)
            {
                // Always get some quality improvement.
                if (water == Water && light == Light)
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

        public IChronic Harvest()
        {
            return this;
        }

        // How the plant enhances through growth stages.
        public bool AdvanceStage(Light light)
        {
            var hasAdvanced = false;

            //Die if quality is bad.
            if (Health <= 25)
            {
                Stage = Stage.Dead;
                if (Died != null)
                {
                    Died(this, new EventArgs());
                }
                hasAdvanced = true;
            }

            // Advance from seed to vegetative.
            if (Age == SeedingAge)
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
        private void AdjustYield(Water water, Light light, Food food, Stage stage)
        {
            // If plant is flowering and has not reached flowering age, increase yield.
            if (stage == Stage.Flowering && Yield <= MaxYield && Age <= FloweringAge)
            {
                // Depending on the height, health and resources received adjust yield.
                if (water == Water)
                    Yield++;
                if (light == Light)
                    Yield++;
                if (food == Food)
                    Yield += 2;
                if (ActualHeight >= 0 || ActualHeight <= 50)
                    Yield += 0.25;
                else if (ActualHeight >= 51 || ActualHeight <= 100)
                    Yield += 0.5;
                else if (ActualHeight >= 101 || ActualHeight <= 150)
                    Yield += 0.75;
                else if (ActualHeight >= 151 || ActualHeight <= 200)
                    Yield += 1;
                if (Health <= 75)
                    Yield -= 2;
                else if (Health >= 100 && Health <= 150)
                    Yield += 0.25;
                else if (Health >= 151 && Health <= 200)
                    Yield += 0.25;
            }

            // If flowering age has gone by, decrease yield.
            else if (stage == Stage.Flowering && Age > FloweringAge)
            {
                Yield *= 0.95;
            }

            else return;
        }

        // Adjust THC % of the plant.
        private void AdjustTHC(Stage stage)
        {
            // High health increases THC content.
            if (stage == Stage.Flowering && Health >= 100 && Health <= 149)
                THC += 0.000015;
            else if (stage == Stage.Flowering && Health >= 150 && Health <= 199)
                THC += 0.000020;
            else if (stage == Stage.Flowering && Health >= 200)
                THC += 0.000025;
            // Low health increases THC content.
            else if (stage == Stage.Flowering && Health <= 75)
                THC -= 0.000025;
        }

        // Adjust CBD % of the plant.
        private void AdjustCBD(Stage stage)
        {
            // High health increases CBD content.
            if (stage == Stage.Flowering && Health >= 100 && Health <= 149)
                CBD += 0.00015;
            else if (stage == Stage.Flowering && Health >= 150 && Health <= 199)
                CBD += 0.00025;
            else if (stage == Stage.Flowering && Health >= 200)
                CBD += 0.00035;
            // Low health lowers CBD content.
            else if (stage == Stage.Flowering && Health <= 75)
                CBD -= 0.00015;
        }

        private void AdjustWaterNeed(Water water, Height height)
        {

        }

        // Printing out all the changing variables so we can track progress.
        public virtual void Print()
        {
            Console.WriteLine(string.Format("Name: {0}  \nStage: {1} \nGUID: {2}", Name, Stage, ID));
            Console.WriteLine(string.Format("Age: {0} \tFlowering age: {1} \tSeeding Age: {2};", Age, FloweringAge, SeedingAge));
            Console.WriteLine(string.Format("Water: {0} \tFood: {1} \t\tLight: {2}", Water, Food, Light));
            Console.WriteLine(string.Format("CBD: {0}%; \tTHC: {1}%", CBD * 100, THC * 100));

            Console.WriteLine(string.Format("\nActual Height: {0} centimeters" , ActualHeight));
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
    }
}