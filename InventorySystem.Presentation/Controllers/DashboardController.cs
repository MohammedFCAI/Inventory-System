using Microsoft.AspNetCore.Mvc;
using InventorySystem.Business.Services.Abstraction;
using System.Threading.Tasks;

namespace InventorySystem.Presentation.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            var dashboardViewModel = await _dashboardService.GetDashboardDataAsync();
            return View(dashboardViewModel);
        }
    }
}
