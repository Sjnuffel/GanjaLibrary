﻿using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;
using System;

namespace GanjaLibrary.Classes.Oils
{
    public partial class Solvent : Item, ISolvent
    {
        public int Age { get; protected set; }

        // double variables
        public double THC { get; protected set; }
        public double CBD { get; protected set; }

        public double Yield { get; protected set; }
        public double Quality { get; protected set; }

        public double Contents { get; protected set; }

        // Solvent is a mix of THC (from Chronic) and Chemicals
        public Solvent(IChronic chronic, IChemical chemical)
        {
            Contents = chemical.Contents;
            Age = 0;
            THC = 0;
            CBD = 0;
            Yield = 0;
            Quality = chronic.Quality;
            Name = chronic.Name + chemical.Name;
            Description = chemical.Description;
        }

        public event EventHandler Died;

        // Heating the chemical out of the solvent
        public ISolvent Heat()
        {
            // While there is chemical in the bottle, heat it away.
            while (Contents > 0)
            {
                Age++;
                Contents -= 100;
                Weight *= 0.9;
                return this;
            }

            // Make sure Contents never go negative, set it to 0 if it does.
            if (Contents < 0)
            {
                Contents = 0;
                Weight = Yield;
            }

            return this;
        }

        public void SetTHC(double amount)
        {
            THC = amount;
        }

        public void SetCBD(double amount)
        {
            CBD = amount;
        }

        public void SetYield(double yield)
        {
            Yield = yield;
        }

        // Refer to print from Chronic class
        public void Print()
        {
            Console.WriteLine(Name + " " + Description);
        }

        public override object Clone()
        {
            return (this as ISolvent).Clone();
        }

        protected Solvent(Solvent other) : base(other)
        {
            Age = other.Age;
            THC = other.THC;
            CBD = other.CBD;
            Yield = other.Yield;
            Quality = other.Quality;
            Contents = other.Contents;
        }

        ISolvent ISolvent.Clone()
        {
            return (ISolvent)Clone();
        }

        public void ImproveYield(double percentage)
        {
            Yield *= percentage;
        }

        public void ImproveQuality(double percentage)
        {
            Quality *= percentage;
        }

        public void ImproveWeight(double percentage)
        {
            Weight *= percentage;
        }

        public void SetWeight(double amount)
        {
            Weight = amount;
        }

        public ISolvent Add(ISolvent toAdd)
        {
            Quality = (Quality + toAdd.Quality) / 2;
            Yield = (Yield + toAdd.Yield) / 2;
            Weight += toAdd.Weight;

            // Set toAdd's values to zero, since it's added to the main solvent.
            toAdd.ImproveYield(0);
            toAdd.ImproveQuality(0);
            toAdd.ImproveWeight(0);

            return this;
        }
    }
}
