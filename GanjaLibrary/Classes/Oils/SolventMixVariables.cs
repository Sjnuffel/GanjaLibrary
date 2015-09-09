using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace GanjaLibrary.Classes.Oils
{
    partial class SolventMix
    {
        public int SeedingAge {
            get { return Chronic.SeedingAge; }
        }

        public int MaxHealth {
            get { return Chronic.MaxHealth; }
        }

        public int DryingAge {
            get { return Chronic.DryingAge; }
        }

        public int Age {
            get { return Chronic.Age; }
        }

        public int FloweringAge {
            get { return Chronic.FloweringAge; }
        }

        public double Height {
            get { return Chronic.Height; }

            set { Chronic.Height = value; }
        }

        public double MaxYield {
            get { return Chronic.MaxYield; }
        }

        public double Quality {
            get { return Chronic.Quality; }

            set { Chronic.Quality = value; }
        }

        public double Trimmings {
            get { return Chronic.Trimmings; }
        }

        public double Health {
            get { return Chronic.Health; }
        }

        public double THC {
            get { return Chronic.THC; }
        }

        public double CBD {
            get { return Chronic.CBD; }
        }

        public double Yield {
            get { return Chronic.Yield; }

            set { Chronic.Yield = value; }
        }

        public Light Light {
            get { return Chronic.Light; }
        }

        public Water Water {
            get { return Chronic.Water; }
        }

        public Food Food {
            get { return Chronic.Food; }
        }

        public Stage Stage {
            get { return Chronic.Stage; }
        }

        public string Name {
            get { return Chronic.Name; }
        }

        public Dictionary<Stage, Water> WaterNeed
        {
            get { return Chronic.WaterNeed; }
        }

        public Dictionary<Stage, Light> LightNeed
        {
            get { return Chronic.LightNeed; }
        }

        public double Flashpoint
        {
            get { return Chemical.Flashpoint; }
        }

        public double Contents {
            get { return Chemical.Contents; }

            set { Chemical.Contents = value; }
        }

        public bool Flammable {
            get { return Chemical.Flammable; }
        }

        public bool Denatured {
            get { return Chemical.Denatured; }
        }

        public Guid Id {
            get { return Chemical.Id; }
        }

        public string Description {
            get { return Chemical.Description; }
        }

        public double Weight {
            get { return Chemical.Weight; }
        }

        public double Value {
            get { return Chemical.Value; }
        }

        public int MaxStackableQuantity
        {
            get { return Chemical.MaxStackableQuantity; }
        }

        public ItemType Type
        {
            get { return ItemType.SolventMix; }
        }

        public IChronic Clone()
        {
            return Chronic.Clone();
        }
    }
}
