namespace GanjaLibrary.Interfaces.Items
{
    public interface IFilter : IItem
    {
        /// <summary>
        /// Effectiveness of the filter.
        /// </summary>
        double Effectiveness { get; set; }
    }
}