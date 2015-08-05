using GanjaLibrary.Interfaces.Items;
using System.Collections.Generic;

namespace GanjaLibrary.Classes.Items
{
    public class CargoPants : Item, IContainer
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

        public CargoPants() : base("Cargopants", "Pockets everywhere! Imagine the blunts you could hide in there.", 3, 250)
        {
            Items = new List<IItem>();
            Slots = 8;
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