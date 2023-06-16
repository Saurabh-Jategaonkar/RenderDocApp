using GroupDocs.Viewer;
using GroupDocs.Viewer.Options;
using Microsoft.AspNetCore.Mvc;
using RenderDocApp.Models;
using System.Diagnostics;

namespace RenderDocApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ViewDocument()
        {
            string fileName = Request.Form["fileToView"];
            string outputDirectory = ("Output/");
            string outputFilePath = Path.Combine(outputDirectory, "output.pdf");
            using (Viewer viewer = new("C:/Users/saura/Documents/Kneo_Projects/test.xlsx"))
            {
                PdfViewOptions options = new(outputFilePath);
                viewer.View(options);
            }
            var fileStream = new FileStream("Output/"+ "output.pdf",
                FileMode.Open,
                FileAccess.Read
                );
            var fsResult = new FileStreamResult(fileStream, "application/pdf");
                return fsResult;
        }
    }
}