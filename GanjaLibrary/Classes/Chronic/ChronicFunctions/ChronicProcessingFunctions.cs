using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;
using System;

namespace GanjaLibrary.Classes
{
    partial class Chronic
    {
        #region Processing functions
        // What to do when plant grows.
        public IChronic Grow(Water water, Light light, Food food)
        {
            if (Stage == Stage.Vegetative || Stage == Stage.Seed || Stage == Stage.Clone || Stage == Stage.Flowering)
            {
                Age++;
                AdjustHealth(water, light, food);
                AdjustQuality(water, light, food);

                if (Stage != Stage.Seed)
                {
                    AdjustHeight(water, light, food, Stage);
                }

                if (Stage == Stage.Flowering)
                {
                    AdjustYield(water, light, food);
                    AdjustTHC(FloweringAge, 5);
                    AdjustCBD(FloweringAge, 5);
                }

                var isAdvanced = AdvanceStage(light);
            }

            return this;
        }

        // What to do when harvesting the plant.
        public HarvestResult Harvest()
        {
            IChronic harvest = null;
            IChronic trimmings = null;

            if (Stage == Stage.Flowering)
            {
                if (Age >= (FloweringAge - 5) && Age <= FloweringAge + 5)
                {
                    // Check if plant has reached optimal flowering age.
                    if (Age == FloweringAge)
                        Yield *= 1.05;
                    // Check the health of the plant and give bonus accordingly.
                    else if (Health >= 0 && Health <= 50)
                        Yield *= 1.01;
                    else if (Health > 50 && Health <= 90)
                        Yield *= 1.02;
                    else if (Health > 90 && Health <= 100)
                        Yield *= 1.05;
                }

                // Causes a lot of stress for the plant.
                // Also since we cut the plant, set height to 10 cm.                
                Health = 0;
                Age = 0;
                Height = 0;

                trimmings = (IChronic)Clone();
                trimmings.SetStage(Stage.Harvesting);
                // Trimmings has lower THC % compared to the real harvest.
                trimmings.ImproveTHC(0.2);
                // Trimmings has lower CBD % compared to the real harvest.
                trimmings.ImproveCBD(0.2);
                // Trimmings yield is higher, with a far lower THC percentage.
                trimmings.ImproveYield(3);

                // Actually harvest the buds, without yield modifier.
                harvest = (IChronic)Clone();
                // Different stage and height for the harvest.
                harvest.SetStage(Stage.Harvesting);

                // After cloning reduce the yield and trimmings.
                Yield = 0;

                // Cutting does not kill, set to clone stage.
                SetStage(Stage.Clone);
                // The plant that has been cut no longer has a THC or Yield.
                THC = 0;
                CBD = 0;
                // The regrowable clone wasn't destroyed, so add some height.
                Height = 10;
            }

            return new HarvestResult(harvest, trimmings);
        }

        public void SetStage(Stage stage)
        {
            Stage = stage;
        }

        public IChronic Dry()
        {
            if (Stage == Stage.Harvesting || Stage == Stage.Drying)
            {
                SetStage(Stage.Drying);
                Age++;
                AdjustTHC(DryingAge, 2);
                AdjustCBD(DryingAge, 2);
            }
            return this;
        }

        // What to do when curing the plant.
        public IChronic Cure(IContainer container)
        {
            if (Stage == Stage.Curing)
            {
                container.Add(this);
                Age++;
                // Adjust THC/CBD with the optimalAge and variance in mind.
                AdjustTHC(14, 1);
                AdjustCBD(14, 1);
            }
            return this;
        }

        public IChronic Finish()
        {
            if (Stage == Stage.Flowering || Stage == Stage.Curing || Stage == Stage.Drying)
            {
                Stage = Stage.Finished;
                Yield *= 0.55;
            }

            if (CBD > THC)
                Value = (Quality * Yield) * CBD;
            else
                Value = (Quality * Yield) * THC;

            return this;
        }

        // To switch from a drying to curing stage.
        // The real life action means storing it in a mason jar (Wecking).
        public IChronic Weck()
        {
            if (Stage == Stage.Drying)
            {
                Age = 0;
                Stage = Stage.Curing;
            }

            return this;
        }

        #endregion

        #region Plant Biology
        // Adjust plant health if watered, lighted and fed.
        private void AdjustHealth(Water water, Light light, Food food)
        {
            if (Stage == Stage.Dead)
            {
                Health = GameSettings.Default.DeathThreshold;
            }
            else
            {
                if (water == Water && Health <= MaxHealth)
                    Health++;
                else
                    Health--;

                if (light == Light && Health <= MaxHealth)
                    Health++;
                else
                    Health--;

                if (food == Food && food != Food.None && Health <= MaxHealth)
                    Health++;
            }
        }

