using InventorySystem.Business.Interfaces;
using InventorySystem.Business.Services.Abstraction;
using InventorySystem.Business.ViewModels;
using InventorySystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Business.Services.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetTotalProductsAsync()
        {
            var NumberOfProducts = _unitOfWork.Products.CountAsync();
            return await NumberOfProducts;
        }

        public async Task<int> GetTotalSuppliersAsync()
        {
            var NumberOfSuppliers = _unitOfWork.Suppliers.CountAsync();
            return await NumberOfSuppliers;
        }

        public async Task<int> GetTotalStocksAsync()
        {
            var NumberOfStock = _unitOfWork.Stocks.CountAsync();
            return await NumberOfStock;
        }

        public async Task<IEnumerable<Stock>> GetAllStocksAsync()
        {
            var AllStocks = _unitOfWork.Stocks.GetAllAsync();
            return await AllStocks;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var AllProducts = _unitOfWork.Products.GetAllAsync();
            return await AllProducts;
        }
        public async Task<DashboardViewModel> GetDashboardDataAsync()
        {
            var totalStocks = await _unitOfWork.Stocks.CountAsync();
            var totalProducts = await _unitOfWork.Products.CountAsync();
            var totalSuppliers = await _unitOfWork.Suppliers.CountAsync();
            var totalCategories = await _unitOfWork.Categories.CountAsync();

            var allStocks = await _unitOfWork.Stocks.GetAllAsync();
            var allProducts = await _unitOfWork.Products.GetAllAsync();

            var stockQuantities = allStocks.Select(s => s.Quantity).ToList();
            var stockDates = allStocks.Select(s => s.Date.ToString("yyyy-MM-dd")).ToList();
            var productNames = allProducts.Select(p => p.Name).ToList();
            var productQuantities = allProducts.Select(p => p.StockQuantity).ToList();


            var dashboardViewModel = new DashboardViewModel
            {
                TotalStocks = totalStocks,
                TotalProducts = totalProducts,
                TotalSuppliers = totalSuppliers,
                TotalCategories = totalCategories,
                AllStocks = allStocks,
                AllProducts = allProducts,
                StockQuantities = stockQuantities,
                StockDates = stockDates,
                ProductNames = productNames,
                ProductQuantities = productQuantities
            };

            return dashboardViewModel;
        }

    }
}
