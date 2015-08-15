using Microsoft.VisualStudio.TestTools.UnitTesting;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Classes.Items;
using GanjaLibrary.Classes.Items.Storage;

namespace GanjaUnitTest.Classes.Items
{
    [TestClass()]
    public class ItemTests
    {
        [TestMethod()]
        public void AddButaneToShopTest()
        {
            IContainer ShopTest = new Shop();
            IChemical Butane = new Butane();
            ShopTest.Add(Butane);

            Assert.IsTrue(ShopTest.ItemAmount == 1);
        }

        [TestMethod()]
        public void AddSmallJarToShopTest()
        {
            IContainer ShopTest = new Shop();
            Item MasonJar = new SmallJar();
            ShopTest.Add(MasonJar);

            Assert.IsTrue(ShopTest.ItemAmount == 1);
        }

        [TestMethod()]
        public void AddCargoPantsToShopTest()
        {
            IContainer ShopTest = new Shop();
            IContainer CargoPants = new CargoPants();
            ShopTest.Add((IItem)CargoPants);

            Assert.IsTrue(ShopTest.ItemAmount == 1);
        }

        [TestMethod()]
        public void AddBenzeneToInventoryTest()
        {
            IContainer ShopTest = new Shop();
            IChemical Benzene = new Butane();
            ShopTest.Add((IItem)Benzene);

            Assert.IsTrue(ShopTest.ItemAmount == 1);
        }
    }
}
