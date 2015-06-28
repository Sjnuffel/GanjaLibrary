using GanjaLibrary.Enums;
using System.Collections.Generic;

namespace GanjaLibrary.Classes
{
    public class Sativa : Chronic
    {
        public Sativa() : base("Sativa", Water.Low, Light.Spring, Food.None) {
            CBD = 0.05;
            THC = 0.25;

            // Create a dict for changing water need per stage.
            WaterNeed = new Dictionary<Stage, Water>()
            {
                { Stage.Seed, Water.Low },
                { Stage.Clone, Water.Low },
                { Stage.Vegetative, Water.Low },
                { Stage.Flowering, Water.High },
                { Stage.Dead, Water.Nothing },
            };

            // Create a dict for changing light need per stage.
            LightNeed = new Dictionary<Stage, Light>()
            {
                { Stage.Seed, Light.Off },
                { Stage.Clone, Light.Spring },
                { Stage.Vegetative, Light.Spring },
                { Stage.Flowering, Light.Summer },
                { Stage.Dead, Light.Off },
            };

            Light = LightNeed[Stage.Seed];
            Water = WaterNeed[Stage.Seed];
        }
    }
}