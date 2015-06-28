using GanjaLibrary.Enums;
using System.Collections.Generic;

namespace GanjaLibrary.Classes
{
    public class Ruderalis : Chronic
    {
        public Ruderalis() : base("Ruderalis", Water.Low, Light.Yolo, Food.None) {
            CBD = 0.30;
            THC = 0.05;

            WaterNeed = new Dictionary<Stage, Water>()
            {
                { Stage.Seed, Water.Low },
                { Stage.Clone, Water.Low },
                { Stage.Vegetative, Water.Low },
                { Stage.Flowering, Water.High },
                { Stage.Dead, Water.Nothing },
            };

            LightNeed = new Dictionary<Stage, Light>()
            {
                { Stage.Seed, Light.Off },
                { Stage.Clone, Light.Yolo },
                { Stage.Vegetative, Light.Yolo },
                { Stage.Flowering, Light.Yolo },
                { Stage.Dead, Light.Off },
            };

            Light = LightNeed[Stage.Seed];
            Water = WaterNeed[Stage.Seed];
        }
    }
}