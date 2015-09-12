using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;
using System;

namespace GanjaLibrary.Classes.Oils
{
    partial class SolventMix
    {
        public IChronic Grow(Water water, Light light, Food food)
        {
            throw new InvalidOperationException(
                "Cannot Grow a Solventmix in this state. Finish the process it is in first");
        }

        public IChronic Harvest()
        {
            throw new InvalidOperationException(
                "Cannot Harvest a Solventmix in this state. Finish the process it is in first");
        }

        public IChronic Dry()
        {
            throw new InvalidOperationException(
                "Cannot Dry a Solventmix in this state. Finish the process it is in first");
        }

        public IChronic Cure(IContainer container)
        {
            throw new InvalidOperationException(
                "Cannot Cure a Solventmix in this state. Finish the process it is in first");
        }

        public IChronic Finish()
        {
            throw new InvalidOperationException(
                "Cannot Finish a Solventmix in this state. Finish the process it is in first");
        }

        public IChronic Weck()
        {
            throw new InvalidOperationException(
                "Cannot Weck a Solventmix in this state. Finish the process it is in first");
        }
    }
}
