using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealPlanner.Export;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        [HttpGet]
        public FileResult Get()
        {
            EvernoteExporter exporter = new EvernoteExporter();
            var stream = exporter.CreateExportedNote(DateTime.Now, "Example streamed note", new string[] { "apples", "bananas", "coconuts", "dates", "elderberry" });
            return File(stream, "application/xml", "export.enex");
        }
    }
}
