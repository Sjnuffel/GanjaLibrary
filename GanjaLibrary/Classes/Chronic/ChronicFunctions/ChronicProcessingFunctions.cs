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
                    AdjustCompost(water, light, food, Stage);
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
        public IChronic Harvest()
        {
            IChronic harvest = null;

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
                Height = 10;

                harvest = (IChronic)Clone();

                // After cloning reduce the yield and trimmings.
                Yield = 0;
                Trimmings = 0;

                // Cutting does not kill, set to clone stage.
                Stage = Stage.Clone;

                // Different stage and height for the clone.
                harvest.SetStage(Stage.Drying);
                harvest.Height -= 10;
            }

            return harvest;
        }

        public void SetStage(Stage stage)
        {
            Stage = stage;
        }

        public IChronic Dry()
        {
            if (Stage == Stage.Drying)
            {
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

        public IChronic Filter(IContainer originContainer, IContainer destContainer, IItem filter)
        {
            // Filter the plant remains from the solvent.
            // Depending on the type of solvent and the contents (ie. denatured alcohol) have different effects.
            // Requires filters, two containers for transfer/sifting.
            if (Stage == Stage.Washing)
            {

            }

            else
                Console.WriteLine("There is nothing to filter.");

            return this;
        }

        public IChronic Heat()
        {
            /* 
            Heat away the chemical solvent. Some chemicals can vaporize in open air without heat.
            Might even be a better idea in the first place...
            Requires: ventilation/open air and time or a heat source like a gasburner or stove.
            */
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

        // Adjust plant compost amount. Compost in this sense means bits of the plant you'll have to cut off.
        private void AdjustCompost(Water water, Light light, Food food, Stage stage)
        {
            if (stage == Stage.Vegetative || stage == Stage.Flowering || stage == Stage.Seed || stage == Stage.Clone)
            {
                if (water == Water)
                    Trimmings += 1.5;
                else
                    Trimmings -= 1.5;

                if (light == Light)
                    Trimmings += 1.5;
                else
                    Trimmings -= 1.5;

                if (food == Food)
                    Trimmings += 1.5;
                else
                    Trimmings -= 1.5;

                if (stage == Stage.Dead)
                    Trimmings -= 2;

                if (Trimmings < 0)
                    Trimmings = 0;
            }
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
            if (Health > 0)
                THC += 0.000025;

            if (Age < (optimalAge - variance))
                THC -= 0.000015;
            if (Age >= (optimalAge - variance) && Age >= (optimalAge + variance))
                THC += 0.000015;
            if (Age > optimalAge + variance)
                THC -= 0.000015;
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
    }
}
