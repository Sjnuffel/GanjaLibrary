using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Items;
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
        /// Day the seed is expected to flower.
        /// </summary>
        int SeedingAge { get; }

        /// <summary>
        /// Max health cap (200)
        /// </summary>
        int MaxHealth { get; }

        /// <summary>
        /// Ideal drying age/time of the plant.
        /// </summary>
        int DryingAge { get; }

        /// <summary>
        /// Age of the plant in days.
        /// </summary>
        int Age { get; }

        /// <summary>
        /// Time the plant should be ready for harvest in days.
        /// </summary>
        int FloweringAge { get; }

        /// <summary>
        /// Height category of the plant
        /// </summary>
        double Height { get; set; }

        /// <summary>
        /// Max yield a plant can get in grams.
        /// </summary>
        double MaxYield { get; }

        /// <summary>
        /// Actual quality of the plant during growth.
        /// </summary>
        double Quality { get; set; }

        /// <summary>
        /// The non-useful plant bits that are generated.
        /// </summary>
        double Trimmings { get; }

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
        /// Yield of the plant in grams, during growth.
        /// </summary>
        double Yield { get; set; }

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
        /// Stage the plant is in.
        /// </summary>
        Stage Stage { get;  }

        /// <summary>
        /// Name of the plant.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Dictionary containing water requirements.
        /// </summary>
        Dictionary<Stage, Water> WaterNeed { get; }

        /// <summary>
        /// Dictionary containing plants light requirements.
        /// </summary>
        Dictionary<Stage, Light> LightNeed { get; }

        /// <summary>
        /// Grow the plant.
        /// </summary>
        IChronic Grow(Water water, Light light, Food food );

        /// <summary>
        /// Harvest the plant.
        /// </summary>
        IChronic Harvest();

        /// <summary>
        /// Dry the plant.
        /// </summary>
        IChronic Dry();

        /// <summary>
        /// Actual curing process.
        /// </summary>
        IChronic Cure(IContainer container);

        /// <summary>
        /// Final steps before plant is ready for sale.
        /// </summary>
        IChronic Finish();

        /// <summary>
        /// Cure the plant (in a weck jar).
        /// </summary>
        IChronic Weck();

        /// <summary>
        /// Set the stage Chronic is in.
        /// </summary>
        /// <param name="stage"></param>
        void SetStage(Stage stage);

        /// <summary>
        /// Print.
        /// </summary>
        void Print();

        /// <summary>
        /// Clone the class.
        /// </summary>
        IChronic Clone();
    }
}