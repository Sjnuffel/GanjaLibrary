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
            IChronic GanjaGame = new Sativa();
            GanjaGame.Print();
            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
                GanjaGame.Grow(Water.Low, Light.Off, Food.None);
                GanjaGame.Print();
                Console.WriteLine();
            }

            for (int i = 0; i < 16; i++)
            {
                GanjaGame.Grow(Water.Low, Light.Spring, Food.None);
                GanjaGame.Print();
                Console.WriteLine();
            }

            for (int i = 0; i < 4; i++)
            {
                GanjaGame.Grow(Water.Low, Light.Summer, Food.None);
                GanjaGame.Print();
                Console.WriteLine();
            }

            GanjaGame.Print();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
