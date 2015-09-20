namespace GanjaLibrary
{
    public interface ICannaOil
    {
        /// <summary>
        /// Calculate the value of the oil
        /// </summary>
        ICannaOil CalculatePrice();

        /// <summary>
        /// Print function for ISolventmix
        /// </summary>
        void Print();
    }
}