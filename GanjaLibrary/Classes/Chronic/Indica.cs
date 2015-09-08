using GanjaLibrary.Enums;
using System;
using System.Collections.Generic;

namespace GanjaLibrary.Classes
{
    public abstract class Indica : Chronic
    {
        public Indica() : base("Indica", Water.Low, Light.Spring, Food.None)
        {
            CBD = 0.25;
            THC = 0.20;

            // Create a dict for changing water need per stage.
            WaterNeed = new Dictionary<Stage, Water>()
            {
                { Stage.Seed, Water.Low },
                { Stage.Clone, Water.Low },
                { Stage.Vegetative, Water.Low },
                { Stage.Flowering, Water.Medium },
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

        protected Indica(Indica other) : base(other) { }
    }
}