using System;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Classes;
using GanjaLibrary.Enums;

namespace GanjaTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IChronic GanjaTest = new SilverHaze();
            GanjaTest.Print();
            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
                GanjaTest.Grow(Water.Low, Light.Off, Food.None);
                GanjaTest.Print();
                Console.WriteLine();
            }

            for (int i = 0; i < 16; i++)
            {
                GanjaTest.Grow(Water.Medium, Light.Spring, Food.None);
                GanjaTest.Print();
                Console.WriteLine();
            }

            for (int i = 0; i < 4; i++)
            {
                GanjaTest.Grow(Water.Low, Light.Summer, Food.None);
                GanjaTest.Print();
                Console.WriteLine();
            }

            GanjaTest.Print();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
