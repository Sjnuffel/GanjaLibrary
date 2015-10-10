using Microsoft.VisualStudio.TestTools.UnitTesting;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Classes.Items;
using GanjaLibrary.Classes.Items.Storage;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Classes;
using GanjaLibrary.Enums;

namespace GanjaUnitTest.Classes.Items
{
    [TestClass()]
    public class StorageAndItemTests
    {
        [TestMethod()]
        public void StorageAndItem_ButaneAddToShop_ItemAmountIncrease()
        {
            IContainer ShopTest = new Shop();
            IChemical Butane = new Butane();
            ShopTest.Add(Butane);

            Assert.IsTrue(ShopTest.ItemAmount == 1);
        }

        [TestMethod()]
        public void StorageAndItem_SmallJarAddToShop_ItemAmountIncrease()
        {
            IContainer ShopTest = new Shop();
            IItem MasonJar = new SmallMasonJar();
            ShopTest.Add(MasonJar);

            Assert.IsTrue(ShopTest.ItemAmount == 1);
        }

        [TestMethod()]
        public void StorageAndItem_CargoPantsAddToShop_ItemAmountIncrease()
        {
            IContainer ShopTest = new Shop();
            IContainer CargoPants = new CargoPants();
            ShopTest.Add((IItem)CargoPants);

            Assert.IsTrue(ShopTest.ItemAmount == 1);
        }

        [TestMethod()]
        public void StorageAndItem_BenzeneAddToInventory_ItemAmountIncrease()
        {
            IContainer ShopTest = new Shop();
            IChemical Benzene = new Butane();
            ShopTest.Add(Benzene);

            Assert.IsTrue(ShopTest.ItemAmount == 1);
        }

        [TestMethod()]
        public void StorageAndItem_MasterKushAddToInventory_ItemAmountIncrease()
        {
            IContainer FirstTrousers = new Trousers();
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);


            var InventoryTestResult = GanjaTest.Harvest().Harvest;

            for (int i = 0; i < InventoryTestResult.DryingAge; i++)
                InventoryTestResult.Dry();

            InventoryTestResult.Weck();
            for (int i = 0; i < 14; i++)
                InventoryTestResult.Cure(MasonJar);

            InventoryTestResult.Finish();
            FirstTrousers.Add(InventoryTestResult);
            Assert.IsTrue(FirstTrousers.ItemAmount == 1);
            Assert.IsInstanceOfType(InventoryTestResult, typeof(IChronic));
        }

        [TestMethod()]
        public void StorageAndItem_RemoveFromStorage_ItemAmountDecrease()
        {
            IContainer FirstTrousers = new Trousers();
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);

            var InventoryTest = GanjaTest.Harvest().Harvest;

            for (int i = 0; i < InventoryTest.DryingAge; i++)
                InventoryTest.Dry();

            InventoryTest.Weck();
            for (int i = 0; i < 14; i++)
                InventoryTest.Cure(MasonJar);

            InventoryTest.Finish();
            FirstTrousers.Add(InventoryTest);
            Assert.IsTrue(FirstTrousers.ItemAmount == 1);
            FirstTrousers.Remove(InventoryTest);
            Assert.IsTrue(FirstTrousers.ItemAmount == 0);
        }

        [TestMethod()]
        public void StorageAndItem_GrowAndSellToShop_ShopItemAmountIncrease()
        {
            IContainer FirstTrousers = new Trousers();
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);

            for (int i = 0; i < 20; i++)
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);

            IChronic SellTest = GanjaTest.Harvest().Harvest;

            for (int i = 0; i < SellTest.DryingAge; i++)
                SellTest.Dry();

            SellTest.Weck();
            for (int i = 0; i < 14; i++)
                SellTest.Cure(MasonJar);

            SellTest.Finish();
            FirstTrousers.Add((IItem)SellTest);

            IShop shop = new Shop();
            shop.Sell((IItem)SellTest);

            Assert.IsTrue(shop.ItemAmount == 1);
        }

        [TestMethod()]
        public void StorageAndItem_MaxSlotsInventoryNotOverridden_ItemAmountIsTwo()
        {
            IContainer FirstTrousers = new Trousers();
            IChronic GanjaTest = new MasterKush();
            IChronic GanjaTest2 = new MasterKush();
            IChronic GanjaTest3 = new MasterKush();

            FirstTrousers.Add((IItem)GanjaTest);
            FirstTrousers.Add((IItem)GanjaTest2);
            FirstTrousers.Add((IItem)GanjaTest3);
            // Trousers only have 2 item slots, so should always assert to 2, the 3rd one will not be added.
            Assert.IsTrue(FirstTrousers.ItemAmount == 2);
        }
    }
}
