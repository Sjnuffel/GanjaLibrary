using System;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Oils
{
    public class CannaOil : Item, ICannaOil
    {
        public override double Value { get { return Quality * Yield; } }

        private ISolvent Solvent { get; set; }

        // Doubles
        public double Quality { get; protected set; }
        public double Yield { get; internal set; }

        public CannaOil(ISolvent solvent, string name): base(string.Format("Pure {0} Honey Oil", name), string.Format("Honey oil made with {0}.", name), (solvent as IItem).Weight, (solvent as IItem).Value)
        {
            Solvent = solvent;
            Quality = solvent.Quality;
            Type = ItemType.CannaOil;
            Yield = solvent.Yield * 0.25;
            Weight = Yield;
        }

        public event EventHandler Died;

        // Refer to IChronic's print method
        public void Print()
        {
            Solvent.Print();
        }

        // Add two CannaOil's together into one.
        public ICannaOil Add(ICannaOil toAdd)
        {
            Quality = (Quality + toAdd.Quality) / 2;
            Yield = (Yield + toAdd.Yield) / 10;
            Weight = Yield;

            // Set toAdd's values to zero, since it's added to the main one.
            toAdd.ImproveYield(0);
            toAdd.ImproveQuality(0);
            toAdd.ImproveWeight(0);

            return this;
        }

        // The variables to copy.
        protected CannaOil(CannaOil other) : base(other)
        {
            Solvent = other.Solvent;
            Quality = other.Quality;
            Yield = other.Yield;
            Weight = other.Weight;
        }

        public override object Clone()
        {
            return (this as ICannaOil).Clone();
        }

        ICannaOil ICannaOil.Clone()
        {
            return (ICannaOil)Clone();
        }

        public void ImproveYield(double percentage)
        {
            Yield *= percentage;
        }

        public void ImproveWeight(double percentage)
        {
            Weight *= percentage;
        }

        public void ImproveQuality(double percentage)
        {
            Quality *= percentage;
        }
    }
}
