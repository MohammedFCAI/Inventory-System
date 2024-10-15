using AspNetCoreHero.ToastNotification.Abstractions;
using InventorySystem.Business.Interfaces;
using InventorySystem.Data.Entities;
using InventorySystem.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _notyService;
        public CategoryController(IUnitOfWork unitOfWork, INotyfService notyService)
        {
            _unitOfWork = unitOfWork;
            _notyService = notyService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _unitOfWork.Categories.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Name = model.Name,
                    Description = model.Description
                };

                _unitOfWork.Categories.Add(category);
                _unitOfWork.Save();

                _notyService.Success("Category Added Successfully!");
                return RedirectToAction("Index");
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if (category == null)
                return BadRequest();
            var model = new UpdateCategoryViewModel()
            {
                Name = category.Name,
                Description = category.Description
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(UpdateCategoryViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var cateogry = _unitOfWork.Categories.GetById(id);
                if (cateogry == null)
                    return View(model);

                cateogry.Description = model.Description;
                cateogry.Name = model.Name;


                _unitOfWork.Categories.Update(cateogry);
                _unitOfWork.Save();

                _notyService.Success("Category Updated Successfully!");
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if (category != null)
            {

                _unitOfWork.Categories.Remove(category);
                _unitOfWork.Save();
                _notyService.Success("Category Deleted Successfully!");
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if (category != null)
                return View(category);

            return BadRequest();
        }

    }
}
