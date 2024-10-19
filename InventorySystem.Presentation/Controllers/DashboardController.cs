using InventorySystem.Business.Interfaces;
using InventorySystem.Business.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Presentation.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IDashboardService dashboardService, IUnitOfWork unitOfWork)
        {
            _dashboardService = dashboardService;
            _unitOfWork = unitOfWork;
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
