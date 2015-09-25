using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Enums;
using System;

namespace GanjaLibrary.Classes.Oils
{
    public partial class Solvent : ISolvent, IChronic, IChemical
    {
        private IChronic Chronic { get; set; }
        private IChemical Chemical { get; set; }

        // Solvent is a mix of THC (from Chronic) and Chemicals
        public Solvent(IChronic chronic, IChemical chemical)
        {
            Age = 0;
            Chronic = chronic.Clone();
            Chemical = chemical.Clone();
            // Chemical.Contents would not transfer to Solvent.Contents, so forcing it this way
            this.Contents = Chemical.Contents;

            Name = string.Format("{0} - {1} Solventmix", Chronic.Name, Chemical.Name);
            Description = string.Format("A solventmix consisting of {0} and {1}", Chronic.Name, Chemical.Name);
        }

        public event EventHandler Died;

        // Heating the chemical out of the solvent
        public ISolvent Heat()
        {
            // While there is chemical in the bottle, heat it away.
            while (Chemical.Contents != 0)
            {
                // Change it to Heating Stage, if it isn't yet.
                if (Chronic.Stage == Stage.Filtering)
                    Chronic.SetStage(Stage.Heating);

                this.Contents -= 50;
                this.Age++;

                return this;
            }

            // If chemical is all gone, return CannaOil.
            if (Chemical.Contents == 0)
            {
                // Since all the chemical has dissipated, reduce the yield to reflect the true THC contents
                this.Yield *= 0.25;
                this.Value *= Chronic.Quality;
                
                return new CannaOil() as ISolvent;
            }

            else return this;
        }

        // Refer to Chronic clone
        public IChronic Clone()
        {
            return Chronic.Clone();
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

        // Refer to Clone from Chemical class.
        IChemical IChemical.Clone()
        {
            return Chemical.Clone();
        }
    }
}
