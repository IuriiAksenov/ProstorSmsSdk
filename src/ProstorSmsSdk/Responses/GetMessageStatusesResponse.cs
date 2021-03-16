using System;
using ProstorSmsSdk.Enums;

namespace ProstorSmsSdk.Responses
{
    public class GetMessageStatusesResponse : SmsApiResponse
    {
        public GetMessageStatusesResponse()
        {
            Messages = Array.Empty<MessageOfGetMessageStatusesResponse>();
        }

        public MessageOfGetMessageStatusesResponse[] Messages { get; set; }
    }

    public class MessageOfGetMessageStatusesResponse
    {
        /// <summary>
        ///     Статус отправленного сообщения (подробнее о статусах в описании REST интерфейса)
        /// </summary>
        public string Status { get; set; } = null!;

        /// <summary>
        ///     Id сообщения на стороне сервера (A-F 0-9, макс. 72 симв.)
        /// </summary>
        public string SmscId { get; set; } = null!;

        /// <summary>
        ///     Id сообщения на стороне клиента
        /// </summary>
        public Guid? ClientId { get; set; }

        public MessageDeliveredStatusType GetStatusType()
        {
            return MessageDeliveredStatusTypeConverter.FromString(Status);
        }
    }
}