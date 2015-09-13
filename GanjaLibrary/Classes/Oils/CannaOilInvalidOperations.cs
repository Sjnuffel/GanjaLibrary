using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Interfaces.Oils;
using System;

namespace GanjaLibrary.Classes.Oils
{
    partial class CannaOil
    {
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

        public IChronic Weck()
        {
            throw new InvalidOperationException(
                "Cannot Weck a CannaOil in this state. CannaOil is a finalized product.");
        }
    }
}
