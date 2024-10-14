using InventorySystem.Business.Interfaces;
using InventorySystem.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventorySystem.Presentation.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            var categories = _unitOfWork.Categories.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
