/*

The most basic type of filter that can be used to seperate the waste from the solvent.

*/

namespace GanjaLibrary.Classes.Items.Filters
{
    public class CoffeeFilter : Filter
    {
        public CoffeeFilter() :base()
        {
            Name = "Coffee Filter";
            Description = "A pack of 10 coffee filters, if you still filter your coffee the old fashion way";

            Weight = 0.5;
            Value = 2.50;

            MaxStackableQuantity = 10;
            WaterFilter = true;
        }
    }
}
