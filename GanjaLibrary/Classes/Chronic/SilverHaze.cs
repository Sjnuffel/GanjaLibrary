using GanjaLibrary.Enums;
using System.Collections.Generic;

namespace GanjaLibrary.Classes
{
    // Silver Haze is an example of a near 100% Sativa plant.
    public class SilverHaze : Sativa
    {
        public SilverHaze() : base()
        {
            Name = "Silver Haze";
            SeedingAge = 6;
            FloweringAge = randgen.Next(90, 100);

            CBD = 0.05;
            THC = 0.35;

            // Create a dict for changing water need per stage.
            WaterNeed = new Dictionary<Stage, Water>()
            {
                { Stage.Seed, Water.Low },
                { Stage.Clone, Water.Low },
                { Stage.Vegetative, Water.Medium },
                { Stage.Flowering, Water.High},
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