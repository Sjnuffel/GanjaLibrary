using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Enums;

namespace GanjaLibrary.Classes.Items.Filters
{
    public class WaterFilter : Item, IFilter
    {
        public double Effectiveness { get; set; } 

        // Base template for a filter.
        public WaterFilter() :base()
        {
            Name = "Template Filter";
            Description = "Base Template for a filter";

            Weight = 2;
            Value = 0.50;
            Effectiveness = 0;

            Type = ItemType.Filter;
        }

        protected WaterFilter(WaterFilter other): base(other)
        {
            Effectiveness = other.Effectiveness;
        }

        public override object Clone()
        {
            return new WaterFilter(this);
        }
    }
}
