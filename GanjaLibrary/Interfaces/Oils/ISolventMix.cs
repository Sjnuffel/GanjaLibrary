using GanjaLibrary.Interfaces.Oils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanjaLibrary.Interfaces.Oils
{
    public interface ISolventMix
    {
        ISolventMix Wash();
        Tuple<IChronic, ISolvent> Filter();
        double Heat();
    }
}