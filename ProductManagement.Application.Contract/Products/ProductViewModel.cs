namespace ProductManagement.Application.Contract.Products
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public string? UnitOfMeasurement { get; set; }
        public long PriceInIran { get; set; }
        public int DefaultCount { get; set; }
        public string CreationDate { get; set; }
    }
}
