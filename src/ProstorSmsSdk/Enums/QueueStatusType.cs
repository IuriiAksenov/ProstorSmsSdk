using System;

namespace ProstorSmsSdk.Enums
{
    public static class QueueStatusTypeConverter
    {
        public static QueueStatusType FromString(string status)
        {
            return status switch
            {
                "queue is empty" => QueueStatusType.QueueIsEmpty,
                "absent status queue name" => QueueStatusType.AbsentStatusQueueName,
                "invalid status queue name" => QueueStatusType.InvalidStatusQueueName,
                _ => throw new ArgumentOutOfRangeException($"{nameof(QueueStatusType)} has no value: '{status}'")
            };
        }
    }

    public enum QueueStatusType
    {
        /// <summary>
        ///     Очередь пуста
        /// </summary>
        QueueIsEmpty,

        /// <summary>
        ///     Не указано название очереди статусов сообщений
        /// </summary>
        AbsentStatusQueueName,

        /// <summary>
        ///     Неверно указано название очереди статусов сообщений
        /// </summary>
        InvalidStatusQueueName
    }
}