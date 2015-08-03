using GanjaLibrary.Interfaces.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanjaLibrary.Classes.Items
{
    public class Shop : IShop, IContainer
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

        public Shop()
        {
            Items = new List<IItem>();
            Slots = 10;
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

        private bool Remove(IItem item)
        {
            return Items.Remove(item);
        }

        public double Sell(IItem item)
        {
            double retVal = item.Value;
            Add(item);
            return retVal;
        }
        
        public IItem Buy(string name)
        {
            IItem retVal = Items.FirstOrDefault(x => x.Name == name);
            Items.Remove(retVal);
            return retVal;
        }
    }
}
