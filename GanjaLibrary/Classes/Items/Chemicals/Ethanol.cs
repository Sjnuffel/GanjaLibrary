/*

    Isopropyl alcohol dissolves a wide range of non-polar compounds. It also evaporates quickly, 
    leaves nearly zero oil traces, compared to ethanol, and is relatively non-toxic, compared to 
    alternative solvents. Thus, it is used widely as a solvent and as a cleaning fluid, especially 
    for dissolving oils. Together with ethanol, n-butanol, and methanol, it belongs to the group 
    of alcohol solvents, about 6.4 million tonnes of which were utilized worldwide in 2011.[15]

    - https://en.wikipedia.org/wiki/Isopropyl_alcohol

    Isopropanol is used as a chemical to create Honey Oil with.
    This oil is itself is good, giving an 90% boost to yield. 

    Boiling point	82.6 °C (180.7 °F; 355.8 K)
    Ethyl Alcohol, Ethanol	63°C

    HOWEVER: denatured alcohol is poisonous to humans. Customers will probably not like you for it. 
    Cheaper though.

*/

using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items
{
    public class Ethanol : Chemical, IItem
    {
        public Ethanol() : base()
        {
            Name = "Ethanol";
            Description = "Denatured alcoholic solution. Contains traces of methanol.";

            Weight = 1;
            Value = 15;
            Flashpoint = 63;
            Contents = 500;

            Flammable = true;
            Denatured = true;
        }
    }
}