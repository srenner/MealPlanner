using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MealPlanner.Export
{
    public interface IExport
    {
        Stream CreateExportedNote(DateTime date, string title, string[] checklist);
    }
}
