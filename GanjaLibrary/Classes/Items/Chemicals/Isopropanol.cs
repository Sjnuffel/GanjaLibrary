
/*
    
    Isopropyl alcohol (IUPAC name 2-propanol, also commonly know as isopropanol) is a chemical 
    compound with the molecular formula C3H8O or C3H7OH or CH3CHOHCH3. It is a colorless, 
    flammable chemical compound with a strong odor. It is the simplest example of a secondary 
    alcohol, where the alcohol carbon atom is attached to two other carbon atoms sometimes 
    shown as (CH3)2CHOH. It is a structural isomer of propanol. It has a wide variety of uses, 
    typically as a solvent for coatings or for industrial processes; it is also consumed for 
    household use (rubbing alcohol) and in personal care products. Following poisoning in humans it 
    mainly acts as a central nervous system (CNS) depressant.[5]

    Boiling point	82.6 °C (180.7 °F; 355.8 K)
    Flash point	Open cup: 11.7 °C (53.1 °F; 284.8 K)
    Closed cup: 13 °C (55 °F)

    - https://en.wikipedia.org/wiki/Isopropyl_alcohol

    Isopropanol is used as a chemical to create Honey Oil with. Using this is the so called "Quick-Wash" method.
    This type of alcohol is very good, will give you an 110% boost to yield.
*/

using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Classes.Items.Chemicals;

namespace GanjaLibrary.Classes.Items
{
    public class Isopropanol : Chemical, IItem
    {
        public Isopropanol() : base()
        {
            Name = "Isopropanol 99%";
            Description = "High purity Isopropyl Alcohol, 99.9%. CAUTION: flammable.";

            Weight = 1;
            Value = 85;
            Flashpoint = 11.7;
            Contents = 1000;

            Flammable = true;
        }
    }
}