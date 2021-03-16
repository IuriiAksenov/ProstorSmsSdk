using System;

namespace ProstorSmsSdk.Enums
{
    public static class MessageSendStatusTypeConverter
    {
        public static MessageSendStatusType FromString(string status)
        {
            return status switch
            {
                "accepted" => MessageSendStatusType.Accepted,
                "invalid mobile phone" => MessageSendStatusType.InvalidMobilePhone,
                "text is empty" => MessageSendStatusType.TextIsEmpty,
                "sender address invalid" => MessageSendStatusType.SenderAddresInvalid,
                "wapurl invalid" => MessageSendStatusType.WapurlInvalid,
                "invalid schedule time format" => MessageSendStatusType.InvalidScheduleTimeFormat,
                "invalid status queue name" => MessageSendStatusType.InvalidStatusQueueName,
                "not enough balance" => MessageSendStatusType.NotEnoughBalance,
                _ => throw new ArgumentOutOfRangeException($"{nameof(MessageSendStatusType)} has no value: '{status}'")
            };
        }
    }

    public enum MessageSendStatusType
    {
        /// <summary>
        ///     Сообщение принято сервисом
        /// </summary>
        Accepted,

        /// <summary>
        ///     Неверно задан номер тефона (формат +71234567890)
        /// </summary>
        InvalidMobilePhone,

        /// <summary>
        ///     Отсутствует текст
        /// </summary>
        TextIsEmpty,

        /// <summary>
        ///     Неверная (незарегистрированная) подпись отправителя
        /// </summary>
        SenderAddresInvalid,

        /// <summary>
        ///     Неправильный формат wap-push ссылки
        /// </summary>
        WapurlInvalid,

        /// <summary>
        ///     Неверный формат даты отложенной отправки сообщения
        /// </summary>
        InvalidScheduleTimeFormat,

        /// <summary>
        ///     Неверное название очереди статусов сообщений
        /// </summary>
        InvalidStatusQueueName,

        /// <summary>
        ///     Баланс пуст (проверьте баланс)
        /// </summary>
        NotEnoughBalance
    }
}