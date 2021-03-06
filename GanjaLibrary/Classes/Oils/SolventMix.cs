﻿using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;
using System;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Exceptions;

namespace GanjaLibrary.Classes.Oils
{
    public partial class SolventMix
    {
        private IChronic Chronic { get; set; }
        private IChemical Chemical { get; set; }
        private ISolvent Solvent { get; set; }

        private double _extractedOils;

        // SolventMix is a mix of Weed-leaves and chemical(s).
        public SolventMix(IChronic chronic, IChemical chemical):base(chronic.Name + " " + chemical.Name, chronic.Description + " " + chemical.Description, chronic.Weight + chemical.Weight, chronic.Value)
        {
            Type = ItemType.SolventMix;

            _extractedOils = new Random().NextDouble() * (0.85 - 0.75) + 0.75;
            Chronic = chronic;
            Chemical = chemical;
            Solvent = new Solvent(Chronic, Chemical);
        }

        public event EventHandler Died;

        // Wash the THC/CBD from the plant remains.
        public ISolventMix Wash(int washCount = 1)
        {
            // Check if there's enough chemical available to wash.
            if (Chemical.Contents <= (Chronic.Yield * 2.5))
                throw new NotEnoughSolventException(Chemical);

            Weight = (Contents + Yield) / 1.5;
            SetStage(Stage.Washing);

            // When washing for the first time, extract 80% of the THC.
            if (washCount == 1)
            {
                Solvent.SetTHC(_extractedOils * Chronic.THC);
                Solvent.SetCBD(_extractedOils * Chronic.CBD);
                Solvent.SetYield((Chronic.THC * Chronic.Yield) + (Chronic.CBD * Chronic.Yield));
                Chronic.ImproveTHC(0.2);
                Chronic.ImproveCBD(0.2);
            }

            // When washing for the second time, extract remaining 20% of the THC.
            if (washCount == 2)
            {
                Solvent.SetTHC(Chronic.THC);
                Solvent.SetCBD(Chronic.CBD);
                Solvent.SetYield((Chronic.THC * Chronic.Yield) + (Chronic.CBD * Chronic.Yield));
                Chronic.ImproveTHC(0);
                Chronic.ImproveCBD(0);
            }

            return this;
        }

        // Apply filter to SolventMix and return Waste (as Chronic) and Solvent (Chemical with THC extracted)
        public FilterResult Filter(IFilter filter)
        {
            SetStage(Stage.Filtering);

            // Use the effectiveness of the filter to improve the yield/quality\
            Solvent.SetYield(Solvent.Yield * (1 + (filter.Effectiveness / 100)));
            // Change the weight to reflect the filtered status
            Chronic.SetWeight(Yield);
            Solvent.SetWeight((Weight - Yield));

            return new FilterResult(Chronic, Solvent);
        }

        // Refer to print from Chronic class
        public void Print()
        {
            Chronic.Print();
        }

        // Refer to SetStage method from Chronic.
        public void SetStage(Stage stage)
        {
            Chronic.SetStage(stage);
        }

        // Refer to Chemical Clone method.
        IChemical IChemical.Clone()
        {
            return Chemical.Clone();
        }

        // The components of SolventMix that are called to be cloned.
        protected SolventMix(SolventMix other): base(other)
        {
            Chronic = other.Chronic;
            Chemical = other.Chemical;
            Solvent = other.Solvent;
        }

        ISolventMix ISolventMix.Clone()
        {
            return (ISolventMix)Clone();
        }

        public override object Clone()
        {
            return (this as ISolventMix).Clone();
        }

        // Method to increase or Decrease the yield by a percentage.
        public void ImproveYield(double percentage)
        {
            Chronic.ImproveYield(percentage);
        }
    }
}