using System;
using MealPlanner.Export;

namespace MealPlanner.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Class1.Test1();
            EvernoteExporter.CreateAndSaveNote(DateTime.Now, "Example Note", new string[] { "bananas", "apples", "charcoal" });
        }
    }
}
