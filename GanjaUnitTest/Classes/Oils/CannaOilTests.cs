using Microsoft.VisualStudio.TestTools.UnitTesting;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Classes.Items;
using GanjaLibrary.Classes.Items.Storage;
using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Classes.Oils;
using GanjaLibrary.Classes.Items.Filters;

namespace GanjaLibrary.Classes.Tests
{
    [TestClass()]
    public class CannaOilTests
    {
        [TestMethod]
        public void CreateSilverHazeSolventMixTest()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Benzene = new Benzene(750);
            IContainer Trousers = new CargoPants();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Benzene);

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            IChronic WashTest = GanjaTest.Harvest().Harvest;
            for (int i = 0; i < WashTest.DryingAge; i++)
                WashTest.Dry();

            ISolventMix mix = new SolventMix(WashTest, Benzene);
            MasonJar.Add((IItem)mix);
            mix.Wash();
            mix.Wash();

            Assert.IsInstanceOfType(mix, typeof(IChemical));
            Assert.IsInstanceOfType(mix, typeof(IChronic));
            Assert.IsInstanceOfType(mix, typeof(ISolventMix));
        }

        [TestMethod]
        public void FilterSilverHazeFromSolventMixTest()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Benzene = new Benzene(750);
            IFilter CoffeeFilter = new CoffeeFilter();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            IChronic WashTest = GanjaTest.Harvest().Harvest;
            for (int i = 0; i < WashTest.DryingAge; i++)
                WashTest.Dry();

            ISolventMix mix = new SolventMix(WashTest, Benzene);
            MasonJar.Add((IItem)mix);
            mix.Wash();
            mix.Wash();
            mix.Filter(CoffeeFilter);
            ISolvent solvent = new Solvent((IChronic)mix, (IChemical)mix);

            Assert.IsInstanceOfType(solvent, typeof(IChemical));
            Assert.IsInstanceOfType(solvent, typeof(IChronic));
            Assert.IsInstanceOfType(solvent, typeof(ISolvent));
        }

        [TestMethod]
        public void HeatSilverHazeSolventTest()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Benzene = new Benzene(750);
            IFilter CoffeeFilter = new CoffeeFilter();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            IChronic WashTest = GanjaTest.Harvest().Harvest;
            for (int i = 0; i < WashTest.DryingAge; i++)
                WashTest.Dry();

            ISolventMix mix = new SolventMix(WashTest, Benzene);
            MasonJar.Add((IItem)mix);
            mix.Wash();
            mix.Wash();
            mix.Filter(CoffeeFilter);
            ISolvent solvent = new Solvent((IChronic)mix, (IChemical)mix);

            for (int i = 0; i < 16; i++)
                solvent.Heat();

            Assert.IsInstanceOfType(solvent, typeof(ICannaOil));
        }

        [TestMethod]
        public void CreateMasterKushSolventMixTest()
        {
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Benzene = new Benzene(750);
            IContainer Trousers = new CargoPants();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Benzene);

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            IChronic WashTest = GanjaTest.Harvest().Harvest;
            for (int i = 0; i < WashTest.DryingAge; i++)
                WashTest.Dry();

            ISolventMix mix = new SolventMix(WashTest, Benzene);
            MasonJar.Add((IItem)mix);
            mix.Wash();
            mix.Wash();

            Assert.IsInstanceOfType(mix, typeof(IChemical));
            Assert.IsInstanceOfType(mix, typeof(ISolventMix));
        }

        [TestMethod]
        public void FilterMasterKushFromSolventMixTest()
        {
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(750);
            IFilter CoffeeFilter = new CoffeeFilter();

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 30; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            IChronic WashTest = GanjaTest.Harvest().Harvest;
            for (int i = 0; i < WashTest.DryingAge; i++)
                WashTest.Dry();

            ISolventMix mix = new SolventMix(WashTest, Butane);
            MasonJar.Add((IItem)mix);
            mix.Wash();
            mix.Wash();
            mix.Filter(CoffeeFilter);
            ISolvent solvent = new Solvent((IChronic)mix, (IChemical)mix);

            Assert.IsInstanceOfType(solvent, typeof(IChemical));
            Assert.IsInstanceOfType(solvent, typeof(IChronic));
            Assert.IsInstanceOfType(solvent, typeof(ISolvent));
        }
    }
}
