using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary
{
    public interface ICannaOil: IItem
    {
        double Yield { get; }
        double Quality { get; }

        /// <summary>
        /// Print function for ISolventmix
        /// </summary>
        void Print();

        ICannaOil Clone();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        ICannaOil Add(ICannaOil toAdd);
    }
}