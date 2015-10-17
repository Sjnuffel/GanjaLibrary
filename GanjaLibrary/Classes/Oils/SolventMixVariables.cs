using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Interfaces.Oils;
using System.Collections.Generic;

namespace GanjaLibrary.Classes.Oils
{
    partial class SolventMix : Item, ISolventMix, IChemical
    {
        // int variables
        public int SeedingAge { get { return Chronic.SeedingAge; } }
        public int MaxHealth { get { return Chronic.MaxHealth; } }
        public int DryingAge { get { return Chronic.DryingAge; } }
        public int FloweringAge { get { return Chronic.FloweringAge; } }

        // double variables
        public double MaxYield { get { return Chronic.MaxYield; } }
        public double Health { get { return Chronic.Health; } }
        public double THC { get { return Chronic.THC; } }
        public double CBD { get { return Chronic.CBD; } }

        // Remaining variables
        public double Flashpoint { get { return Chemical.Flashpoint; } }

        public double Contents { get { return Chemical.Contents; } set { Chemical.Contents = value; } }
        public double Height { get { return Chronic.Height; } }
        public double Yield { get { return Chronic.Yield; } } 
        public double Quality { get { return Chronic.Quality; } }

        // Enum variables
        public Light Light { get { return Chronic.Light; } }
        public Water Water { get { return Chronic.Water; } }
        public Food Food { get { return Chronic.Food; } }
        public Stage Stage { get { return Chronic.Stage; } }
        
        // Bool variables
        public bool Flammable { get { return Chemical.Flammable; } }
        public bool Denatured { get { return Chemical.Denatured; } }

        // Dictionaries
        public Dictionary<Stage, Water> WaterNeed { get { return Chronic.WaterNeed; } }
        public Dictionary<Stage, Light> LightNeed { get { return Chronic.LightNeed; } }
    }
}
