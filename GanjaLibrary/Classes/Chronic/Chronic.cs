using GanjaLibrary.Classes.Items;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces;
using GanjaLibrary.Interfaces.Items;
using GanjaLibrary.Statics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GanjaLibrary.Classes
{
    public abstract partial class Chronic : Item, IChronic
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
            Console.WriteLine(string.Format("Yield: {0} \t\tCompost: {1}", Yield, Trimmings));

            if (Globals.Debug)
            {
                Console.WriteLine(string.Format("CBD content: {0}%; THC: {1}%", CBD * 100, THC * 100));
                Console.WriteLine(string.Format("Expected Yield: {0}", MaxYield));
                Console.WriteLine(string.Format("Height: {0}", Height));
            }
        }
        
        IChronic IChronic.Clone()
        {
            return (IChronic)Clone();
        }
    }
}