using Newtonsoft.Json;
using ProstorSmsSdk.Responses;

namespace ProstorSmsSdk.Requests
{
    public abstract class SmsApiRequest<TResponse> where TResponse : SmsApiResponse
    {
        protected SmsApiRequest(string methodApi, string login, string password)
        {
            MethodApi = methodApi;
            Login = login;
            Password = password;
        }

        /// <summary>
        /// Метод url
        /// </summary>
        [JsonIgnore]
        public string MethodApi { get; }

        /// <summary>
        /// Логин (на выбор: GET параметр или basic access authentication)
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// Пароль (на выбор: GET параметр или basic access authentication)
        /// </summary>
        public string Password { get; }
    }
}