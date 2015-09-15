using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Oils
{
    class Solvent : ISolvent
    {
        private IChronic Chronic;
        private IChemical Chemical;

        // Solvent is a mix of THC (from Chronic) and Chemicals
        public Solvent(IChronic chronic, IChemical chemical)
        {
            Chronic = chronic.Clone();
            Chemical = chemical.Clone();
        }

        // Heating the chemical out of the solvent
        public ISolvent Heat()
        {
            // If there is still chemical left, remove it
            if (Chemical.Contents >= 50)
                Chemical.Contents -= 50;

            // Remember this was poison?
            if (Chemical.Denatured == true)
                Chronic.Quality *= 0.8;

            // If chemical is all gone, return CannaOil.
            if (Chemical.Contents <= 50)
            {
                // Since all the chemical has dissipated, reduce the yield to reflect the true THC contents
                Chronic.Yield *= 0.25;

                return new CannaOil() as ISolvent;
            }

            else return this;
        }
    }
}
