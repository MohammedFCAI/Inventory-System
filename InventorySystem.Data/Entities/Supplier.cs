namespace InventorySystem.Data.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; }
        public ICollection<SupplierCategory> SupplierCategories { get; set; }
    }
}
