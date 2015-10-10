using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary
{
    public interface ICannaOil: IItem
    {
        /// <summary>
        /// Actual yield of useful product (ie.: Honey Oil)
        /// </summary>
        double Yield { get; }

        /// <summary>
        /// Quality of the Cannabis Oil (helps determine the value)
        /// </summary>
        double Quality { get; }

        /// <summary>
        /// Print function for ISolventmix
        /// </summary>
        void Print();

        /// <summary>
        /// Clone the CannaOil.
        /// </summary>
        ICannaOil Clone();

        /// <summary>
        /// Add the amounts of one CannaOil to the other (yield/quality etc.)
        /// </summary>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        ICannaOil Add(ICannaOil toAdd);
    }
}