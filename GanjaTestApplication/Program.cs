using System;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Classes;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Classes.Items;
using GanjaLibrary.Classes.Items.Storage;
using GanjaLibrary.Classes.Items.Filters;
using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Classes.Oils;
using GanjaLibrary;

namespace GanjaTestApplication
{
    class Program
    {
        private static int tableWidth = 77;

        static void PrintLine()
        {
            Console.WriteLine(new string('=', tableWidth));
        }

        static void Main(string[] args)
        {
            IChronic GanjaTest = new SilverHaze();
            IContainer MasonJar = new SmallMasonJar();
            IChemical Butane = new Benzene(900);
            IContainer Trousers = new CargoPants();
            IFilter CoffeeFilter = new CoffeeFilter();
            Trousers.Add((IItem)MasonJar);
            Trousers.Add(Butane);

            for (int i = 0; i < GanjaTest.SeedingAge; i++)
            {
                PrintLine();
                GanjaTest.Grow(Water.Low, Light.None, Food.None);
                GanjaTest.Print();
                Console.WriteLine();
            }

            for (int i = 0; i < GanjaTest.FloweringAge; i++)
            {
                PrintLine();
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.Low);
                GanjaTest.Print();
                Console.WriteLine();
            }

            for (int i = 0; i < 30; i++)
            {
                PrintLine();
                GanjaTest.Grow(Water.High, Light.Summer, Food.Low);
                GanjaTest.Print();
                Console.WriteLine();
            }

            var fullHarvest = GanjaTest.Harvest();
            var clone = GanjaTest;
            var harvest = fullHarvest.Harvest;
            var trimmings = fullHarvest.Trimmings;
            for (int i = 0; i < harvest.DryingAge; i++)
            {
                PrintLine();
                harvest.Dry();
                harvest.Print();
                Console.WriteLine();
            }
            Console.ReadLine();

            for (int i = 0; i < trimmings.DryingAge; i++)
            {
                PrintLine();
                trimmings.Dry();
                trimmings.Print();
                Console.WriteLine();
            }

            Console.ReadLine();

            PrintLine();
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

            PrintLine();
            
            ISolventMix secondSolventMix = new SolventMix(firstFilteredRemainingChronic, new Benzene(900));
            secondSolventMix.Wash(2);
            PrintLine();

            var secondFilteredSolvent = secondSolventMix.Filter(new CoffeeFilter()).Solvent;
            for (int i = 0; i < 12; i++)
            {
                firstFilteredSolvent.Heat();
                secondFilteredSolvent.Heat();
            }
            ICannaOil cannaOil = new CannaOil(firstFilteredSolvent, GanjaTest.Name);
            ICannaOil cannaOilv2 = new CannaOil(secondFilteredSolvent, GanjaTest.Name);

            cannaOil.Add(cannaOilv2);

            firstFilteredSolvent.Print();
            secondFilteredSolvent.Print();

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
