/*

    A cheap coffee filter to filter water from the coffee grounds.
    The same principle works fine for weed remains as well.

    */

namespace GanjaLibrary.Classes.Items.Filters
{
    class CoffeeFilter : Filter
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
