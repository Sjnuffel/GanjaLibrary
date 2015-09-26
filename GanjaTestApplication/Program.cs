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
            IChemical Butane = new Benzene();
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

            IChronic WashTest = GanjaTest.Harvest();
            for (int i = 0; i < WashTest.DryingAge; i++)
            {
                PrintLine();
                WashTest.Dry();
                WashTest.Print();
                Console.WriteLine();
            }

            PrintLine();
            ISolventMix mix = new SolventMix(WashTest, Butane);
            MasonJar.Add((IItem)mix);
            mix.Wash();
            mix.Print();
            PrintLine();
            mix.Wash();
            mix.Print();
            PrintLine();
            mix.Filter(CoffeeFilter);
            ISolvent solvent = new Solvent((IChronic)mix, (IChemical)mix);
            for (int i = 0; i < 12; i++)
                solvent.Heat();

            solvent.Heat();
            solvent.Heat();
            solvent.Heat();
            solvent.Heat();
            solvent.Heat();

            solvent.Print();

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
