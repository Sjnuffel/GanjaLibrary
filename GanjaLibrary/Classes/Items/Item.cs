using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Enums;
using System;

namespace GanjaLibrary.Classes
{
    public abstract class Item : IItem
    {
        public string Description { get; set; }
        public string Name { get; set; }

        public double Weight { get; set; }
        public double Value { get; set; }

        public int MaxStackableQuantity { get; set; }

        public Guid Id { get; set; }
        public ItemType Type { get; set; }

        public Item()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Description = string.Empty;

            Weight = 0;
            Value = 0;
            MaxStackableQuantity = 1;

            Type = ItemType.BaseItem;
        }

        public Item(string name, string description, double weight, double value) : this()
        {
            Name = name;
            Description = description;
            Weight = weight;
            Value = value;
        }

        protected Item(IItem other)
        {
            Description = other.Description;
            Name = other.Name;
            Weight = other.Weight;
            Value = other.Value;
            MaxStackableQuantity = other.MaxStackableQuantity;
            Id = other.Id;
            Type = other.Type;
        }

        public abstract object Clone();
    }
}
