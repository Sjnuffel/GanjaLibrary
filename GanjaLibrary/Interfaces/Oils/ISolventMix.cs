using System;

namespace GanjaLibrary.Interfaces.Oils
{
    public interface ISolventMix
    {
        /// <summary>
        /// Wash out the leaves/weedremains from the SolventMix
        /// </summary>
        /// <returns></returns>

        ISolventMix Wash();

        /// <summary>
        /// Filter a Tuple of IChronic and ISolvent representing SolventMix
        /// </summary>
        /// <returns></returns>
        Tuple<IChronic, ISolvent> Filter();

        /// <summary>
        /// Heat off the chemical from the Solvent
        /// </summary>
        /// <returns></returns>
        double Heat();
    }
}