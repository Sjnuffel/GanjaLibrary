/*
    Stroh is a distilled from a secret blend of herbs and fruit to hefty strength of 80% alcohol. If you were lost 
    in the snow and a St. Bernard brought you a cup of this, you would be pretty happy.

    Stroh Rum can be used as a chemical to create Honey Oil with.
    This isn't proper alcohol, will leave a taste that might not be acceptable. Gives a 70% bonus to yield.
*/

using GanjaLibrary.Classes.Items.Chemicals;
using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items
{
    public class Strohrum : Chemical, IItem
    {
        public Strohrum() : base()
        {
            Name = "Stroh Rum 80%";
            Description = "Quality alcoholic beverage.";

            Weight = 1;
            Value = 35;

            Flashpoint = 350;
            Contents = 500;
            Flammable = true;

        }
    }
}