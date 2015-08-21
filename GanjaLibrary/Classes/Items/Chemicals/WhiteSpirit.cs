/*

    White spirit (UK)[note 1] or mineral spirits (US),[1][2][3] also known as mineral turpentine, 
    turpentine substitute, petroleum spirits, solvent naphtha (petroleum), varsol, Stoddard 
    solvent,[4][5] or, generically, "paint thinner", is a petroleum-derived clear, transparent 
    liquid used as a common organic solvent in painting and decorating.

    White Spirit is a petroleum distillate used as a paint thinner and mild solvent. In industry, 
    mineral spirits are used for cleaning and degreasing machine tools and parts, and in 
    conjunction with cutting oil as a thread cutting and reaming lubricant.

    Initial boiling point (IBP) (°C)	130–144
    Flash point (°C)	21–30	31–54	> 55

    - https://en.wikipedia.org/wiki/White_spirit

    WhiteSpirit or Turpentine can be used as a chemical to create Honey Oil with.
    Pretty decent alcohol for it's cheapness. Provides 90% bonus to yield.

*/
using GanjaLibrary.Classes.Items.Chemicals;
using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Items
{
    public class WhiteSpirit : Chemical, IItem
    {
        public WhiteSpirit() : base()
        {
            Name = "Turpentine";
            Description = "Primarily used as a paint thinner or as varnish.";

            Weight = 1;
            Value = 15;
            Flashpoint = 20;
            Contents = 500;

            Flammable = true;
        }
    }
}