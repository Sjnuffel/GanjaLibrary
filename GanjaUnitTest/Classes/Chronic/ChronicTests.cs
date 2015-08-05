using Microsoft.VisualStudio.TestTools.UnitTesting;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Classes.Items;

namespace GanjaLibrary.Classes.Tests
{
    [TestClass()]
    public class ChronicTests
    {
        [TestMethod()]
        public void PerfectSilverHazeGrowTest()
        {
            IChronic GanjaTest = new SilverHaze();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
            {
                GanjaTest.Grow(Water.Low, Light.None, Food.Low);
            }

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
            {
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);
            }

            for (int i = 0; i < 30; i++)
            {
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);
            }
            Assert.IsTrue(GanjaTest.Stage == Stage.Flowering);
            Assert.IsTrue(GanjaTest.Health > 90);
        }

        [TestMethod()]
        public void PerfectMasterKushGrowTest()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
            {
                GanjaTest.Grow(Water.Low, Light.None, Food.None);
            }

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
            {
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
            }

            for (int i = 0; i < 25; i++)
            {
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);
            }
            Assert.IsTrue(GanjaTest.Stage == Stage.Flowering);
            Assert.IsTrue(GanjaTest.Health > 90);
        }

        [TestMethod()]
        public void KillMasterKushSeedTest()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
            {
                GanjaTest.Grow(Water.None, Light.None, Food.None);
            }

            for (int i = 0; i < 20; i++)
            {
                GanjaTest.Grow(Water.None, Light.None, Food.None);
            }

            for (int i = 0; i < 10; i++)
            {
                GanjaTest.Grow(Water.None, Light.None, Food.None);
            }
            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void KillSilverHazeSeedTest()
        {
            IChronic GanjaTest = new SilverHaze();
            for (int i = 0; i < 20; i++)
            {
                GanjaTest.Grow(Water.None, Light.None, Food.None);
            }

            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void KillMasterKushVegatativeTest()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
            {
                GanjaTest.Grow(Water.Low, Light.None, Food.None);
            }

            // For test to succeed it needed extra days in Vegatative state.
            for (int i = 0; i < 30; i++)
            {
                GanjaTest.Grow(Water.None, Light.None, Food.None);
            }
            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void KillSilverHazeVegatativeTest()
        {
            IChronic GanjaTest = new SilverHaze();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
            {
                GanjaTest.Grow(Water.Low, Light.None, Food.None);
            }

            // For test to succeed it needed extra days in Vegatative state.
            for (int i = 0; i < 30; i++)
            {
                GanjaTest.Grow(Water.None, Light.None, Food.None);
            }
            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void KillMasterKushFloweringTest()
        {
            IChronic GanjaTest = new MasterKush();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
            {
                GanjaTest.Grow(Water.Low, Light.None, Food.None);
            }

            // For test to succeed it needed extra days in Vegatative state.
            for (int i = 0; i < GanjaTest.FloweringAge; i++)
            {
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
            }

            for (int i = 0; i < 70; i++)
            {
                GanjaTest.Grow(Water.None, Light.None, Food.None);
            }
            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void KillSilverHazeFloweringTest()
        {
            IChronic GanjaTest = new SilverHaze();
            for (int i = 0; i < GanjaTest.SeedingAge; i++)
            {
                GanjaTest.Grow(Water.Low, Light.None, Food.None);
            }

            // For test to succeed it needed extra days in Vegatative state.
            for (int i = 0; i < GanjaTest.FloweringAge; i++)
            {
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
            }

            for (int i = 0; i < 70; i++)
            {
                GanjaTest.Grow(Water.None, Light.None, Food.None);
            }
            Assert.IsTrue(GanjaTest.Stage == Stage.Dead);
        }

        [TestMethod()]
        public void NegativeHeightTest()
        {
            {
                IChronic GanjaTest = new MasterKush();
                for (int i = 0; i < GanjaTest.SeedingAge; i++)
                {
                    GanjaTest.Grow(Water.None, Light.None, Food.None);
                }

                for (int i = 0; i < GanjaTest.FloweringAge; i++)
                {
                    GanjaTest.Grow(Water.None, Light.None, Food.None);
                }

                for (int i = 0; i < 10; i++)
                {
                    GanjaTest.Grow(Water.None, Light.None, Food.None);
                }
                Assert.IsTrue(GanjaTest.Height >= 0);
            }
        }

        [TestMethod()]
        public void AgeFreezeWhenDeadTest()
        {
            {
                IChronic GanjaTest = new MasterKush();
                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.None, Light.Spring, Food.None);
                }

                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.None, Light.None, Food.None);
                }

                for (int i = 0; i < 10; i++)
                {
                    GanjaTest.Grow(Water.None, Light.None, Food.None);
                }
                Assert.IsTrue(GanjaTest.Age == 13);
            }
        }

        [TestMethod()]
        public void HealthIncreaseWhenDeadTest()
        {
            {
                IChronic GanjaTest = new MasterKush();
                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.None, Light.Spring, Food.None);
                }

                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.None, Light.None, Food.None);
                }

                for (int i = 0; i < 10; i++)
                {
                    GanjaTest.Grow(Water.None, Light.None, Food.None);
                }
                Assert.IsTrue(GanjaTest.Health <= -25);
            }
        }

        [TestMethod()]
        public void GrowAndHarvestPlantTest()
        {
            {
                IChronic GanjaTest = new MasterKush();
                GanjaTest.Print();
                for (int i = 0; i < GanjaTest.SeedingAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.None, Food.None);
                }

                for (int i = 0; i < GanjaTest.FloweringAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
                }

                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);
                }

                IChronic HarvestTest = GanjaTest.Harvest();
                Assert.IsTrue(HarvestTest.Stage == Stage.Drying);
            }
        }

        [TestMethod()]
        public void GrowHarvestAndDryPlantTest()
        {
            {
                IChronic GanjaTest = new MasterKush();
                GanjaTest.Print();
                for (int i = 0; i < GanjaTest.SeedingAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.None, Food.None);
                }

                for (int i = 0; i < GanjaTest.FloweringAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
                }

                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);
                }

                IChronic DryTest = GanjaTest.Harvest();

                for (int i = 0; i < DryTest.DryingAge; i++)
                {
                    DryTest.Dry();
                }
                Assert.IsTrue(DryTest.Stage == Stage.Drying);
            }
        }

        [TestMethod()]
        public void GrowHarvestDryAndCurePlantTest()
        {
            {
                IChronic GanjaTest = new MasterKush();
                GanjaTest.Print();
                for (int i = 0; i < GanjaTest.SeedingAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.None, Food.None);
                }

                for (int i = 0; i < GanjaTest.FloweringAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
                }

                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);
                }

                IChronic CureTest = GanjaTest.Harvest();

                for (int i = 0; i < CureTest.DryingAge; i++)
                {
                    CureTest.Dry();
                }

                CureTest.Weck();
                for (int i = 0; i < 14; i++)
                {
                    CureTest.Cure();
                }
                Assert.IsTrue(CureTest.Stage == Stage.Curing);
            }
        }

        [TestMethod()]
        public void GrowHarvestDryCureAndFinishPlantTest()
        {
            {
                IChronic GanjaTest = new MasterKush();
                GanjaTest.Print();
                for (int i = 0; i < GanjaTest.SeedingAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.None, Food.None);
                }

                for (int i = 0; i < GanjaTest.FloweringAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
                }

                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);
                }

                IChronic CureTest = GanjaTest.Harvest();

                for (int i = 0; i < CureTest.DryingAge; i++)
                {
                    CureTest.Dry();
                }

                CureTest.Weck();
                for (int i = 0; i < 14; i++)
                {
                    CureTest.Cure();
                }

                CureTest.Finish();
                Assert.IsTrue(CureTest.Stage == Stage.Finished);
            }
        }

        [TestMethod()]
        public void FullCycleGrowthAddToInventoryTest()
        {
            {
                IContainer FirstTrousers = new Trousers();
                IChronic GanjaTest = new MasterKush();
                GanjaTest.Print();
                for (int i = 0; i < GanjaTest.SeedingAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.None, Food.None);
                }

                for (int i = 0; i < GanjaTest.FloweringAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
                }

                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);
                }

                IChronic InventoryTest = GanjaTest.Harvest();

                for (int i = 0; i < InventoryTest.DryingAge; i++)
                {
                    InventoryTest.Dry();
                }

                InventoryTest.Weck();
                for (int i = 0; i < 14; i++)
                {
                    InventoryTest.Cure();
                }

                InventoryTest.Finish();
                FirstTrousers.Add((IItem)InventoryTest);
                Assert.IsTrue(FirstTrousers.ItemAmount == 1);
            }
        }

        [TestMethod()]
        public void FullCycleGrowthAddThenRemoveFromInventoryTest()
        {
            {
                IContainer FirstTrousers = new Trousers();
                IChronic GanjaTest = new MasterKush();
                GanjaTest.Print();
                for (int i = 0; i < GanjaTest.SeedingAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.None, Food.None);
                }

                for (int i = 0; i < GanjaTest.FloweringAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
                }

                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);
                }

                IChronic InventoryTest = GanjaTest.Harvest();

                for (int i = 0; i < InventoryTest.DryingAge; i++)
                {
                    InventoryTest.Dry();
                }

                InventoryTest.Weck();
                for (int i = 0; i < 14; i++)
                {
                    InventoryTest.Cure();
                }

                InventoryTest.Finish();
                FirstTrousers.Add((IItem)InventoryTest);
                FirstTrousers.Remove((IItem)InventoryTest);
                Assert.IsTrue(FirstTrousers.ItemAmount == 0);
            }
        }

        [TestMethod()]
        public void FullCycleGrowthAddToInventorySellToShopTest()
        {
            {
                IContainer FirstTrousers = new Trousers();
                IChronic GanjaTest = new MasterKush();
                GanjaTest.Print();
                for (int i = 0; i < GanjaTest.SeedingAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.None, Food.None);
                }

                for (int i = 0; i < GanjaTest.FloweringAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
                }

                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);
                }

                IChronic SellTest = GanjaTest.Harvest();

                for (int i = 0; i < SellTest.DryingAge; i++)
                {
                    SellTest.Dry();
                }

                SellTest.Weck();
                for (int i = 0; i < 14; i++)
                {
                    SellTest.Cure();
                }

                SellTest.Finish();
                FirstTrousers.Add((IItem)SellTest);

                IShop shop = new Shop();
                shop.Sell((IItem)SellTest);

                Assert.IsTrue(shop.ItemAmount == 1);
            }
        }

        [TestMethod()]
        public void MaxSlotsInventoryNotOverridenTest()
        {
            {
                IContainer FirstTrousers = new Trousers();
                IChronic GanjaTest = new MasterKush();
                IChronic GanjaTest2 = new MasterKush();
                IChronic GanjaTest3 = new MasterKush();
                GanjaTest.Print();
                for (int i = 0; i < GanjaTest.SeedingAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.None, Food.None);
                    GanjaTest2.Grow(Water.Low, Light.None, Food.None);
                    GanjaTest3.Grow(Water.Low, Light.None, Food.None);
                }

                for (int i = 0; i < GanjaTest.FloweringAge; i++)
                {
                    GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
                    GanjaTest2.Grow(Water.Low, Light.Spring, Food.None);
                    GanjaTest3.Grow(Water.Low, Light.Spring, Food.None);
                }

                for (int i = 0; i < 20; i++)
                {
                    GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);
                    GanjaTest2.Grow(Water.Medium, Light.Summer, Food.None);
                    GanjaTest3.Grow(Water.Medium, Light.Summer, Food.None);
                }

                IChronic SellTest = GanjaTest.Harvest();
                IChronic SellTest2 = GanjaTest2.Harvest();
                IChronic SellTest3 = GanjaTest3.Harvest();

                for (int i = 0; i < SellTest.DryingAge; i++)
                {
                    SellTest.Dry();
                    SellTest2.Dry();
                    SellTest3.Dry();
                }

                SellTest.Weck();
                for (int i = 0; i < 14; i++)
                {
                    SellTest.Cure();
                    SellTest2.Cure();
                    SellTest3.Cure();
                }

                SellTest.Finish();
                SellTest2.Finish();
                SellTest3.Finish();
                FirstTrousers.Add((IItem)SellTest);
                FirstTrousers.Add((IItem)SellTest2);
                FirstTrousers.Add((IItem)SellTest3);
                // Trousers only have 2 item slots, so should always assert to 2, the 3rd one will not be added.
                Assert.IsTrue(FirstTrousers.ItemAmount == 2);
            }
        }
    }
}