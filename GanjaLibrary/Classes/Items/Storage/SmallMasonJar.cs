using GanjaLibrary.Interfaces.Items;
using System.Collections.Generic;
using GanjaLibrary.Interfaces;
using System;

namespace GanjaLibrary.Classes.Items.Storage
{
    public class SmallMasonJar : Item, IContainer
    {
        public List<IItem> Items { get; set; }

        public int Slots { get; internal set; }
        public int ItemAmount
        {
            get
            {
                if (Items == null) return 0;
                else return Items.Count;
            }
        }

        public SmallMasonJar() :base("Small Mason Jar", "Useful for keeping stuff sealed in for a long period of time", 2, 25)
        {
            Items = new List<IItem>();
            Slots = 1;
        }

        public bool Add(IItem item)
        {
            if (ItemAmount != Slots)
            {
                Items.Add(item);
                if (Items.Contains(item))
                    return true;
            }

            return false;
        }

        public bool Remove(IItem item)
        {
            return Items.Remove(item);
        }

        public bool Contains(IItem item)
        {
            if (Items.Contains(item))
            {
                return true;
            }

            return false;
        }

        public double Sell(IItem item)
        {
            double retVal = item.Value;
            if (Remove(item))
                return retVal;
            else
                return 0;
        }
    }
}
