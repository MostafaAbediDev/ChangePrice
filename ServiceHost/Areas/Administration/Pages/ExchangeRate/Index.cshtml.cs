using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManagement.Application.Contract.ExchangeRate;

namespace ServiceHost.Areas.Administration.Pages.ExchangeRate
{
    public class IndexModel : PageModel
    {

        private readonly IExchangeRateService _exchangeRateService;
        public List<ExchangeRateViewModel> ExchangeRates;

        public IndexModel(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        public void OnGet()
        {
            ExchangeRates = _exchangeRateService.GetRate();
        }

    }
}
