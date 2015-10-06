using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Enums;
using System;

namespace GanjaLibrary.Classes
{
    public abstract class Item : IItem
    {
        protected double _value = 0;

        public string Description { get; set; }
        public string Name { get; set; }

        public double Weight { get; set; }
        public virtual double Value { get { return _value; } internal set { _value = value; } }

        public int Amount { get; set; }
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
            Amount = 1;
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

        // Clone information from the overloaded item
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

        // Clone an item
        public abstract object Clone();
    }
}
