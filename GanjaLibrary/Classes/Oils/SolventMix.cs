using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;
using System;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Oils;

namespace GanjaLibrary.Classes.Oils
{
    public partial class SolventMix : ISolventMix, IChronic, IChemical
    {
        private IChronic Chronic { get; set; }
        private IChemical Chemical { get; set; }

        private double _extractedOils;
        private double _remainingOils;
        private double _washCount;
        private double _solventRatio;
        private double _washRemains;

        // SolventMix is a mix of Weed-leaves and chemical(s).
        public SolventMix(IChronic chronic, IChemical chemical)
        {
            _washCount = 0;
            _solventRatio = 0;
            _washRemains = 0;

            _extractedOils = new Random().Next(75, 85);
            _remainingOils = 100 - _extractedOils;

            Chronic = chronic;
            Chemical = chemical;
        }

        public event EventHandler Died;

        public ISolventMix Wash()
        {
            // Calculate the solvent first so it doesn't change initial calculation
            if (_washCount == 0)
            {
                // Calculate solvent ratio for this batch of weed
                _solventRatio = Yield + Trimmings;
                _solventRatio *= 3;
            }

            if (_solventRatio <= Contents || Yield + Trimmings > MaxStackableQuantity)
            {
                if (_washCount == 0)
                {
                    // Remove the solvent from the chemical bottle
                    Contents -= _solventRatio;
                    
                    // Extract either THC or CBD from the yield
                    if (THC >= CBD)
                    {
                        Yield += Trimmings;
                        Yield *= THC;
                    }
                    if (CBD > THC)
                    {
                        Yield += Trimmings;
                        Yield *= CBD;
                    }

                    // We have to work with a %
                    _remainingOils /= 100;
                    _extractedOils /= 100;

                    // Calculate remainder.
                    _washRemains = Yield * _remainingOils;
                    // Extract the first 80% of THC/CBD during first wash
                    Yield *= _extractedOils;
                    SetStage(Stage.Washing);
                    _washCount++;
                    return this;
                }

                if (_washCount == 1)
                {
                    Contents -= _solventRatio;
                    // Add remainder to the yield
                    Yield += _washRemains;
                    _washCount++;
                    return this;
                }

                // Washing any more will dissolve the green bits, thus reducing the oil quality
                if (_washCount > 1)
                {
                    Contents -= _solventRatio;
                    Quality *= 0.95;
                    _washCount++;
                }
            }

            return this;
        }

        // Apply filter to SolventMix and return Waste (as Chronic) and Solvent (Chemical with THC extracted)
        public Tuple<IChronic, ISolvent> Filter(IFilter filter)
        {
            Tuple<IChronic, ISolvent> retVal = null;

            IChronic tmpChronic = Chronic.Clone();
            tmpChronic.SetStage(Stage.Filtering);

            // Use the effectiveness of the filter to improve the yield/quality
            if (filter.Effectiveness >= 1 || filter.Effectiveness < 10)
            {
                tmpChronic.Yield *= 1.01;
            }

            // The Solvent consists of the (THC/CBD, yield, etc.) values of Chronic, with the Chemical.Contents
            ISolvent tmpSolvent = new Solvent(Chronic, Chemical);

            retVal = new Tuple<IChronic, ISolvent>(tmpChronic, tmpSolvent);

            return retVal;
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

        // Refer to Chronic clone
        public IChronic Clone()
        {
            return Chronic.Clone();
        }
    }
}