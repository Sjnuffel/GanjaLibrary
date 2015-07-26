using System;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Classes;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Classes.Items;

namespace GanjaTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer FirstTrousers = new Trousers();
            IChronic GanjaTest = new MasterKush();
            GanjaTest.Print();
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                GanjaTest.Grow(Water.Low, Light.None, Food.None);
                GanjaTest.Print();
                Console.WriteLine();
            }

            for (int i = 0; i < 35; i++)
            {
                GanjaTest.Grow(Water.Low, Light.Spring, Food.None);
                GanjaTest.Print();
                Console.WriteLine();
            }

            for (int i = 0; i < 20; i++)
            {
                GanjaTest.Grow(Water.Medium, Light.Summer, Food.None);
                GanjaTest.Print();
                Console.WriteLine();
            }

            IChronic harvest = GanjaTest.Harvest();

            harvest.Print();

            for (int i = 0; i < 12; i++)
            {
                harvest.Dry();
                harvest.Print();
            }

            harvest.Weck();
            harvest.Print();

            for (int i = 0; i < 14; i++)
            {
                harvest.Cure();
                harvest.Print();
            }

            harvest.Finish();
            harvest.Print();

            FirstTrousers.Add((IItem)harvest);

            IShop shop = new Shop();
            shop.Sell((IItem)harvest);
            
            var price = shop.Buy("Master Kush").Value;

            Console.WriteLine(price);
            Console.ReadLine();
        }
    }
}
