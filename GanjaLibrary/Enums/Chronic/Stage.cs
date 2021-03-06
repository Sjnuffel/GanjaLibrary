﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GanjaLibrary.Enums
{
    public enum Stage
    {
        /// <summary>
        /// Plant in it's seedling stage (unwatered)
        /// </summary>
        Seed,
        /// <summary>
        /// Plant as a clone of a motherplant
        /// </summary>
        Clone,
        /// <summary>
        /// Plant in it's spring stage
        /// </summary>
        Vegetative,
        /// <summary>
        /// Plant in it's summer stage
        /// </summary>
        Flowering,
        /// <summary>
        /// You killed it
        /// </summary>
        Dead,
        /// <summary>
        /// Dried plant.
        /// </summary>
        Drying,
        /// <summary>
        /// Curing plant.
        /// </summary>
        Curing,
        /// <summary>
        /// All done.
        /// </summary>
        Finished,
        /// <summary>
        /// Washing the Weed with the selected Chemical
        /// </summary>
        Washing,
        /// <summary>
        /// Filter the weed remains from the solvent.
        /// </summary>
        Filtering,
        /// <summary>
        /// Heating off the remaining solvent.
        /// </summary>
        Heating,
        /// <summary>
        /// Harvesting off the remaining solvent.
        /// </summary>
        Harvesting
    }
}