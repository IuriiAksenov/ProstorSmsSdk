using System;
using System.Collections.Generic;
using ProstorSmsSdk.Constants;
using ProstorSmsSdk.Responses;

namespace ProstorSmsSdk.Requests
{
    /// <summary>
    ///     Возвращает статус платежа
    /// </summary>
    public class GetMessageStatusesRequest : SmsApiRequest<GetMessageStatusesResponse>
    {
        public GetMessageStatusesRequest(string login, string password,
            IReadOnlyCollection<MessageOfGetMessageStatusesRequest> messages) : base(SmsApi.GetMessageStatuses, login,
            password)
        {
            if (messages.Count > 200)
            {
                throw new Exception("No more than 200 messages per request can be sent");
            }

            Messages = messages;
        }

        public IReadOnlyCollection<MessageOfGetMessageStatusesRequest> Messages { get; }
    }

    public class MessageOfGetMessageStatusesRequest
    {
        public MessageOfGetMessageStatusesRequest(string smscId, Guid? clientId = null)
        {
            SmscId = smscId;
            ClientId = clientId;
        }

        /// <summary>
        ///     Id сообщения на стороне сервера
        /// </summary>
        public string SmscId { get; }

        /// <summary>
        ///     Id сообщения на стороне клиента (A-Z 0-9, макс. 72 симв.)
        /// </summary>
        public Guid? ClientId { get; }
    }
}