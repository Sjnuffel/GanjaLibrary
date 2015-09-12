using GanjaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Interfaces.Oils;

namespace GanjaLibrary.Classes.Oils
{
    partial class CannaOil : ICannaOil, IChronic, ISolvent
    {
        private IChronic Chronic { get; set; }

        public int Age {
            get { return Chronic.Age; }
        }

        public double CBD {
            get { return Chronic.CBD; }
        }

        public int DryingAge {
            get { return Chronic.DryingAge; }
        }

        public int FloweringAge {
            get { return Chronic.FloweringAge; }
        }

        public double Health {
            get { return Chronic.Health; }
        }

        public double Height {
            get { return Chronic.Height; }

            set { Chronic.Height = value; }
        }

        public int MaxHealth {
            get { return Chronic.MaxHealth; }
        }

        public double MaxYield {
            get { return Chronic.MaxYield; }
        }

        public string Name {
            get { return Chronic.Name; }
        }

        public double Quality {
            get { return Chronic.Quality; }

            set { Chronic.Quality = value; }
        }

        public int SeedingAge {
            get { return Chronic.SeedingAge; }
        }

        
        public double THC {
            get { return Chronic.THC; }
        }

        public double Trimmings {
            get { return Chronic.Trimmings; }
        }

        public Water Water {
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

        public Dictionary<Stage, Water> WaterNeed {
            get { return Chronic.WaterNeed; }
        }

        public Dictionary<Stage, Light> LightNeed
        {
            get { return Chronic.LightNeed; }
        }

        public double Yield {
            get { return Chronic.Yield; }

            set { Chronic.Yield = value; }
        }

        public event EventHandler Died;

        public IChronic Clone()
        {
            return Chronic.Clone();
        }

        public IChronic Cure(IContainer container)
        {
            throw new InvalidOperationException(
                "Cannot Cure a CannaOil in this state. CannaOil is a finalized product.");
        }

        public IChronic Dry()
        {
            throw new InvalidOperationException(
                "Cannot Dry a CannaOil in this state. CannaOil is a finalized product.");
        }

        public IChronic Finish()
        {
            throw new InvalidOperationException(
                "Cannot Finish a CannaOil in this state. CannaOil is a finalized product.");
        }

        public IChronic Grow(Water water, Light light, Food food)
        {
            throw new InvalidOperationException(
                "Cannot Grow a CannaOil in this state. CannaOil is a finalized product.");
        }

        public IChronic Harvest()
        {
            throw new InvalidOperationException(
                "Cannot Harvest a CannaOil in this state. CannaOil is a finalized product.");
        }

        public ISolvent Heat()
        {
            throw new InvalidOperationException(
                "Cannot Heat a CannaOil in this state. CannaOil is a finalized product.");
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public void SetStage(Stage stage)
        {
            throw new NotImplementedException();
        }

        public IChronic Weck()
        {
            throw new InvalidOperationException(
                "Cannot Weck a CannaOil in this state. CannaOil is a finalized product.");
        }
    }
}
