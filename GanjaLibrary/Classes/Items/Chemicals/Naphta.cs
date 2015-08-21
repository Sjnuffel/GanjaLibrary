/*

    Naptha (boiling point between 30 °C and 200 °C).

    Naptha is extremely volatile and can explode on exposure to high temperature so great 
    care must be taken when it is used. Naptha is recommended by Rick Simpson, however 
    there are concerns expressed by some that naphtha can be carcinogenic. 
    Some commonly available forms of Naptha contain impurities which may also have harmful properties of their own.

    - See more at: http://www.cannabiscure.info/files/cannabis_oil.htm#sthash.DxdGsIpo.dpuf

    Works well with extracting THC/CBD from plants, sadly there is a (high) risk of it being denatured. 
*/

using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items
{
    public class Naphta : Chemical, IItem
    {
        public Naphta() :base()
        {
            Name = "Naphta";
            Description = "";

            Weight = 2;
            Value = 12;
            Flashpoint = 350;
            Contents = 1000;

            Flammable = true;
            Denatured = true;
        }
    }
}
