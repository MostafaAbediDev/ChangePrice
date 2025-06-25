using _0_FrameWork.Domain;
using ProductManagement.Application.Contract.ExchangeRate;

namespace ProductManagement.Domain.ExchangeRateAgg
{
    public interface IExchangeRateRepository : IRepository<long, ExchangeRate>
    {
        List<ExchangeRateViewModel> GetRate();
    }
}
