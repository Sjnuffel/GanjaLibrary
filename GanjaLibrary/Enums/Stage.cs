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
        Dead
    }
}