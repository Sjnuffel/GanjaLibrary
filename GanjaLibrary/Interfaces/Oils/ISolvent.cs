using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Interfaces.Oils
{
    public interface ISolvent: IItem
    {
        /// <summary>
        /// Heat off the chemical from the Solvent
        /// </summary>
        ISolvent Heat();

        double Yield { get; }
        double Quality { get; }
        double THC { get; }
        double CBD { get; }

        ISolvent Clone();

        /// <summary>
        /// Set the THC of a Chemical
        /// </summary>
        /// <param name="amount">Amount of THC to set.</param>
        void SetTHC(double amount);
        void SetCBD(double amount);

        /// <summary>
        /// Print function for ISolventmix
        /// </summary>
        void Print();

        //ISolvent Clone();
        void SetYield(double yield);
    }
}