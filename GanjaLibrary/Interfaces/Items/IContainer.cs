using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanjaLibrary.Interfaces.Items
{
    public interface IContainer
    {
        /// <summary>
        /// A list of containers.
        /// </summary>
        List<IItem> Items { get; }

        /// <summary>
        /// Amount of slots in the container.
        /// </summary>
        int Slots { get; }
        
        /// <summary>
        /// Amount of items currently in container.
        /// </summary>
        int ItemAmount { get; }

        /// <summary>
        /// Add an item.
        /// </summary>
        bool Add(IItem item);

        /// <summary>
        /// Remove an item.
        /// </summary>
        bool Remove(IItem item);

        /// <summary>
        /// Check inside the container if it contains an item.
        /// </summary>
        bool Contains(IItem item);
    }
}