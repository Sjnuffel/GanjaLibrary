﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Classes.Items;
using GanjaLibrary.Classes.Items.Storage;
using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Classes.Oils;
using GanjaLibrary.Classes.Items.Filters;
using GanjaLibrary.Exceptions;

namespace GanjaLibrary.Classes.Tests
{
    [TestClass()]
    public class CannaOilCreationTests
    {
        [TestMethod]
        public void CannaOilCreation_SilverHazeCreateSolventMix()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(900);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Butane);

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

            harvest.Add(ref trimmings);

            ISolventMix firstSolventMix = new SolventMix(harvest, Butane);

            Assert.IsInstanceOfType(firstSolventMix, typeof(ISolventMix));
        }

        [TestMethod]
        public void CannaOilCreation_SilverHazeFilterFromSolventMixTest()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(1500);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Butane);

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

            harvest.Add(ref trimmings);

            ISolventMix firstSolventMix = new SolventMix(harvest, Butane);
            MasonJar.Add((IItem)firstSolventMix);

            firstSolventMix.Wash();

            var firstFilteredBatch = firstSolventMix.Filter(new CoffeeFilter());
            var firstFilteredRemainingChronic = firstFilteredBatch.Chronic;
            var firstFilteredSolvent = firstFilteredBatch.Solvent;

            Assert.IsInstanceOfType(firstFilteredSolvent, typeof(ISolvent));
            Assert.IsTrue(firstFilteredSolvent.THC != 0);
            Assert.IsInstanceOfType(firstFilteredRemainingChronic, typeof(IChronic));
        }

        [TestMethod]
        public void CannaOilCreation_SilverHazeHeatSolventTest()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Benzene = new Benzene(1000);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Benzene);

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 25; i++)
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

            ISolventMix firstSolventMix = new SolventMix(harvest, Benzene);
            MasonJar.Add((IItem)firstSolventMix);

            firstSolventMix.Wash();

            var firstFilteredBatch = firstSolventMix.Filter(new CoffeeFilter());
            firstSolventMix.Print();
            var firstFilteredRemainingChronic = firstFilteredBatch.Chronic;
            firstFilteredRemainingChronic.Print();
            var firstFilteredSolvent = firstFilteredBatch.Solvent;
            firstFilteredSolvent.Print();

            ISolventMix secondSolventMix = new SolventMix(firstFilteredRemainingChronic, new Benzene(1000));
            secondSolventMix.Wash(2);

            var secondFilteredSolvent = secondSolventMix.Filter(new CoffeeFilter()).Solvent;
            for (int i = 0; i < 15; i++)
            {
                firstFilteredSolvent.Heat();
                secondFilteredSolvent.Heat();
            }

            ICannaOil cannaOil = new CannaOil(firstFilteredSolvent, GanjaTest.Name);

            Assert.IsTrue(firstFilteredSolvent.Contents == 0);
            Assert.IsTrue(secondFilteredSolvent.Contents == 0);
        }

        [TestMethod]
        public void CannaOilCreation_MasterKushHeatSolventTest()
        {
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();
            // Needs extra chemical for test to pass.
            IChemical Benzene = new Benzene(1300);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Benzene);

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
            {
                harvest.Dry();
                trimmings.Dry();
            }

            harvest.Add(ref trimmings);

            ISolventMix firstSolventMix = new SolventMix(harvest, Benzene);
            MasonJar.Add((IItem)firstSolventMix);

            firstSolventMix.Wash();

            var firstFilteredBatch = firstSolventMix.Filter(new CoffeeFilter());
            firstSolventMix.Print();
            var firstFilteredRemainingChronic = firstFilteredBatch.Chronic;
            firstFilteredRemainingChronic.Print();
            var firstFilteredSolvent = firstFilteredBatch.Solvent;
            firstFilteredSolvent.Print();

            // Again needs extra chemical to pass test.
            ISolventMix secondSolventMix = new SolventMix(firstFilteredRemainingChronic, new Benzene(1300));
            secondSolventMix.Wash(2);

            var secondFilteredSolvent = secondSolventMix.Filter(new CoffeeFilter()).Solvent;
            for (int i = 0; i < 15; i++)
            {
                firstFilteredSolvent.Heat();
                secondFilteredSolvent.Heat();
            }

            ICannaOil cannaOil = new CannaOil(firstFilteredSolvent, GanjaTest.Name);

            Assert.IsTrue(firstFilteredSolvent.Contents == 0);
            Assert.IsTrue(secondFilteredSolvent.Contents == 0);
        }

        [TestMethod]
        public void CannaOilCreation_MasterKushCreateSolventMixTest()
        {
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(900);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Butane);

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

            harvest.Add(ref trimmings);

            ISolventMix firstSolventMix = new SolventMix(harvest, Butane);

            Assert.IsInstanceOfType(firstSolventMix, typeof(ISolventMix));
        }

        [TestMethod]
        public void CannaOilCreation_MasterKushFilterFromSolventMixTest()
        {
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(1500);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Butane);

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

            harvest.Add(ref trimmings);

            ISolventMix firstSolventMix = new SolventMix(harvest, Butane);
            MasonJar.Add((IItem)firstSolventMix);

            firstSolventMix.Wash();

            var firstFilteredBatch = firstSolventMix.Filter(new CoffeeFilter());
            var firstFilteredRemainingChronic = firstFilteredBatch.Chronic;
            var firstFilteredSolvent = firstFilteredBatch.Solvent;

            Assert.IsInstanceOfType(firstFilteredSolvent, typeof(ISolvent));
            Assert.IsTrue(firstFilteredSolvent.THC != 0);
            Assert.IsInstanceOfType(firstFilteredRemainingChronic, typeof(IChronic));
            Assert.IsTrue(firstFilteredRemainingChronic.Stage == Stage.Filtering);
        }

        [TestMethod]
        public void CannaOilCreation_MasterKushtoAddCannaOilTest_CannaOilv2YieldIsZero()
        {
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(900);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Butane);

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

            harvest.Add(ref trimmings);

            ISolventMix firstSolventMix = new SolventMix(harvest, Butane);
            MasonJar.Add((IItem)firstSolventMix);

            firstSolventMix.Wash();

            var firstFilteredBatch = firstSolventMix.Filter(new CoffeeFilter());
            firstSolventMix.Print();
            var firstFilteredRemainingChronic = firstFilteredBatch.Chronic;
            firstFilteredRemainingChronic.Print();
            var firstFilteredSolvent = firstFilteredBatch.Solvent;
            firstFilteredSolvent.Print();

            ISolventMix secondSolventMix = new SolventMix(firstFilteredRemainingChronic, new Benzene(900));
            secondSolventMix.Wash(2);

            var secondFilteredSolvent = secondSolventMix.Filter(new CoffeeFilter()).Solvent;
            for (int i = 0; i < 12; i++)
            {
                firstFilteredSolvent.Heat();
                secondFilteredSolvent.Heat();
            }

            ICannaOil cannaOil = new CannaOil(firstFilteredSolvent, GanjaTest.Name);
            ICannaOil cannaOilv2 = new CannaOil(secondFilteredSolvent, GanjaTest.Name);

            cannaOil.Add(cannaOilv2);

            Assert.IsTrue(cannaOilv2.Yield == 0);
        }

        [TestMethod]
        public void CannaOilCreation_SilverHazetoAddCannaOilTest_CannaOilv2YieldIsZero()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(900);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Butane);

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
                GanjaTest.Grow(Water.Low, Light.None, Food.None);

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);

            for (int i = 0; i < 25; i++)
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);

            var fullHarvest = GanjaTest.Harvest();
            var clone = GanjaTest;
            var harvest = fullHarvest.Harvest;
            var trimmings = fullHarvest.Trimmings;
            for (int i = 0; i < harvest.DryingAge; i++)
                harvest.Dry();

            for (int i = 0; i < trimmings.DryingAge; i++)
                trimmings.Dry();

            harvest.Add(ref trimmings);

            ISolventMix firstSolventMix = new SolventMix(harvest, Butane);
            MasonJar.Add((IItem)firstSolventMix);

            firstSolventMix.Wash();

            var firstFilteredBatch = firstSolventMix.Filter(new CoffeeFilter());
            firstSolventMix.Print();
            var firstFilteredRemainingChronic = firstFilteredBatch.Chronic;
            firstFilteredRemainingChronic.Print();
            var firstFilteredSolvent = firstFilteredBatch.Solvent;
            firstFilteredSolvent.Print();

            ISolventMix secondSolventMix = new SolventMix(firstFilteredRemainingChronic, new Benzene(900));
            secondSolventMix.Wash(2);

            var secondFilteredSolvent = secondSolventMix.Filter(new CoffeeFilter()).Solvent;
            for (int i = 0; i < 12; i++)
            {
                firstFilteredSolvent.Heat();
                secondFilteredSolvent.Heat();
            }

            ICannaOil cannaOil = new CannaOil(firstFilteredSolvent, GanjaTest.Name);
            ICannaOil cannaOilv2 = new CannaOil(secondFilteredSolvent, GanjaTest.Name);

            cannaOil.Add(cannaOilv2);

            Assert.IsTrue(cannaOilv2.Yield == 0);
        }

        [TestMethod()]
        public void CannaOilCreation_MasterKushWash_MasterKushInWashingStage()
        {
            IChronic GanjaTest = new MasterKush();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(1500);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Butane);

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

            harvest.Add(ref trimmings);

            ISolventMix firstSolventMix = new SolventMix(harvest, Butane);
            MasonJar.Add((IItem)firstSolventMix);

            firstSolventMix.Wash();

            var firstFilteredBatch = firstSolventMix.Filter(new CoffeeFilter());
            firstSolventMix.Print();
            var firstFilteredRemainingChronic = firstFilteredBatch.Chronic;
            firstFilteredRemainingChronic.Print();
            var firstFilteredSolvent = firstFilteredBatch.Solvent;

            Assert.IsInstanceOfType(firstSolventMix, typeof(ISolventMix));
        }

        [TestMethod()]
        public void CannaOilCreation_SilverHazeWashOnce_SilverHazeInWashingStage()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(1500);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Butane);

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

            harvest.Add(ref trimmings);

            ISolventMix firstSolventMix = new SolventMix(harvest, Butane);
            MasonJar.Add((IItem)firstSolventMix);

            firstSolventMix.Wash();

            var firstFilteredBatch = firstSolventMix.Filter(new CoffeeFilter());
            var firstFilteredRemainingChronic = firstFilteredBatch.Chronic;
            var firstFilteredSolvent = firstFilteredBatch.Solvent;

            Assert.IsInstanceOfType(firstSolventMix, typeof(ISolventMix));
        }

        [TestMethod()]
        public void CannaOilCreation_SilverHazeCreateCannaOil_IsTypeofCannaOil()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(900);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Butane);

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

            harvest.Add(ref trimmings);

            ISolventMix firstSolventMix = new SolventMix(harvest, Butane);
            MasonJar.Add((IItem)firstSolventMix);

            firstSolventMix.Wash();

            var firstFilteredBatch = firstSolventMix.Filter(new CoffeeFilter());
            var firstFilteredRemainingChronic = firstFilteredBatch.Chronic;
            var firstFilteredSolvent = firstFilteredBatch.Solvent;

            ISolventMix secondSolventMix = new SolventMix(firstFilteredRemainingChronic, new Benzene(900));
            secondSolventMix.Wash(2);

            var secondFilteredSolvent = secondSolventMix.Filter(new CoffeeFilter()).Solvent;

            for (int i = 0; i < 12; i++)
            {
                firstFilteredSolvent.Heat();
                secondFilteredSolvent.Heat();
            }

            ICannaOil cannaOil = new CannaOil(firstFilteredSolvent, GanjaTest.Name);
            ICannaOil cannaOilv2 = new CannaOil(secondFilteredSolvent, GanjaTest.Name);

            cannaOil.Add(cannaOilv2);

            Assert.IsInstanceOfType(cannaOil, typeof(ICannaOil));
        }

        [TestMethod()]
        [ExpectedException(typeof(NotEnoughSolventException), "Not enough Solvent")]
        public void CannaOilCreation_NotEnoughChemicalForWash_ExpectedNotEnoughSolventException()
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(500);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Butane);

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

            harvest.Add(ref trimmings);

            ISolventMix firstSolventMix = new SolventMix(harvest, Butane);
            MasonJar.Add((IItem)firstSolventMix);

            firstSolventMix.Wash();
        }
    }
}
