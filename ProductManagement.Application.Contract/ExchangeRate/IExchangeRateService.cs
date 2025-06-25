using _0_Framework.Application;

namespace ProductManagement.Application.Contract.ExchangeRate
{
    public interface IExchangeRateService
    {
        Task<OperationResult> GetAndSaveExchangeRateAsync();
        List<ExchangeRateViewModel> GetRate();
    }
}
