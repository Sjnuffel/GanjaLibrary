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
        private static int tableWidth = 77;

        static void PrintLine()
        {
            Console.WriteLine(new string('=', tableWidth));
        }

        static void Main(string[] args)
        {
            IContainer Sweatpants = new Trousers();
            IShop GanjaShop = new Shop();
            Item Butane = new Butane();
            Sweatpants.Add(Butane);

            IChronic MasterKush = new MasterKush();
            IChronic SilverHaze = new SilverHaze();
            GanjaShop.Add((IItem)MasterKush);
            GanjaShop.Add((IItem)SilverHaze);

            PrintLine();
            Console.WriteLine(string.Format("\n\tSo, you want to grow some weed, huh?" +
                                            "\n\tWell, what do you want to do?\n"+
                                            "\n\t\t1) Grow Master Kush"+
                                            "\n\t\t2) Grow Silver Haze\n"));
            PrintLine();
            // First choice.

            string choice = Console.ReadLine();


    
    
    
    
    
    
    
    /*
            string str = Console.ReadLine();

            switch (str)
            {
                case "1":
                case "Master Kush":
                    PrintLine();
                    MasterKush.Print();
                    Console.WriteLine();
                    for (int i = 0; i < MasterKush.SeedingAge; i++)
                    {
                        MasterKush.Grow(Water.Low, Light.None, Food.None);
                        PrintLine();
                        MasterKush.Print();
                        Console.WriteLine();
                    }

                    for (int i = 0; i < MasterKush.FloweringAge; i++)
                    {
                        MasterKush.Grow(Water.Low, Light.Spring, Food.Low);
                        PrintLine();
                        MasterKush.Print();
                        Console.WriteLine();
                    }

                    for (int i = 0; i < 20; i++)
                    {
                        MasterKush.Grow(Water.Medium, Light.Summer, Food.Low);
                        PrintLine();
                        MasterKush.Print();
                        Console.WriteLine();
                    }

                    PrintLine();
                    Console.WriteLine(string.Format("\tAll grown up, what do you want to do now?\n"));
                    Console.WriteLine(string.Format("\t\t1) Harvest the plant, let it dry and cure the nuggets."));
                    Console.WriteLine(string.Format("\t\t2) Harvest the plant, but use it to make some oils.\n"));
                    PrintLine();

                    // Second possible choice.
                    string str2 = Console.ReadLine();

                    switch (str2)
                    {
                        case "1":
                        case "Nuggets":
                            IChronic harvest = MasterKush.Harvest();

                            harvest.Print();

                            for (int i = 0; i < 12; i++)
                            {
                                PrintLine();
                                harvest.Dry();
                                harvest.Print();
                            }

                            harvest.Weck();
                            harvest.Print();

                            for (int i = 0; i < 14; i++)
                            {
                                PrintLine();
                                harvest.Cure();
                                harvest.Print();
                            }

                            PrintLine();
                            harvest.Finish();
                            harvest.Print();
                            break;
                        case "2":
                        case "Oils":
                            Console.WriteLine(string.Format("Yeah I haven't made this yet..."));
                            break;
                        default:
                            PrintLine();
                            Console.WriteLine(string.Format("Can't do that dude, type 1 or 2."));
                            break;
                    }
                    break;
                case "2":
                case "Silver Haze":
                    PrintLine();
                    SilverHaze.Print();
                    Console.WriteLine();
                    for (int i = 0; i < SilverHaze.SeedingAge; i++)
                    {
                        SilverHaze.Grow(Water.Low, Light.None, Food.None);
                        PrintLine();
                        SilverHaze.Print();
                        Console.WriteLine();
                    }

                    for (int i = 0; i < SilverHaze.FloweringAge; i++)
                    {
                        SilverHaze.Grow(Water.Medium, Light.Spring, Food.Low);
                        PrintLine();
                        SilverHaze.Print();
                        Console.WriteLine();
                    }

                    for (int i = 0; i < 30; i++)
                    {
                        SilverHaze.Grow(Water.High, Light.Summer, Food.Low);
                        PrintLine();
                        SilverHaze.Print();
                        Console.WriteLine();
                    }

                    PrintLine();
                    Console.WriteLine(string.Format("\tAll grown up, what do you want to do now?\n"));
                    Console.WriteLine(string.Format("\t\t1) Harvest the plant, let it dry and cure the nuggets."));
                    Console.WriteLine(string.Format("\t\t2) Harvest the plant, but use it to make some oils.\n"));
                    PrintLine();

                    // Third possible choice.
                    string str3 = Console.ReadLine();

                    switch (str3)
                    {
                        case "1":
                        case "Nuggets":
                            IChronic harvest = SilverHaze.Harvest();

                            harvest.Print();

                            for (int i = 0; i < 12; i++)
                            {
                                PrintLine();
                                harvest.Dry();
                                harvest.Print();
                            }

                            harvest.Weck();
                            harvest.Print();

                            for (int i = 0; i < 14; i++)
                            {
                                PrintLine();
                                harvest.Cure();
                                harvest.Print();
                            }

                            PrintLine();
                            harvest.Finish();
                            harvest.Print();
                            break;
                        case "2":
                        case "Oils":
                            Console.WriteLine(string.Format("Yeah I haven't actually made this yet..."));
                            break;
                        default:
                            PrintLine();
                            Console.WriteLine(string.Format("Can't do that dude, type 1 or 2."));
                            break;
                    }

                    break;
                default:
                    PrintLine();
                    Console.WriteLine("\tThat's not going to work buddy, please type 1 or 2.\n");
                    break;
            }

            Console.ReadLine();
            */
        }
    }
}
