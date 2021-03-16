using System;

namespace ProstorSmsSdk.Responses
{
    public abstract class SmsApiResponse
    {
        /// <summary>
        ///     Статус приема пакета (ok – ошибок не обнаружено)
        /// </summary>
        public string Status { get; set; } = null!;

        public bool IsSuccess => Status.Equals("ok", StringComparison.OrdinalIgnoreCase);
    }
}