using GanjaLibrary.Enums;
using System.Collections.Generic;

namespace GanjaLibrary.Classes.Oils
{
    partial class CannaOil
    {
        public int Age
        {
            get { return Chronic.Age; }
        }

        public double CBD
        {
            get { return Chronic.CBD; }
        }

        public int DryingAge
        {
            get { return Chronic.DryingAge; }
        }

        public int FloweringAge
        {
            get { return Chronic.FloweringAge; }
        }

        public double Health
        {
            get { return Chronic.Health; }
        }

        public int MaxHealth
        {
            get { return Chronic.MaxHealth; }
        }

        public double MaxYield
        {
            get { return Chronic.MaxYield; }
        }

        public string Name
        {
            get { return Chronic.Name; }
        }

        public int SeedingAge
        {
            get { return Chronic.SeedingAge; }
        }

        public double THC
        {
            get { return Chronic.THC; }
        }

        public double Trimmings
        {
            get { return Chronic.Trimmings; }
        }

        public double Height
        {
            get { return Chronic.Height; }

            set { Chronic.Height = value; }
        }

        public double Quality
        {
            get { return Chronic.Quality; }

            set { Chronic.Quality = value; }
        }

        public double Yield
        {
            get { return Chronic.Yield; }

            set { Chronic.Yield = value; }
        }

        public Water Water
        {
            get { return Chronic.Water; }
        }

        public Stage Stage
        {
            get { return Chronic.Stage; }
        }

        public Food Food
        {
            get { return Chronic.Food; }
        }

        public Light Light
        {
            get { return Chronic.Light; }
        }

        public Dictionary<Stage, Water> WaterNeed
        {
            get { return Chronic.WaterNeed; }
        }

        public Dictionary<Stage, Light> LightNeed
        {
            get { return Chronic.LightNeed; }
        }
    }
}
