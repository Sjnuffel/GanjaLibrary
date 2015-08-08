using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items
{
    public class Butane : Item, IItem
    {
        public Butane() :base("Butane", "Commonly known as lighter fluid, 500 ml.", 1, 25)
        {
        }
    }
}