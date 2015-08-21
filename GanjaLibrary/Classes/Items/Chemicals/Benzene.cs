/*
    Boiling point 80.1 °C (176.2 °F; 353.2 K) 

    Benzene is an important organic chemical compound with the chemical formula C6H6. Its molecule is 
    composed of 6 carbon atoms joined in a ring, with 1 hydrogen atom attached to each carbon atom. 
    Because its molecules contain only carbon and hydrogen atoms, benzene is classed as a hydrocarbon.

    Benzene is a natural constituent of crude oil, and is one of the most elementary petrochemicals. 
    Benzene is an aromatic hydrocarbon and the second [n]-annulene ([6]-annulene), a cyclic hydrocarbon 
    with a continuous pi bond. It is sometimes abbreviated Ph–H. Benzene is a colorless and highly 
    flammable liquid with a sweet smell. It is mainly used as a precursor to heavy chemicals, such 
    as ethylbenzene and cumene, which are produced on a billion kilogram scale. Because it has a high 
    octane number, it is an important component of gasoline, comprising a few percent of its mass. 
    Most non-industrial applications have been limited by benzene's carcinogenicity.

    Flash point (PMCC)	°C	-11.1

    - https://en.wikipedia.org/wiki/Benzene

*/


using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items
{
    public class Benzene : Chemical, IItem
    {
        public Benzene() :base()
        {
            Name = "Benzene";
            Description = "Can be used to remove stains from clothing.";

            Weight = 1;
            Value = 25;

            Flashpoint = -11.1;
            Contents = 500;
            Flammable = true;
        }
    }
}