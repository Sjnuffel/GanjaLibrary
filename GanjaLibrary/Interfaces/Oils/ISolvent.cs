using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Interfaces.Oils
{
    public interface ISolvent: IItem
    {
        /// <summary>
        /// Heat off the chemical from the Solvent
        /// </summary>
        ISolvent Heat();

        /// <summary>
        /// Actual yield of useful product (ie.: Honey Oil)
        /// </summary>
        double Yield { get; }

        /// <summary>
        /// Quality of the solvent (helps determine the value)
        /// </summary>
        double Quality { get; }

        /// <summary>
        /// Amount of THC in the solvent (as a %)
        /// </summary>
        double THC { get; }

        /// <summary>
        /// Amount of CBD in the solvent (as a %)
        /// </summary>
        double CBD { get; }
        
        /// <summary>
        /// The remaining chemical contents in the solvent (in ml.).
        /// </summary>
        double Contents { get; }

        /// <summary>
        /// Clone the Solvent.
        /// </summary>
        ISolvent Clone();

        /// <summary>
        /// Set the THC of a Chemical
        /// </summary>
        /// <param name="amount">Amount of THC to set.</param>
        void SetTHC(double amount);

        /// <summary>
        /// Set the CBD of a Chemical
        /// </summary>
        /// <param name="amount">Amount of THC to set.</param>
        void SetCBD(double amount);

        /// <summary>
        /// Print function for ISolventmix
        /// </summary>
        void Print();

        /// <summary>
        /// Be able to set the yield.
        /// </summary>
        void SetYield(double yield);

        /// <summary>
        /// Increase or decrease the yield of the Solvent by a certain percentage
        /// </summary>
        /// <param name="percentage">The percentage to increase (or decrease) the yield by</param>
        void ImproveYield(double percentage);

        /// <summary>
        /// Increase or decrease the quality of the Solvent by a certain percentage
        /// </summary>
        /// <param name="percentage">The percentage to increase (or decrease) the yield by</param>
        void ImproveQuality(double percentage);

        /// <summary>
        /// Increase or decrease the Weight of the Solvent by a certain percentage
        /// </summary>
        /// <param name="percentage">The percentage to increase (or decrease) the yield by</param>
        void ImproveWeight(double percentage);

        /// <summary>
        /// Add the amounts of one Solvent to the other (yield/quality etc.)
        /// </summary>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        ISolvent Add(ISolvent toAdd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weight"></param>
        void SetWeight(double amount);
    }
}