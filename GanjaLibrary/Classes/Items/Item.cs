﻿using GanjaLibrary.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanjaLibrary.Classes.Items
{
    [Serializable]
    public class Item : IItem
    {
        public string Description { get; set; }
        public string Name { get; set; }

        public double Weight { get; set; }
        public double Value { get; set; }

        public Guid Id { get; set; }

       
        public Item()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            Weight = 0;
            Value = 0;
            Description = string.Empty;
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