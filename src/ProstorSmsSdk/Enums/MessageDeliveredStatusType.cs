using System;

namespace ProstorSmsSdk.Enums
{
    public static class MessageDeliveredStatusTypeConverter
    {
        public static MessageDeliveredStatusType FromString(string status)
        {
            return status switch
            {
                "queued" => MessageDeliveredStatusType.Queued,
                "delivered" => MessageDeliveredStatusType.Delivered,
                "delivery error" => MessageDeliveredStatusType.DeliveryError,
                "smsc submit" => MessageDeliveredStatusType.SmscSubmit,
                "smsc reject" => MessageDeliveredStatusType.SmscReject,
                "incorrect id" => MessageDeliveredStatusType.IncorrectId,
                _ => throw new ArgumentOutOfRangeException($"{nameof(MessageDeliveredStatusType)} has no value: '{status}'")
            };
        }
    }

    public enum MessageDeliveredStatusType
    {
        /// <summary>
        ///     Сообщение находится в очереди
        /// </summary>
        Queued,

        /// <summary>
        ///     Сообщение доставлено
        /// </summary>
        Delivered,

        /// <summary>
        ///     Ошибка доставки SMS (абонент в течение времени доставки находился вне зоны действия сети или номер абонента
        ///     заблокирован)
        /// </summary>
        DeliveryError,

        /// <summary>
        ///     Сообщение доставлено в SMSC
        /// </summary>
        SmscSubmit,

        /// <summary>
        ///     Сообщение отвергнуто SMSC (номер заблокирован или не существует)
        /// </summary>
        SmscReject,

        /// <summary>
        ///     Неверный идентификатор сообщения
        /// </summary>
        IncorrectId
    }
}