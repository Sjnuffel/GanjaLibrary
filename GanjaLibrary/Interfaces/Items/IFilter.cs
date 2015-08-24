namespace GanjaLibrary.Interfaces.Items
{
    public interface IFilter : IItem
    {
        /// <summary>
        /// To specify if this is a filter used in air filtration.
        /// </summary>
        bool AirFilter { get; }

        /// <summary>
        /// To specify if this is a filter used in water filtration.
        /// </summary>
        bool WaterFilter { get; }
        double Effectiveness { get; set; }
    }
}