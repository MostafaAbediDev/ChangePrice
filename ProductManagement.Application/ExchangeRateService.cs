using _0_Framework.Application;
using Newtonsoft.Json;
using ProductManagement.Application.Contract.ExchangeRate;
using ProductManagement.Domain.ExchangeRateAgg;

namespace ProductManagement.Application
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IExchangeRateRepository _exchangeRateRepository;
        private readonly HttpClient _httpClient;


        public ExchangeRateService(IExchangeRateRepository exchangeRateRepository, HttpClient httpClient)
        {
            _exchangeRateRepository = exchangeRateRepository;
            _httpClient = httpClient;
        }

        public async Task<OperationResult> GetAndSaveExchangeRateAsync()
        {
            var operation = new OperationResult();
            var apiUrl = "http://api.navasan.tech/latest/?api_key=freerBRoV2nDJlNZziQql9LFBrQPN23Q";

            var response = await _httpClient.GetStringAsync(apiUrl);
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);

            if (_exchangeRateRepository.Exists(x => x.Usd == apiResponse.Usd.value && x.Aed == apiResponse.Aed.value
                && x.UsdChange == apiResponse.Usd.change && x.AedChange == apiResponse.Aed.change))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var exchangeRate = new ExchangeRate(
                usd: apiResponse.Usd.value, 
                usdChange: apiResponse.Usd.change, 
                usdDate: apiResponse.Usd.date,
                aed: apiResponse.Aed.value,
                aedChange: apiResponse.Aed.change,
                aedDate: apiResponse.Aed.date
            );

            _exchangeRateRepository.Create(exchangeRate);
            await _exchangeRateRepository.SaveChangesAsync();

            return operation.Succedded();
        }

        public List<ExchangeRateViewModel> GetRate()
        {
            return _exchangeRateRepository.GetRate();
        }

    }

}

