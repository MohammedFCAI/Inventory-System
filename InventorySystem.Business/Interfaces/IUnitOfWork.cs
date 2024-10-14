namespace InventorySystem.Business.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        ISupplierRepository Suppliers { get; }
        IStockRepository Stocks { get; }
        public void Save();
    }
}
