/*
    
    Diethyl ether
    Chemical Compound
    Diethyl ether, also known as ethoxyethane, ethyl ether, sulfuric ether, or simply ether, 
    is an organic compound in the ether class with the formula 2O. It is a colorless,
    highly volatile flammable liquid. Wikipedia
    Density: 713.40 kg/m³
    Formula: (C2H5)2O
    Boiling point: 34.6 °C
    Molar mass: 74.12 g/mol
    Melting point: -116.3 °C
    IUPAC ID: Ethoxyethane
    Classification: Ether
    Flash point −45 °C (−49 °F; 228 K)

    - https://en.wikipedia.org/wiki/Ether

    Ether is used as a chemical to create Honey Oil with.
    This oil is itself is good, giving an 100% boost to yield. 

*/

using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items
{
    public class Ether : Chemical, IItem
    {
        public Ether() : base()
        {
            Name = "Ether";
            Description = "99.9% pure alcohol solution. CAUTION: flammable.";

            Weight = 1;
            Value = 75;
            Flashpoint = -45;
            Contents = 500;

            Flammable = true;
        }
    }
}