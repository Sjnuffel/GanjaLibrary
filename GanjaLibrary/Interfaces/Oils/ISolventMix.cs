using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Interfaces.Oils
{
    public struct FilterResult
    {
        public IChronic Chronic { get; internal set; }
        public ISolvent Solvent { get; internal set; }

        public FilterResult(IChronic chronic, ISolvent solvent)
        {
            Chronic = chronic;
            Solvent = solvent;
        }
    }

    public interface ISolventMix
    {
        /// <summary>
        /// Wash out the THC/CBD with the Chemical from the Weed in the SolventMix
        /// </summary>
        ISolventMix Wash(int washCount = 1);

        /// <summary>
        /// Filter a Tuple of IChronic and ISolvent representing SolventMix
        /// </summary>
        FilterResult Filter(IFilter filter);

        /// <summary>
        /// Print function for ISolventmix
        /// </summary>
        void Print();

        /// <summary>
        /// Clone the SolventMix
        /// </summary>
        /// <returns></returns>
        ISolventMix Clone();
    }
}