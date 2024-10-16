using InventorySystem.Business.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> GenerateReport()
        {
            var reportViewModel = await _dashboardService.GenerateReportAsync();
            return View(reportViewModel);
        }
    }
}
