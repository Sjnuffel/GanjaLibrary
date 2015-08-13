
/*
    
    Isopropyl alcohol (IUPAC name 2-propanol, also commonly know as isopropanol) is a chemical 
    compound with the molecular formula C3H8O or C3H7OH or CH3CHOHCH3. It is a colorless, 
    flammable chemical compound with a strong odor. It is the simplest example of a secondary 
    alcohol, where the alcohol carbon atom is attached to two other carbon atoms sometimes 
    shown as (CH3)2CHOH. It is a structural isomer of propanol. It has a wide variety of uses, 
    typically as a solvent for coatings or for industrial processes; it is also consumed for 
    household use (rubbing alcohol) and in personal care products. Following poisoning in humans it 
    mainly acts as a central nervous system (CNS) depressant.[5]

    - https://en.wikipedia.org/wiki/Isopropyl_alcohol

    Isopropanol is used as a chemical to create Honey Oil with. Using this is the so called "Quick-Wash" method.
    This type of alcohol is very good, will give you an 110% boost to yield.
*/

using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items
{
    public class Isopropanol : Item, IItem
    {
        public Isopropanol() : base("Isopropanol 99%", 
            "High purity Isopropyl Alcohol, 99.9%. CAUTION: take care of ventilation when using product. Contains 1000 ml.", 
            1, 75)
        {
        }
    }
}