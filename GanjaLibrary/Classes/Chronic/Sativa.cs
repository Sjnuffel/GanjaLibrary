﻿using GanjaLibrary.Enums;
using System;
using System.Collections.Generic;

namespace GanjaLibrary.Classes
{
    public abstract class Sativa : Chronic
    {
        public Sativa() : base("Sativa", Water.Low, Light.Spring, Food.None)
        {
            Name = "Sativa";
            CBD = 0.05;
            THC = 0.25;
            
            // Create a dict for changing water need per stage.
            WaterNeed = new Dictionary<Stage, Water>()
            {
                { Stage.Seed, Water.Low },
                { Stage.Clone, Water.Low },
                { Stage.Vegetative, Water.Low },
                { Stage.Flowering, Water.High },
                { Stage.Dead, Water.None },
            };

            // Create a dict for changing light need per stage.
            LightNeed = new Dictionary<Stage, Light>()
            {
                { Stage.Seed, Light.None },
                { Stage.Clone, Light.Spring },
                { Stage.Vegetative, Light.Spring },
                { Stage.Flowering, Light.Summer },
                { Stage.Dead, Light.None },
            };

            Light = LightNeed[Stage.Seed];
            Water = WaterNeed[Stage.Seed];
        }

        protected Sativa(Sativa other) : base(other) { }
    }
}