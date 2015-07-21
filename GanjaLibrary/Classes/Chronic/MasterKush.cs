using GanjaLibrary.Enums;
using System.Collections.Generic;

namespace GanjaLibrary.Classes
{
    // Master Kush is an example of an almost 100% Indica plant.
    public class MasterKush : Indica
    {
        public MasterKush() : base()
        {
            Name = "Master Kush";
            SeedingAge = 4;
            FloweringAge = randgen.Next(50, 65);

            CBD = 0.25;
            THC = 0.30;

            // Create a dict for changing water need per stage.
            WaterNeed = new Dictionary<Stage, Water>()
            {
                { Stage.Seed, Water.Low },
                { Stage.Clone, Water.Low },
                { Stage.Vegetative, Water.Low },
                { Stage.Flowering, Water.Medium },
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