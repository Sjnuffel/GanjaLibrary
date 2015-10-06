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
        public void ChronicCultivation_GrowPerfectSilverHaze_HealthySilverHaze()
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
        public void ChronicCultivation_GrowPerfectMasterKush_HealthyMasterKush()
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
        public void ChronicCultivation_KillMasterKushSeed_DeadMasterKushSeed()
        {
            IChronic GanjaTest = new MasterKush();
            // For test to succeed it needed extra days in Seeding stage.
            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void ChronicCultivation_KillSilverHazeSeed_DeadSilverHazeSeed()
        {
            IChronic GanjaTest = new SilverHaze();
            // For test to succeed it needed extra days in Seeding stage.
            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.None, Light.None, Food.None);

            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void ChronicCultivation_KillMasterKushVegatative_DeadMasterKushVegatative()
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
        public void ChronicCultivation_KillSilverHazeVegatative_DeadSilverHazeVegatative()
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
        public void ChronicCultivation_KillMasterKushFlowering_DeadMasterKushFlowering()
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
        public void ChronicCultivation_KillSilverHazeFlowering_DeadSilverHazeFlowering()
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
        public void ChronicCultivation_NegativeMasterKushHeightWhenDead_HeightIsZero()
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
        public void ChronicCultivation_NegativeSilverHazeHeightWhenDead_HeightIsZero()
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
        public void ChronicCultivation_FreezeAgeWhenDead_AgeIsThirteen()
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
        public void ChronicCultivation_HealthIncreaseWhenDead_HealthLessOrEqualThan25()
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
        public void ChronicCultivation_HarvestMasterKush_MasterKushHarvestingStage()
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
        public void ChronicCultivation_HarvestSilverHaze_SilverHazeHarvestingstage()
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
        public void ChronicCultivation_DryMasterKush_MasterKushDryingStage()
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
        public void ChronicCultivation_CureMasterKush_MasterKushCuringStage()
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
        public void ChronicCultivation_CureSilverHaze_SilverHazeCuringStage()
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
        public void ChronicCultivation_FinishMasterKushForSale_MasterKushFinishedStage()
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
        public void ChronicCultivation_FinishSilverHazeForSale_SilverHazeFinishedStage()
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

        
    }
}