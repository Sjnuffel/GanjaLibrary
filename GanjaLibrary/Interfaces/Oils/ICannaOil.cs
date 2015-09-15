using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanjaLibrary
{
    public interface ICannaOil
    {
        /// <summary>
        /// Calculate the value of the oil
        /// </summary>
        ICannaOil CalculatePrice();
    }
}