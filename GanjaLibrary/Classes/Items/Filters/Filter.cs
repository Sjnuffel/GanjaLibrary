using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Enums;
using System;

namespace GanjaLibrary.Classes.Items.Filters
{
    public class Filter : IFilter
    {
        // Implement IFilter interface.
        public Guid Id { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }

        public double Value { get; set; }
        public double Weight { get; set; }

        public int MaxStackableQuantity { get; set; }

        public bool AirFilter { get; set; }
        public bool WaterFilter { get; set; }

        public double Effectiveness { get; set; } 

        public ItemType Type { get; set; }

        // Base template for a filter.
        public Filter() :base()
        {
            Name = "Template Filter";
            Description = "Base Template for a filter";

            Weight = 2;
            Value = 0.50;

            AirFilter = true;
            WaterFilter = false;

            Type = ItemType.Filter;
        }
    }
}
