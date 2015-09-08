/*

    We can assume this is the base chemical every chemical is based off of.

*/

using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Enums;
using System;

namespace GanjaLibrary.Classes
{
    public class Chemical : Item, IChemical
    {
        public double Flashpoint { get; internal set; }
        public double Contents { get; set; }

        public bool Flammable { get; internal set; }
        public bool Denatured { get; internal set;  }

        // Inherit from Item and input name, description, weight and value in constructor.
        public Chemical() :base(string.Empty, string.Empty, 1, 0)
        {
            Flashpoint = 100;
            Contents = 1000;

            Flammable = false;
            Denatured = false;

            Type = ItemType.Chemical;
        }

        protected Chemical(Chemical other) : base(other) { }

        public override object Clone()
        {
            return new Chemical(this);
        }

        IChemical IChemical.Clone()
        {
            return (IChemical)Clone();
        }
    }
}
