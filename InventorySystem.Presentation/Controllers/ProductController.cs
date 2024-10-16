using AspNetCoreHero.ToastNotification.Abstractions;
using InventorySystem.Business.Helper;
using InventorySystem.Business.Interfaces;
using InventorySystem.Data.Entities;
using InventorySystem.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Presentation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _notyService;
        public ProductController(IUnitOfWork unitOfWork, INotyfService notyService)
        {
            _unitOfWork = unitOfWork;
            _notyService = notyService;
        }

        [HttpGet]
        public IActionResult Index(int? categoryId)
        {
            var categories = _unitOfWork.Categories.GetAll().ToList();
            var products = _unitOfWork.Products.GetAll().ToList();

            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            var viewModel = new ProductViewModel
            {
                Categories = categories,
                Products = products,
                SelectedCategoryId = categoryId
            };

            return View(viewModel);
        }



        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _unitOfWork.Categories.GetAll().ToList();
            ViewBag.Suppliers = _unitOfWork.Suppliers.GetAll().ToList();
            return View();
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.ImageUrl = FileHelper.UploadFile("products", product.ImageFile);
                _unitOfWork.Products.Add(product);
                _unitOfWork.Save();

                _notyService.Success("Product Added Successfully!");
                return RedirectToAction("Index");
            }
            return View(product);
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            ViewBag.Categories = _unitOfWork.Categories.GetAll().ToList();
            ViewBag.Suppliers = _unitOfWork.Suppliers.GetAll().ToList();
            if (product == null)
                return BadRequest();

            return View(product);
        }

        [HttpPost]


        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ImageFile is not null && product.ImageFile.Length > 0)
                    product.ImageUrl = FileHelper.UploadFile("ProductPhoto", product.ImageFile);
                _unitOfWork.Products.Update(product);
                _unitOfWork.Save();

                _notyService.Success("Product Updated Successfully!");
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product != null)
            {

                _unitOfWork.Products.Remove(product);
                _unitOfWork.Save();
                _notyService.Success("Product Deleted Successfully!");
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product != null)
                return View(product);

            return BadRequest();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(Product product, int quantity)
        {
            if (ModelState.IsValid && quantity > 0)
            {
                product.StockQuantity += quantity;
                Stock stock = new Stock()
                {
                    ProductName = product.Name,
                    Quantity = quantity,
                    Price = product.Price * quantity,
                    ToInventory = true,
                    Date = DateTime.UtcNow.AddHours(1),
                    ProductId = product.Id,
                    Operation = Data.Enum.Operation.Restock
                };

                _unitOfWork.Stocks.Add(stock);
                _unitOfWork.Products.Update(product);
                _unitOfWork.Save();

                _notyService.Success("Stock added Successfully!");
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Sell(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product != null)
                return View(product);

            return BadRequest();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sell(Product product, int quantity)
        {
            if (ModelState.IsValid && quantity > 0)
            {
                product.StockQuantity -= quantity;
                Stock stock = new Stock()
                {
                    ProductName = product.Name,
                    Quantity = quantity,
                    Price = product.Price * quantity,
                    ToInventory = false,
                    Date = DateTime.UtcNow.AddHours(3),
                    ProductId = product.Id,
                    Operation = Data.Enum.Operation.Take
                };

                _unitOfWork.Stocks.Add(stock);
                _unitOfWork.Products.Update(product);
                _unitOfWork.Save();

                _notyService.Success("Stock added Successfully!");
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var product = _unitOfWork.Products.GetByIdWithInclude(id);
            if (product != null)
                return View(product);

            return BadRequest();
        }
    }
}
