using System.Text.Json.Serialization;

namespace ProductManagement.Application.Contract.ExchangeRate
{
    public class ApiResponse
    {
        [JsonPropertyName("usd")]
        public CurrencyData Usd { get; set; }

        [JsonPropertyName("aed")]
        public CurrencyData Aed { get; set; }
    }

}

