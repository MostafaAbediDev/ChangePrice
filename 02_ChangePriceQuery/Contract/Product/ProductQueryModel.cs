namespace _02_ChangePriceQuery.Contract.Product
{
    public class ProductQueryModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Name { get; set; }
        public string UnitOfMeasurement { get; set; }
        public long PriceInIran { get; set; }
    }
}
