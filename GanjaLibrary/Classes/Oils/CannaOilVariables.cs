using GanjaLibrary.Enums;
using System;
using System.Collections.Generic;

namespace GanjaLibrary.Classes.Oils
{
    partial class CannaOil
    {
        // Ints
        public int Age { get { return Chronic.Age; } }
        public int SeedingAge { get { return Chronic.SeedingAge; } }
        public int DryingAge { get { return Chronic.DryingAge; } }
        public int FloweringAge { get { return Chronic.FloweringAge; } }
        public int MaxHealth { get { return Chronic.MaxHealth; } }
        public int MaxStackableQuantity { get; set; }

        // Doubles
        public double Health { get { return Chronic.Health; } }
        public double MaxYield { get { return Chronic.MaxYield; } }
        public double CBD { get { return Chronic.CBD; } }
        public double THC { get { return Chronic.THC; } }
        public double Weight { get { return Chemical.Weight; } }
        public double Value { get { return Chemical.Value; } }
        public double Trimmings { get { return Chronic.Trimmings; } }
        public double Height { get { return Chronic.Height; } set { Chronic.Height = value; } }
        public double Quality { get { return Chronic.Quality; } set { Chronic.Quality = value; } }
        public double Yield { get { return Chronic.Yield; } set { Chronic.Yield = value; } }

        // Enums
        public Water Water { get { return Chronic.Water; } }
        public Stage Stage { get { return Chronic.Stage; } }
        public Food Food { get { return Chronic.Food; } }
        public Light Light { get { return Chronic.Light; } }

        // Dictionaries
        public Dictionary<Stage, Water> WaterNeed { get { return Chronic.WaterNeed; } }
        public Dictionary<Stage, Light> LightNeed { get { return Chronic.LightNeed; } }

        // String
        public string Name { get { return Chronic.Name + "-based Oil"; } }
        public string Description { get { return "Precious THC Oil"; } }

        // Remaining stuff
        public Guid Id { get { return Chemical.Id; } }
        
        public ItemType Type { get { return ItemType.CannaOil; } }
    }
}
