using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace GanjaLibrary.Classes
{
    partial class Chronic
    {
        #region Properties
        // Growing related variables.
        public int Age { get; internal set; }
        public int FloweringAge { get; internal set; }
        public int DryingAge { get; internal set; }
        public int SeedingAge { get; internal set; }
        public int MaxHealth { get; private set; }

        public double CBD { get; internal set; }
        public double THC { get; internal set; }
        public double Yield { get; set; }
        public double MaxYield { get; private set; }
        public double Quality { get; set; }
        public double Health { get; internal set; }
        public double Height { get; set; }
        public double Trimmings { get; internal set; }

        // Growing related variables.
        public Water Water { get; internal set; }
        public Stage Stage { get; internal set; }
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
            // Assign values to variables for growing
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
            Trimmings = 0;
            Value = 0;

            Water = Water.None;
            Stage = Stage.Seed;
            Food = Food.None;
            Light = Light.None;
            Type = ItemType.Plant;

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

        // The variables to copy.
        protected Chronic(Chronic other) : base(other)
        {
            Age = other.Age;
            SeedingAge = other.SeedingAge;
            FloweringAge = other.FloweringAge;
            DryingAge = other.DryingAge;
            MaxHealth = other.MaxHealth;

            CBD = other.CBD;
            THC = other.THC;
            MaxYield = other.MaxYield;
            Yield = other.Yield;
            Quality = other.Quality;
            Health = other.Health;
            Height = other.Height;
            Trimmings = other.Trimmings;

            Water = other.Water;
            Stage = other.Stage;
            Food = other.Food;
            Light = other.Light;
            Type = other.Type;
        }

        IChronic IChronic.Clone()
        {
            return (IChronic)Clone();
        }
        #endregion
    }
}
