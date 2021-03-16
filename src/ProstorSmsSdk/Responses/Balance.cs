using Newtonsoft.Json;
using ProstorSmsSdk.Enums;

namespace ProstorSmsSdk.Responses
{
    public class Balance
    {
        /// <summary>
        ///     Кредит (возможность использовать сервис при отрицательном балансе)
        /// </summary>
        public decimal Credit { get; set; }

        /// <summary>
        ///     Количество средств на балансе
        /// </summary>
        [JsonProperty("balance")]
        public decimal BalanceValue { get; set; }

        /// <summary>
        ///     Тип баланса: RUB, SMS
        /// </summary>
        public string Type { get; set; } = null!;

        public BalanceType GetBalanceType()
        {
            return BalanceTypeConverter.FromString(Type);
        }
    }
}