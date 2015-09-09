using System;

namespace GanjaLibrary.Interfaces.Oils
{
    public interface ISolventMix
    {
        /// <summary>
        /// Wash out the leaves/weedremains from the SolventMix
        /// </summary>
        ISolventMix Wash();

        /// <summary>
        /// Filter a Tuple of IChronic and ISolvent representing SolventMix
        /// </summary>
        Tuple<IChronic, ISolvent> Filter();

        /// <summary>
        /// Print function for ISolventmix
        /// </summary>
        void Print();
    }
}