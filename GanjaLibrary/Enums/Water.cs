using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanjaLibrary.Enums
{
    public enum Water
    {
        /// <summary>
        /// Open water tap.
        /// </summary>
        Full,
        /// <summary>
        /// Close water tap.
        /// </summary>
        Nothing,
        /// <summary>
        /// Slightly open water tap.
        /// </summary>
        Low,
        /// <summary>
        /// Almost fully open water tap.
        /// </summary>
        High,
        /// <summary>
        /// Halfway open water tap.
        /// </summary>
        Medium
    }
}