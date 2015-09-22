using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Enums;
using System;

namespace GanjaLibrary.Classes.Oils
{
    public partial class Solvent : ISolvent, IChronic
    {
        private IChronic Chronic { get; set; }
        private IChemical Chemical { get; set; }

        // Solvent is a mix of THC (from Chronic) and Chemicals
        public Solvent(IChronic chronic, IChemical chemical)
        {
            Age = 0;
            Chronic = chronic.Clone();
            Chemical = chemical.Clone();

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
                Chemical.Contents -= 50;
                this.Age++;

                return this;
            }
            
            // Remember this was poison?
            if (Chemical.Contents != 0 && Chemical.Denatured == true)
                Chronic.Quality *= 0.8;

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
    }
}
