using System;
using ProstorSmsSdk.Enums;

namespace ProstorSmsSdk.Responses
{
    public class GetStatusQueueResponse : SmsApiResponse
    {
        public GetStatusQueueResponse()
        {
            Messages = Array.Empty<MessageOfGetMessageStatusesResponse>();
        }

        public MessageOfGetMessageStatusesResponse[] Messages { get; set; }
    }

    public class MessageOfGetStatusQueueResponse
    {
        /// <summary>
        ///     Статус отправленного сообщения (подробнее о статусах в описании REST интерфейса)
        /// </summary>
        public string Status { get; set; } = null!;

        /// <summary>
        ///     Id сообщения на стороне сервера (A-F 0-9, макс. 72 симв.)
        /// </summary>
        public string SmscId { get; set; } = null!;


        public QueueStatusType GetStatusType()
        {
            return QueueStatusTypeConverter.FromString(Status);
        }
    }
}