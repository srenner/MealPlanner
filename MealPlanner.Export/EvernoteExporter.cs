using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MealPlanner.Export
{
    public class EvernoteExporter : IExport
    {
        public Stream CreateExportedNote(DateTime date, string title, string[] checklist)
        {
            throw new NotImplementedException();
        }
    }
}
