using GanjaLibrary.Enums;
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
        public int FloweringAge { get; private set; }
        public int SeedingAge { get; internal set; }

        public double CBD { get; internal set; }
        public double THC { get; internal set; }
        public double MaxYield { get; private set; }
        public double Quality { get; private set; }
        public double Yield { get; private set; }
        public double Health { get; private set; }
        public double ActualHeight { get; private set; }

        public Height Height { get; internal set; }
        public Water Water { get; internal set; }
        public Stage Stage { get; internal set; }
        public Food Food { get; internal set; }
        public Light Light { get; internal set; }

        public Dictionary<Stage, Water> WaterNeed { get; internal set; }
        public Dictionary<Stage, Light> LightNeed { get; internal set; }

        public Chronic()
        {
            // Set base variables
            Name = "Chronic";
            Age = 0;
            FloweringAge = 90;
            SeedingAge = 1;

            CBD = 0.15;
            THC = 0.10;
            MaxYield = 75;
            Quality = 1;
            Yield = 0;
            Health = 1;
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
            AdjustQuality();
            var isAdvanced = AdvanceStage(light);

            return this;
        }

        // Adjust plant health if watered and lighted.
        private void AdjustHealth(Water water, Light light, Food food)
        {
            if (water == Water)
                Health *= 1.05;
            else
                Health *= 0.95;

            if (light == Light)
                Health *= 1.05;
            else
                Health *= 0.95;

            if (food == Food)
                Health *= 1.05;
            else
                Health *= 0.95;
        }

        // Adjust plant height if watered and lighted.
        private void AdjustHeight(Water water, Light light, Food food, Stage stage)
        {
            // Check if plant is alive and no longer a seed.
            if (stage == Stage.Vegetative || stage == Stage.Clone || stage == Stage.Flowering)
            {
                if (water == Water)
                    ActualHeight++;
                else
                    ActualHeight--;

                if (light == Light)
                    ActualHeight++;
                else
                    ActualHeight--;

                // No penalty for lack of food, just bonus growth.
                if (food == Food.Low || food == Food.Medium || food == Food.High)
                    ActualHeight++;
            }

            else if (stage == Stage.Dead)
                ActualHeight--;

            else if (stage == Stage.Seed)
                ActualHeight = 0;
        }

        // Quality improvement algorithm.
        private void AdjustQuality()
        {
            Quality *= Health;
        }

        public IChronic Harvest()
        {
            return this;
        }

        // How the plant enhances through growth stages.
        public bool AdvanceStage(Light light)
        {
            var hasAdvanced = false;

            //Die if quality is bad
            if (Quality <= 0.4)
            {
                Stage = Stage.Dead;
                if (Died != null)
                {
                    Died(this, new EventArgs());
                }
                hasAdvanced = true;
            }

            // Advance from seed to vegetative
            if (Age == SeedingAge)
            {
                Stage = Stage.Vegetative;
                hasAdvanced = true;
            }

            // Advance if 3 weeks are reached and light requirement is triggered
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

        // Printing out all the changing variables so we can track progress.
        public virtual void Print()
        {
            Console.WriteLine(string.Format("Name: {0}", Name));
            Console.WriteLine(string.Format("Age: {0}; Flowering age: {1}; Seeding Age: {2};", Age, FloweringAge, SeedingAge));
            Console.WriteLine(string.Format("Stage: {0}, Water: {1}, Food: {2}; Light: {3}", Stage, Water, Food, Light));
            Console.WriteLine(string.Format("Quality: {0}, Health: {1}", Quality, Health));
            Console.WriteLine(string.Format("ActualHeight: {0}", ActualHeight));

            if (Globals.Debug)
            {
                Console.WriteLine(string.Format("CBD content: {0}%; THC: {1}%", CBD * 100, THC * 100));
                Console.WriteLine(string.Format("Expected Yield: {0}", MaxYield));
                Console.WriteLine(string.Format("Actual Yield: {0}", Yield));
                Console.WriteLine(string.Format("Height: {0}", Height));
            }
        }
    }
}