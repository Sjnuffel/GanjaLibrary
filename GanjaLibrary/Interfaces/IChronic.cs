using GanjaLibrary.Enums;
using System;
using System.Collections.Generic;

namespace GanjaLibrary.Interfaces
{
    public interface IChronic
    {
        /// <summary>
        /// Event for death.
        /// </summary>
        event EventHandler Died;

        /// <summary>
        /// Height category in the plant
        /// </summary>
        Height Height { get; }
        /// <summary>
        /// Max yield a plant can get in grams.
        /// </summary>
        double MaxYield { get; }
        /// <summary>
        /// Quality of a plant (can be improved through good care).
        /// </summary>
        double Quality { get; }
        /// <summary>
        /// Age of the plant in days.
        /// </summary>
        int Age { get; }
        /// <summary>
        /// Time the plant should be ready for harvest in days.
        /// </summary>
        int FloweringAge { get; }
        /// <summary>
        /// Stage the plant is in.
        /// </summary>
        Stage Stage { get; }
        /// <summary>
        /// Day to Day health of the plant (%).
        /// </summary>
        double Health { get; }
        /// <summary>
        /// Amount of THC in the plant (% of yield).
        /// </summary>
        double THC { get; }
        /// <summary>
        /// Amount of CBD in the plant (% of yield).
        /// </summary>
        double CBD { get; }
        /// <summary>
        /// Actual yield of the plant in grams.
        /// </summary>
        double Yield { get; }
        /// <summary>
        /// Light need of a plant in specific season.
        /// </summary>
        Light Light { get; }
        /// <summary>
        /// Amount of water the plant receives.
        /// </summary>
        Water Water { get; }
        /// <summary>
        /// Amount of the food the plant receives.
        /// </summary>
        Food Food { get; }
        /// <summary>
        /// Name of the plant.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Actual height of plant in centimeters (start at 0)
        /// </summary>
        double ActualHeight { get; }

        Dictionary<Stage, Water> WaterNeed { get; }
        Dictionary<Stage, Light> LightNeed { get; }

        /// <summary>
        /// Grow the plant.
        /// </summary>
        IChronic Grow(Water water, Light light, Food food );
        /// <summary>
        /// Print.
        /// </summary>
        void Print();
        /// <summary>
        /// Harvest the plant.
        /// </summary>
        IChronic Harvest();
    }
}