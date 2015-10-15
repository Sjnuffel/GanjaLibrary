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

        /// <summary>
        /// Increase or decrease the yield of the CannaOil by a certain percentage
        /// </summary>
        /// <param name="percentage">The percentage to increase (or decrease) the yield by</param>
        void ImproveYield(double percentage);

        /// <summary>
        /// Increase or decrease the quality of the CannaOil by a certain percentage
        /// </summary>
        /// <param name="percentage">The percentage to increase (or decrease) the yield by</param>
        void ImproveQuality(double percentage);

        /// <summary>
        /// Increase or decrease the Weight of the CannaOil by a certain percentage
        /// </summary>
        /// <param name="percentage">The percentage to increase (or decrease) the yield by</param>
        void ImproveWeight(double percentage);
    }
}