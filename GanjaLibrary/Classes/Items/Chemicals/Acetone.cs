/*

    Acetone Boiling point 57 °C (135 °F).
    Easily available as a solvent and degreaser, Acetone evaporates rapidly and it is a popular 
    solvent and is recognized to have low acute and chronic toxicity if ingested and/or inhaled. 
    Acetone has been internationally rated as a GRAS (Generally Recognized as Safe) substance for 
    food use and is produced and disposed of in the human body through normal metabolic processes. 
    The most hazardous property of acetone is its extreme flammability. At temperatures greater 
    than acetone's flash point of -20 °C (-4 °F), air mixtures of between 2.5% and 12.8% acetone, 
    by volume, may explode or cause a flash fire. Vapors can flow along surfaces to distant ignition 
    sources and flash back.

    - See more at: http://www.cannabiscure.info/files/cannabis_oil.htm#sthash.DxdGsIpo.dpuf

*/

using GanjaLibrary.Classes.Items.Chemicals;
using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items
{
    public class Acetone : Chemical, IItem
    {
        public Acetone() : base()
        {
            Name = "Acetone";
            Description = "Most commonly used as a degreaser or as a paint thinner.";

            Weight = 1;
            Value = 15;

            Flashpoint = -20;
            Contents = 500;
            Flammable = true;
        }
    }
}