using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Oils
{
    class Solvent : ISolvent
    {
        private IChronic Chronic;

        public Solvent(IChronic chronic)
        {
            Chronic = chronic.Clone();
        }
    }
}
