using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanjaLibrary.Interfaces.Items
{
    public interface IShop
    {
        /// <summary>
        /// Amount of items in the shop storage.
        /// </summary>
        int ItemAmount { get; }

        /// <summary>
        /// Sell an item.
        /// </summary>
        double Sell(IItem item);

        IItem Buy(string name);
    }
}