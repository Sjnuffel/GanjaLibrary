/*

    Everclear was taken as an example:

    Everclear grain alcohol, is the brand name of a colorless, unflavored, distilled 
    beverage sold in some states in the U.S. and bottled at two different high 
    strengths: 151-proof and 190-proof, meaning respectively 75.5% and 95% alcohol 
    by volume, 190-proof spirits are the strongest that are available and they are ideal 
    for this basic method of making cannabis oil. It is illegal to sell 190-proof 
    Everclear in California, Florida, Hawaii, Iowa, Maine, Massachusetts, Minnesota, 
    Nevada, New Hampshire, North Carolina and Virginia. It can be purchased in Ohio 
    but only under severe restrictions. In Canada, Everclear is sold in the province 
    of Alberta but not in other provinces. In British Columbia, it is available for 
    purchase only with a permit for medical, research, or industrial use. Everclear 
    is difficult to obtain in the E.U, it is however possible to distill your own solvent. 
    
    - See more at: http://www.cannabiscure.info/files/cannabis_oil.htm#sthash.6IioCYdZ.dpuf

*/

using GanjaLibrary.Classes.Items.Chemicals;
using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items.Chemicals
{
    class GrainAlcohol : Chemical, IItem
    {
        public GrainAlcohol() :base()
        {
            Name = "Grain Alocohol";
            Description = "Good to get drunk on, 80% alcohol.";

            Weight = 2;
            Value = 120;
            Flashpoint = 350;
            Contents = 1000;

            Flammable = true;
        }
    }

}
