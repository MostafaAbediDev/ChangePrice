using _0_FrameWork.Domain;

namespace ProductManagement.Domain.ExchangeRateAgg
{
    public class ExchangeRate : EntityBase
    {
        public long Usd { get; private set; }
        public long UsdChange { get; private set; }
        public string UsdDate { get; private set; }
        public long Aed { get; private set; }
        public long AedChange { get; private set; }
        public string AedDate { get; private set; }

        public ExchangeRate(long usd, long usdChange, string usdDate, long aed, long aedChange, string aedDate)
        {
            Usd = usd;
            UsdChange = usdChange;
            UsdDate = usdDate;
            Aed = aed;
            AedChange = aedChange;
            AedDate = aedDate;
        }
    }
}
