using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanjaLibrary.Enums
{
    public enum ItemType
    {
        /// <summary>
        /// Base Item class Type.
        /// </summary>
        BaseItem,
        /// <summary>
        /// Chemical type.
        /// </summary>
        Chemical,
        /// <summary>
        /// Plant type.
        /// </summary>
        Plant,
        /// <summary>
        /// Filter type.
        /// </summary>
        Filter,
        /// <summary>
        /// SolventMix type (=Weedleaves + Chemical)
        /// </summary>
        SolventMix,
        /// <summary>
        /// Solvent type (=THC + Chemical)
        /// </summary>
        Solvent,
        /// <summary>
        /// Cannabis oil type.
        /// </summary>
        CannaOil
    }
}