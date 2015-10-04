/*

    We can assume this is the base chemical every chemical is based off of.

*/

using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Enums;
using System;

namespace GanjaLibrary.Classes
{
    public abstract class Chemical : Item, IChemical
    {
        public double Flashpoint { get; internal set; }
        public double Contents { get; set; }

        public bool Flammable { get; internal set; }
        public bool Denatured { get; internal set; }

        public double THC { get; protected set; }

        public double CBD { get; protected set; }

        // Inherit from Item and input name, description, weight and value in constructor.
        public Chemical() :base("Chemical", "Standard Chemical", 1, 0)
        {
            Flashpoint = 100;
            Contents = 1000;

            Flammable = false;
            Denatured = false;

            Type = ItemType.Chemical;
        }

        // The variables to copy.
        protected Chemical(Chemical other) : base(other)
        {
            Flashpoint = other.Flashpoint;
            Contents = other.Contents;

            Flammable = other.Flammable;
            Denatured = other.Denatured;
        }
        
        public abstract override object Clone();

        IChemical IChemical.Clone()
        {
            return (IChemical)Clone();
        }

        public void SetTHC(double amount)
        {
            THC = amount;
        }

        public void SetCBD(double amount)
        {
            CBD = amount;
        }

        public void Print()
        {
            throw new NotImplementedException();
        }
    }
}
