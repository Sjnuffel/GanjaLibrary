﻿using GanjaLibrary.Interfaces;
using System;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Oils
{
    public class CannaOil : Item, ICannaOil
    {
        public override double Value { get { return Quality * Yield; } internal set { throw new NotSupportedException("Value of CannaOil is calculated. Unable to set."); } }

        private ISolvent Solvent { get; set; }

        // Doubles
        public double Quality { get; protected set; }
        public double Yield { get; internal set; }

        public CannaOil(ISolvent solvent, string name): base(string.Format("Pure {0} Honey Oil", name), string.Format("Honey oil made with {0}.", name), (solvent as IItem).Weight, (solvent as IItem).Value)
        {
            Solvent = solvent;
            Type = ItemType.CannaOil;
            Yield = solvent.Yield * 0.25;
        }

        public event EventHandler Died;

        // Refer to IChronic's print method
        public void Print()
        {
            Solvent.Print();
        }

        public ICannaOil Add(ICannaOil toAdd)
        {
            Quality = (Quality * Yield) + (toAdd.Quality * Yield) / (Yield + toAdd.Yield);
            Yield = Yield + toAdd.Yield;

            return this;
        }

        // The variables to copy.
        protected CannaOil(CannaOil other) : base(other)
        {
            Solvent = other.Solvent;
            Quality = other.Quality;
            Yield = other.Yield;
        }

        public override object Clone()
        {
            return (this as ICannaOil).Clone();
        }

        ICannaOil ICannaOil.Clone()
        {
            return (ICannaOil)Clone();
        }
    }
}
