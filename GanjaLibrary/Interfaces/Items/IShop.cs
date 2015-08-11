﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanjaLibrary.Interfaces.Items
{
    public interface IShop : IContainer
    {
        /// <summary>
        /// Sell an item to the shop.
        /// </summary>
        double Sell(IItem item);

        /// <summary>
        /// Buy an item from the shop.
        /// </summary>
        IItem Buy(string name);
    }
}