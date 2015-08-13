using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanjaLibrary.Interfaces.Items
{
    public interface IItem
    {
        /// <summary>
        /// Unique identifier of an item (GUID).
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Name of the item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A description of the item.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Weight of the item (in grams).
        /// </summary>
        double Weight { get; }

        /// <summary>
        /// Value of the item (in euros).
        /// </summary>
        double Value { get; }
    }
}
