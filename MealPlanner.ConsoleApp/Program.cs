using System;
using System.IO;
using MealPlanner.Export;

namespace MealPlanner.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Class1.Test1();
            //EvernoteExporter.CreateAndSaveNote(DateTime.Now, "Example Note", new string[] { "apples", "bananas", "chocolate" });

            var exporter = new EvernoteExporter();
            var stream = exporter.CreateExportedNote(DateTime.Now, "My List", new string[] { "apples", "bananas", "chocolate" });

            var streamReader = new StreamReader(stream);
            string text = streamReader.ReadToEnd();
            Console.WriteLine(text);
        }
    }
}
