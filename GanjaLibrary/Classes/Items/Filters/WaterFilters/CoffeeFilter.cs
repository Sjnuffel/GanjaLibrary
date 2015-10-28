/*

The most basic type of filter that can be used to seperate the waste from the solvent.

*/

using GanjaLibrary.Enums;
using System;

namespace GanjaLibrary.Classes.Items.Filters
{
    public class CoffeeFilter : WaterFilter
    {
        public CoffeeFilter() :base()
        {
            Name = "Coffee Filter";
            Description = "One coffee filter";

            Weight = 0.5;
            Value = 2.50;

            MaxStackableQuantity = 1;
        }
    }
}
