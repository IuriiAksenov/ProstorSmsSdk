using System;
using ProstorSmsSdk.Enums;

namespace ProstorSmsSdk.Responses
{
    public class SendMessageResponse : SmsApiResponse
    {
        public SendMessageResponse()
        {
            Balance = Array.Empty<Balance>();
            Messages = Array.Empty<MessageOfSendMessageResponse>();
        }

        /// <summary>
        ///     Остатки средств на балансе, после отправки сообщений
        /// </summary>
        public Balance[] Balance { get; set; }

        public MessageOfSendMessageResponse[] Messages { get; set; }
    }

    public class MessageOfSendMessageResponse
    {
        /// <summary>
        ///     Статус отправки сообщения (подробнее о статусах в описании REST интерфейса)
        /// </summary>
        public string Status { get; set; } = null!;

        /// <summary>
        ///     Id сообщения на стороне сервера (A-F 0-9, макс. 72 симв.)
        /// </summary>
        public string SmscId { get; set; } = null!;

        /// <summary>
        ///     Id сообщения на стороне клиента
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        ///     Количество SMS в сообщении
        /// </summary>
        public int? SmsCount { get; set; }

        /// <summary>
        ///     Стоимость сообщения (тариф умноженный на количество SMS). Отображается,
        ///     если клиент использует рублевый баланс
        /// </summary>
        public int? MsgCost { get; set; }

        public MessageSendStatusType GetStatusType()
        {
            return MessageSendStatusTypeConverter.FromString(Status);
        }
    }
}