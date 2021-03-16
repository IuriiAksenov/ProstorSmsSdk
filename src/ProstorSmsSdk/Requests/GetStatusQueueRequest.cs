using System;
using ProstorSmsSdk.Constants;
using ProstorSmsSdk.Responses;

namespace ProstorSmsSdk.Requests
{
    public class GetStatusQueueRequest : SmsApiRequest<GetStatusQueueResponse>
    {
        public GetStatusQueueRequest(string login, string password, int statusQueueLimit, string statusQueueName) :
            base(SmsApi.GetBalance, login, password)
        {
            if (string.IsNullOrEmpty(statusQueueName))
            {
                throw new Exception("statusQueueName can not be null or empty");
            }

            if (statusQueueLimit < 0 || statusQueueLimit > 1000)
            {
                throw new Exception("statusQueueLimit have to be between 1 and 1_000");
            }

            StatusQueueLimit = statusQueueLimit;
            StatusQueueName = statusQueueName;
        }

        /// <summary>
        /// Количество запрашиваемых статусов из очереди (по умолчанию 1, макс. 1000)
        /// </summary>
        public int StatusQueueLimit { get; }

        /// <summary>
        /// Название очереди статусов сообщений. Название очереди устанавливается при передаче сообщения
        /// </summary>
        public string StatusQueueName { get; }
    }
}