using Microsoft.VisualStudio.TestTools.UnitTesting;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Classes.Items.Storage;

namespace GanjaLibrary.Classes.Tests
{
    [TestClass()]
    public class ChronicCultivationTests
    {
        [TestMethod()]
        public void ChronicCultivation_SilverHazePerfectGrowth_HealthySilverHaze()
        {
            IChronic GanjaTest = new SilverHaze();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.Low);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            Assert.IsTrue(GanjaTest.Stage == Stage.Flowering);
            Assert.IsTrue(GanjaTest.Health > 90);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushPerfectGrowth_HealthyMasterKush()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 25; i++)
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);

            Assert.IsTrue(GanjaTest.Stage == Stage.Flowering);
            Assert.IsTrue(GanjaTest.Health > 90);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushKillSeed_DeadMasterKushSeed()
        {
            IChronic GanjaTest = new MasterKush();
            // For test to succeed it needed extra days in Seeding stage.
            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void ChronicCultivation_SilverHazeKillSeed_DeadSilverHazeSeed()
        {
            IChronic GanjaTest = new SilverHaze();
            // For test to succeed it needed extra days in Seeding stage.
            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushKillVegatative_DeadMasterKushVegatative()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);
            
            // For test to succeed it needed extra days in Vegatative state.
            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void ChronicCultivation_SilverHazeKillVegatative_DeadSilverHazeVegatative()
        {
            IChronic GanjaTest = new SilverHaze();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            // For test to succeed it needed extra days in Vegatative state.
            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushKillFlowering_DeadMasterKushFlowering()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            // For test to succeed it needed extra days in Vegatative state.
            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 70; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void ChronicCultivation_SilverHazeKillFlowering_DeadSilverHazeFlowering()
        {
            IChronic GanjaTest = new SilverHaze();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            // For test to succeed it needed extra days in Vegatative state.
            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 70; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushNegativeHeightWhenDead_HeightIsZero()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            for (int i = 0; i < 10; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Height >= 0);
        }

        [TestMethod()]
        public void ChronicCultivation_SilverHazeNegativeHeightWhenDead_HeightIsZero()
        {
            IChronic GanjaTest = new SilverHaze();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            for (int i = 0; i < 10; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Height >= 0);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushFreezeAgeWhenDead_AgeIsThirteen()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.None, Light.Spring, Food.None);

            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            for (int i = 0; i < 10; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Age == 13);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushHealthIncreaseWhenDead_HealthLessOrEqualThan25()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.None, Light.Spring, Food.None);

            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            for (int i = 0; i < 10; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Health <= -25);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushHarvest_MasterKushHarvestingStage()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);

            var HarvestTest = GanjaTest.Harvest().Harvest;
            Assert.IsTrue(HarvestTest.Stage == Stage.Harvesting);
        }

        [TestMethod()]
        public void ChronicCultivation_SilverHazeHarvest_SilverHazeHarvestingstage()
        {
            IChronic GanjaTest = new SilverHaze();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.Low);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            var HarvestTest = GanjaTest.Harvest().Harvest;
            Assert.IsTrue(HarvestTest.Stage == Stage.Harvesting);
        }

        [TestMethod()]
        public void ChronicCultivation_SilverHazetoAddTest_TrimmingsDeadStageYieldZero()
        {
            IChronic GanjaTest = new SilverHaze();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.Low);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            var fullHarvest = GanjaTest.Harvest();
            var clone = GanjaTest;
            var harvest = fullHarvest.Harvest;
            var trimmings = fullHarvest.Trimmings;
            for (int i = 0; i < harvest.DryingAge; i++)
            {
                harvest.Dry();
                trimmings.Dry();
            }

            harvest.Add(ref trimmings);
            Assert.IsTrue(trimmings.Stage == Stage.Dead);
            Assert.IsTrue(trimmings.Yield == 0);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushtoAddTest_TrimmingsDeadStageYieldZero()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.Low);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            var fullHarvest = GanjaTest.Harvest();
            var clone = GanjaTest;
            var harvest = fullHarvest.Harvest;
            var trimmings = fullHarvest.Trimmings;
            for (int i = 0; i < harvest.DryingAge; i++)
            {
                harvest.Dry();
                trimmings.Dry();
            }

            harvest.Add(ref trimmings);
            Assert.IsTrue(trimmings.Stage == Stage.Dead);
            Assert.IsTrue(trimmings.Yield == 0);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushDry_MasterKushDryingStage()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);

            var DryTestResult = GanjaTest.Harvest().Harvest;

            for (int i = 0; i < DryTestResult.DryingAge; i++)
                DryTestResult.Dry();
            
            Assert.IsTrue(DryTestResult.Stage == Stage.Drying);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushCure_MasterKushCuringStage()
        {
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);

            var CureTestResult = GanjaTest.Harvest().Harvest;

            for (int i = 0; i < CureTestResult.DryingAge; i++)
                CureTestResult.Dry();

            CureTestResult.Weck();
            for (int i = 0; i < 14; i++)
                CureTestResult.Cure(MasonJar);

            Assert.IsTrue(CureTestResult.Stage == Stage.Curing);
        }

        [TestMethod()]
        public void ChronicCultivation_SilverHazeCure_SilverHazeCuringStage()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.Low);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            var CureTestResult = GanjaTest.Harvest().Harvest;

            for (int i = 0; i < CureTestResult.DryingAge; i++)
                CureTestResult.Dry();

            CureTestResult.Weck();
            for (int i = 0; i < 14; i++)
                CureTestResult.Cure(MasonJar);

            Assert.IsTrue(CureTestResult.Stage == Stage.Curing);
        }
      
        [TestMethod()]
        public void ChronicCultivation_MasterKushFinishForSale_MasterKushFinishedStage()
        {
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);

            var CureTestResult = GanjaTest.Harvest().Harvest;

            for (int i = 0; i < CureTestResult.DryingAge; i++)
                CureTestResult.Dry();

            CureTestResult.Weck();
            for (int i = 0; i < 14; i++)
                CureTestResult.Cure(MasonJar);

            CureTestResult.Finish();
            Assert.IsTrue(CureTestResult.Stage == Stage.Finished);
        }

        [TestMethod()]
        public void ChronicCultivation_SilverHazeFinishForSale_SilverHazeFinishedStage()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.Low);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            var CureTestResult = GanjaTest.Harvest().Harvest;

            for (int i = 0; i < CureTestResult.DryingAge; i++)
                CureTestResult.Dry();

            CureTestResult.Weck();
            for (int i = 0; i < 14; i++)
                CureTestResult.Cure(MasonJar);

            CureTestResult.Finish();
            Assert.IsTrue(CureTestResult.Stage == Stage.Finished);
        }

        [TestMethod()]
        public void ChronicCultivation_SilverHazeHarvestValue_IsNotNull()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            var fullHarvest = GanjaTest.Harvest();
            var clone = GanjaTest;
            var harvest = fullHarvest.Harvest;
            var trimmings = fullHarvest.Trimmings;
            for (int i = 0; i < harvest.DryingAge; i++)
                harvest.Dry();

            for (int i = 0; i < trimmings.DryingAge; i++)
                trimmings.Dry();

            harvest.Finish();

            Assert.IsTrue(harvest.Value != 0);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushHarvestValue_IsNotNull()
        {
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 25; i++)
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);

            var fullHarvest = GanjaTest.Harvest();
            var clone = GanjaTest;
            var harvest = fullHarvest.Harvest;
            var trimmings = fullHarvest.Trimmings;
            for (int i = 0; i < harvest.DryingAge; i++)
                harvest.Dry();

            for (int i = 0; i < trimmings.DryingAge; i++)
                trimmings.Dry();

            harvest.Finish();

            Assert.IsTrue(harvest.Value != 0);
        }

        [TestMethod()]
        public void ChronicCultivation_MasterKushHarvestHeight_IsEqualToYield()
        {
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 25; i++)
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);

            var fullHarvest = GanjaTest.Harvest();
            var clone = GanjaTest;
            var harvest = fullHarvest.Harvest;
            var trimmings = fullHarvest.Trimmings;
            for (int i = 0; i < harvest.DryingAge; i++)
                harvest.Dry();

            for (int i = 0; i < trimmings.DryingAge; i++)
                trimmings.Dry();

            Assert.IsTrue(harvest.Height == 0);
        }

        [TestMethod()]
        public void ChronicCultivation_SilverHazeHarvestHeight_IsEqualToYield()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            var fullHarvest = GanjaTest.Harvest();
            var clone = GanjaTest;
            var harvest = fullHarvest.Harvest;
            var trimmings = fullHarvest.Trimmings;
            for (int i = 0; i < harvest.DryingAge; i++)
                harvest.Dry();

            for (int i = 0; i < trimmings.DryingAge; i++)
                trimmings.Dry();

            Assert.IsTrue(harvest.Height == 0);
        }


    }
}