using GanjaLibrary.Interfaces.Oils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GanjaLibrary.Interfaces;

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
