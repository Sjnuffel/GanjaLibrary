
namespace GanjaLibrary.Interfaces.Items
{
    public interface IChemical : IItem
    {
        /// <summary>
        /// Boiling point of a chemical, in degrees Celsius.
        /// </summary>
        double Flashpoint { get; set; }
        /// <summary>
        /// Amount of chemical in the package (in ml.)
        /// </summary>
        double Contents { get; set; }
        /// <summary>
        /// If the product is flammable or not.
        /// </summary>
        bool Flammable { get; set; }
    }
}