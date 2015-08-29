using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Enums;
using System;
using GanjaLibrary;

namespace GanjaLibrary.Classes.Items
{
    [Serializable]
    public class Item : IItem
    {
        public string Description { get; set; }
        public string Name { get; set; }

        public double Weight { get; set; }
        public double Value { get; set; }

        public int MaxStackableQuantity { get; set; }

        public Guid Id { get; set; }


        public Item()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Weight = 0;
            Value = 0;
            Description = string.Empty;
            MaxStackableQuantity = 1;
        }

        public Item(string name, string description, double weight, double value) :this()
        {
            Name = name;
            Description = description;
            Weight = weight;
            Value = value;
        }
    }
}
