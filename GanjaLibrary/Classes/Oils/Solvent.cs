using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Interfaces;
using System;
using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Oils
{
    class Solvent : ISolvent
    {
        private IChronic Chronic;
        private IChemical Chemical;

        public Solvent(IChronic chronic, IChemical chemical)
        {
            Chronic = chronic.Clone();
            Chemical = chemical.Clone();
        }

        ISolvent ISolvent.Heat()
        {
            throw new NotImplementedException();
        }
    }
}
