namespace ProductManagement.Application.Contract
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public string? UnitOfMeasurement { get; set; }
        public long PriceInIran { get; set; }
        public string CreationDate { get; set; }
    }
}
