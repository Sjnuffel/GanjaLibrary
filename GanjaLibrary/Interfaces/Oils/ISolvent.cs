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

        //ISolvent Clone();
        void SetYield(double yield);
    }
}