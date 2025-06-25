namespace ProductManagement.Application.Contract.ExchangeRate
{
    public class ExchangeRateViewModel
    {
        public long Id { get; set; }
        public long Usd { get; set; }
        public long UsdChange { get; set; }
        public string UsdDate { get; set; }
        public long Aed { get; set; }
        public long AedChange { get; set; }
        public string AedDate { get; set; }
        public string CreationDate { get; set; }

    }
}
