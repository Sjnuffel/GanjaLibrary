﻿using GanjaLibrary.Interfaces;
using GanjaLibrary.Statics;
using System;

namespace GanjaLibrary.Classes
{
    public abstract partial class Chronic
    {
        public event EventHandler Died;

        // Printing out all the changing variables so we can track progress.
        public virtual void Print()                                                        
        {
            Console.WriteLine(string.Format("GUID: {0}", Id));
            Console.WriteLine(string.Format("Stage: {0}", Stage));
            Console.WriteLine(string.Format("Age: {0}     \t\t\tName: {1}", Age, Name));
            Console.WriteLine(string.Format("Seeding Age: {0} \t\t\tFlowering Age: {1}", SeedingAge, FloweringAge));
            Console.WriteLine(string.Format("Water: {0}  \t\t\tLight: {1}", Water, Light));
            Console.WriteLine(string.Format("Food: {0} \t\t\tHealth: {1}", Food, Health));
            Console.WriteLine(string.Format("CBD: {0}%  \t\t\tTHC: {1}%", CBD * 100, THC * 100));
            Console.WriteLine(string.Format("Height: {0} \t\tQuality: {1}", Height, Quality));

            if (Globals.Debug)
            {
                Console.WriteLine(string.Format("CBD content: {0}%; THC: {1}%", CBD * 100, THC * 100));
                Console.WriteLine(string.Format("Expected Yield: {0}", MaxYield));
                Console.WriteLine(string.Format("Height: {0}", Height));
            }
        }
    }
}