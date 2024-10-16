using InventorySystem.Business.Interfaces;
using InventorySystem.Data.Entities;
using InventorySystem.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InventorySystem.Presentation.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var allSuppliers = _unitOfWork.Suppliers.GetAll().ToList();
            return View(allSuppliers);
        }
        [HttpGet]
        public IActionResult CreateSupplier()
        {
            return View(new CreateSupplierViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSupplier(CreateSupplierViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var supplier = new Supplier
                {
                    Name = viewModel.Name,
                    ContactInfo = viewModel.ContactInfo
                };

                _unitOfWork.Suppliers.Add(supplier);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult EditSupplier(int id)
        {
            var supplier = _unitOfWork.Suppliers.GetById(id);
            if (supplier is null)
            {
                return NotFound();
            }
            var viewModel = new EditSupplierViewModel
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactInfo = supplier.ContactInfo
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSupplier(EditSupplierViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var supplier = _unitOfWork.Suppliers.GetById(viewModel.Id);
                if (supplier is null)
                {
                    return NotFound();
                }
                supplier.Name = viewModel.Name;
                supplier.ContactInfo = viewModel.ContactInfo;

                _unitOfWork.Suppliers.Update(supplier);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteSupplier(int supplierId)
        {
            var supplier = _unitOfWork.Suppliers.GetById(supplierId);
            if (supplier != null)
            {
                _unitOfWork.Suppliers.Remove(supplier);
                _unitOfWork.Save();
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Supplier not found." });
        }
    }
}
