using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProstorSmsSdk.Constants;
using ProstorSmsSdk.Requests;
using ProstorSmsSdk.Responses;

namespace ProstorSmsSdk
{
    public class SmsApiClient
    {
        private static readonly HttpClient HttpClient = new();

        private static readonly JsonSerializerSettings JsonSettings =
            new() {NullValueHandling = NullValueHandling.Ignore};

        private readonly string _login;
        private readonly string _password;

        public SmsApiClient(string login, string password)
        {
            _login = login;
            _password = password;
        }

        /// <summary>
        ///     Позволяет переключать SDK с тестового режима и обратно. По-умолчанию выключен
        /// </summary>
        public static bool IsDeveloperMode { get; set; }

        /// <summary>
        ///     Передача сообщения (до 200 сообщений в запросе)
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="scheduleTime">Дата для отложенной отправки сообщения, в UTC (2008-07-12T14:30:01Z)</param>
        /// <param name="statusQueueName">
        ///     Название очереди статусов отправленных сообщений, в случае, если вы хотите использовать
        ///     очередь статусов отправленных сообщений.От 3 до 16 символов, буквы и цифры (например myQueue1)
        /// </param>
        /// <param name="showBillingDetails">Включение в ответ биллинговых данных: баланса, количества SMS в сообщении,  сообщения</param>
        /// <returns></returns>
        public async Task<SendMessageResponse> SendMessagesAsync(
            IReadOnlyCollection<MessageOfSendMessageRequest> messages, DateTime? scheduleTime = null,
            string? statusQueueName = null, bool? showBillingDetails = null)
        {
            var request = new SendMessagesRequest(_login, _password, messages, scheduleTime, statusQueueName,
                showBillingDetails);
            return await SendRequestAsync<SendMessageResponse, SendMessagesRequest>(request);
        }

        /// <summary>
        ///     Проверка состояния отправленных сообщений (до 200 сообщений в запросе)
        /// </summary>
        /// <returns></returns>
        public async Task<GetMessageStatusesResponse> GetMessageStatusesAsync(
            IReadOnlyCollection<MessageOfGetMessageStatusesRequest> messages)
        {
            var request = new GetMessageStatusesRequest(_login, _password, messages);
            return await SendRequestAsync<GetMessageStatusesResponse, GetMessageStatusesRequest>(request);
        }

        /// <summary>
        ///     Проверка очереди статусов сообщений (до 1000 сообщений в запросе)
        /// </summary>
        /// <param name="statusQueueName">
        ///     Название очереди статусов сообщений. Название очереди устанавливается при передаче
        ///     сообщения
        /// </param>
        /// <param name="statusQueueLimit">Количество запрашиваемых статусов из очереди (по умолчанию 1, макс. 1000)</param>
        /// <returns></returns>
        public async Task<GetStatusQueueResponse> GetStatusQueueAsync(string statusQueueName, int statusQueueLimit)
        {
            var request = new GetStatusQueueRequest(_login, _password, statusQueueLimit, statusQueueName);
            return await SendRequestAsync<GetStatusQueueResponse, GetStatusQueueRequest>(request);
        }

        /// <summary>
        ///     Проверка состояния счета
        /// </summary>
        /// <returns></returns>
        public async Task<GetBalanceResponse> GetBalanceAsync()
        {
            var request = new GetBalanceRequest(_login, _password);
            return await SendRequestAsync<GetBalanceResponse, GetBalanceRequest>(request);
        }

        /// <summary>
        ///     Список доступных подписей отправителя
        /// </summary>
        /// <returns></returns>
        public async Task<GetSendersResponse> GetSendersAsync()
        {
            var request = new GetSendersRequest(_login, _password);
            return await SendRequestAsync<GetSendersResponse, GetSendersRequest>(request);
        }

        /// <summary>
        ///     Проверка активной версии API
        /// </summary>
        /// <returns></returns>
        public async Task<GetVersionResponse> GetVersionAsync()
        {
            var request = new GetVersionRequest(_login, _password);
            return await SendRequestAsync<GetVersionResponse, GetVersionRequest>(request);
        }

        private static async Task<TResponse> SendRequestAsync<TResponse, TRequest>(TRequest request)
            where TResponse : SmsApiResponse where TRequest : SmsApiRequest<TResponse>
        {
            var json = JsonConvert.SerializeObject(request, JsonSettings);
            var url = GetUrl(request.MethodApi);
            using var content = new StringContent(json, Encoding.UTF8, SmsApi.Json);
            var response = await HttpClient.PostAsync(url, content);
            var responseContent = response.Content;
            var body = await responseContent.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(body);
        }

        /// <summary>
        ///     Возвращает базовый Url для переданного названия метода запроса.
        ///     Зависит от режима работы SDK [AcquiringSdk.isDeveloperMode]
        /// </summary>
        private static string GetUrl(string apiMethod)
        {
            var url = IsDeveloperMode ? SmsApi.ApiUrlDebug : SmsApi.ApiUrlRelease;
            return url.Replace("[0]", apiMethod);
        }
    }
}