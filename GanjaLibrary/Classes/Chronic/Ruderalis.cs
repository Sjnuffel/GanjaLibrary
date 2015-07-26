using GanjaLibrary.Enums;
using System.Collections.Generic;

namespace GanjaLibrary.Classes
{
    public class Ruderalis : Chronic
    {
        public Ruderalis() : base("Ruderalis", Water.Low, Light.Yolo, Food.None) {
            CBD = 0.30;
            THC = 0.05;
            SeedingAge = 3;

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
                { Stage.Clone, Light.Yolo },
                { Stage.Vegetative, Light.Yolo },
                { Stage.Flowering, Light.Yolo },
                { Stage.Dead, Light.None },
            };

            Light = LightNeed[Stage.Seed];
            Water = WaterNeed[Stage.Seed];
        }
    }
}