        // Adjust plant height if watered and lighted.
        private void AdjustHeight(Water water, Light light, Food food, Stage stage)
        {
            // Check if plant is alive and no longer a seed.
            if (stage == Stage.Vegetative || stage == Stage.Flowering || stage == Stage.Clone)
            {
                if (water == Water)
                    Height += 0.75;
                else
                    Height -= 0.75;

                if (light == Light)
                    Height += 0.75;
                else
                    Height -= 0.75;

                // No penalty for lack of food, just bonus growth.
                if (food == Food.Low || food == Food.Medium || food == Food.High)
                    Height++;
            }

            else if (stage == Stage.Dead)
                Height -= 0.75;

            else if (stage == Stage.Seed)
                Height = 0;

            if (Height < 0)
                Height = 0;

        }

        // Quality improvement algorithm.
        private void AdjustQuality(Water water, Light light, Food food)
        {
            // Plant has to be very healthy
            if (Health > 50)
            {
                // Always get some quality improvement.
                if (water == Water && light == Light)
                {
                    Quality *= 1.01;

                    if (food == Food.Low)
                        Quality *= 1.01;

                    else if (food == Food.Medium)
                        Quality *= 1.02;

                    else if (food == Food.High)
                        Quality *= 1.03;
                }
            }
        }

        // How the plant enhances through growth stages.    
        public bool AdvanceStage(Light light)
        {
            var hasAdvanced = false;

            // Die if quality is bad.
            if (Health <= GameSettings.Default.DeathThreshold)
            {
                Stage = Stage.Dead;
                if (Died != null)
                {
                    Died(this, new EventArgs());
                }
                hasAdvanced = true;
            }

            // Advance from seed to vegetative.
            if (Age == SeedingAge && Health >= 0)
            {
                Stage = Stage.Vegetative;
                hasAdvanced = true;
            }

            // Advance if 3 weeks are reached and light requirement is triggered.
            if (Age >= 21 && (light == LightNeed[Stage.Flowering]))
            {
                if (Stage == Stage.Vegetative || Stage == Stage.Clone)
                {
                    hasAdvanced = true;
                    Stage = Stage.Flowering;
                }
            }

            if (hasAdvanced)
            {
                Light = LightNeed[Stage];
                Water = WaterNeed[Stage];
            }

            return hasAdvanced;
        }

        // Adjust the actual yield of the plant.
        private void AdjustYield(Water water, Light light, Food food)
        {
            // If plant is flowering and has not reached flowering age, increase yield.
            if (Yield <= MaxYield && Age >= FloweringAge)
            {
                // Depending on the height, health and resources received adjust yield.
                if (water == Water)
                    Yield++;
                if (light == Light)
                    Yield++;
                if (food == Food)
                    Yield += 2;
                if (Height >= 0 || Height <= 50)
                    Yield += 0.25;
                else if (Height >= 51 || Height <= 100)
                    Yield += 0.5;
                else if (Height >= 101 || Height <= 150)
                    Yield += 0.75;
                else if (Height >= 151 || Height <= 200)
                    Yield += 1;
                if (Health < 0)
                    Yield -= 2;
                else if (Health >= 0 && Health <= 50)
                    Yield += 0.25;
                else if (Health > 50 && Health <= 100)
                    Yield += 0.25;
            }

            // If flowering age has gone by, decrease yield.
            else if (Age > FloweringAge)
            {
                Yield *= 0.95;
            }

            else return;
        }

        // Adjust THC % of the plant.
        private void AdjustTHC(int optimalAge, int variance)
        {
            // Low health decreases THC content.
            if (Health < 0)
                THC -= 0.000025;
            // High health increases THC content.
            if (Health >= 0 && Health <= 50)
                THC += 0.000015;
            if (Health > 50 && Health <= 100)
                THC += 0.000020;
            if (Health > 100)
                THC += 0.000025;

            if (Age == optimalAge)
                THC += 0.000030;
            if (Age >= (optimalAge - variance) && Age >= (optimalAge + variance))
                THC += 0.000015;
        }

        // Adjust CBD % of the plant.
        private void AdjustCBD(int optimalAge, int variance)
        {
            // Low health lowers CBD content.
            if (Health < 0)
                CBD -= 0.00015;
            // High health increases CBD content.
            if (Health >= 0 && Health <= 50)
                CBD += 0.00015;
            if (Health > 50 && Health <= 100)
                CBD += 0.00025;
            if (Health > 100)
                CBD += 0.00035;

            if (Age < (optimalAge - variance))
                CBD -= 0.00015;
            if (Age >= (optimalAge - variance) && Age >= (optimalAge + variance))
                CBD += 0.00025;
            if (Age > optimalAge + variance)
                CBD -= 0.00015;
        }

        #endregion

        // Method to increase or decrease the yield by a percentage.
        public void ImproveYield(double percentage)
        {
            Yield *= percentage;
        }

        // Method to increase or decrease the THC by a percentage.
        public double ImproveTHC(double percentage)
        {
            THC *= percentage;
            return THC;
        }

        // Method to increase or decrease the CBD by a percentage.
        public double ImproveCBD(double percentage)
        {
            CBD *= percentage;
            return CBD;
        }

        // Method to increase or decrease the Quality by a percentage.
        public void ImproveQuality(double percentage)
        {
            Quality *= percentage;
        }
    }
}
