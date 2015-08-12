using GanjaLibrary.Interfaces.Items;
using System.Collections.Generic;

namespace GanjaLibrary.Classes.Items
{
    public class CargoPants : Trousers
    {
        public CargoPants()
        {
            Name = "Cargo Pants";
            Description = "Look at all these pockets, you could hide a zoo in here!";
            Weight = 2;
            Value = 250;
            Slots = 8;
        }
    }
}