/*

    BHO: Butane Honey Oil

    This is extracted using butane gas. Butane has a low boiling point of 0.5 °C (31.1 °F) and 
    using butane is very dangerous and it must always be performed outdoors. There have been 
    many instances of fires caused by people using butane as an extraction solvent and some fire 
    departments in the U.S. have gone so far as to issue warnings against its use. There are many 
    companies who sell ready made Butane gas extraction kits and they are readily available online. 
    The best advice we can give is to not attempt this extraction process, if you decide to do 
    so then wear protective clothing and always carry out the procedure outdoors away from 
    any flame source.

    Butane, Boiling point   -1 °C
    Flash point	−60 °C (−76 °F; 213 K)

    - See more at: http://www.cannabiscure.info/files/cannabis_oil.htm#sthash.6IioCYdZ.dpuf

    This type of alcohol is decent enough, will give you an 80% boost to yield.
*/

using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items
{
    public class Butane : Chemical, IItem
    {
        public Butane() :base()
        {
            Name = "Butane";
            Description = "Commonly known as lighter fluid.";

            Weight = 1;
            Value = 15;

            Flashpoint = -60;
            Contents = 500;
            Flammable = true;
        }
    }
}