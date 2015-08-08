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
            Item Butane = new Butane();
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
    }
}
