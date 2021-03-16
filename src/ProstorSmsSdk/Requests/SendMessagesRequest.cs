using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ProstorSmsSdk.Constants;
using ProstorSmsSdk.Responses;

namespace ProstorSmsSdk.Requests
{
    /// <summary>
    ///     Возвращает статус платежа
    /// </summary>
    public class SendMessagesRequest : SmsApiRequest<SendMessageResponse>
    {
        public SendMessagesRequest(string login, string password,
            IReadOnlyCollection<MessageOfSendMessageRequest> messages, DateTime? scheduleTime = null,
            string? statusQueueName = null, bool? showBillingDetails = null) : base(SmsApi.SendMessages, login,
            password)
        {
            if (messages.Count > 200)
            {
                throw new Exception("No more than 200 messages per request can be sent");
            }

            Messages = messages;
            ScheduleTime = scheduleTime;
            StatusQueueName = statusQueueName;
            ShowBillingDetails = showBillingDetails;
        }

        public IReadOnlyCollection<MessageOfSendMessageRequest> Messages { get; }

        /// <summary>
        ///     Дата для отложенной отправки сообщения, в UTC (2008-07-12T14:30:01Z)
        /// </summary>
        public DateTime? ScheduleTime { get; }

        /// <summary>
        ///     Название очереди статусов отправленных сообщений, в случае, если вы хотите использовать
        ///     очередь статусов отправленных сообщений.От 3 до 16 символов, буквы и цифры (например myQueue1)
        /// </summary>
        public string? StatusQueueName { get; }

        /// <summary>
        ///     Включение в ответ биллинговых данных: баланса, количества SMS в сообщении,  сообщения
        /// </summary>
        public bool? ShowBillingDetails { get; }
    }

    public class MessageOfSendMessageRequest
    {
        private const string PhonePattern = @"^7[\d]{10}";
        private const string PlusForApiRequirement = "+";
        private static readonly Regex Regex = new(PhonePattern);

        public MessageOfSendMessageRequest(string phone, string text, string? sender = null, Guid? clientId = null)
        {
            if (string.IsNullOrEmpty(phone) || Regex.IsMatch(phone))
            {
                throw new Exception($"Phone {phone} does not math pattern'{PhonePattern}'");
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("Text can not be null or empty");
            }

            Phone = PlusForApiRequirement + phone;
            Text = text;
            Sender = sender;
            ClientId = clientId;
        }

        /// <summary>
        ///     Номер телефона, в формате +71234567890
        /// </summary>
        public string Phone { get; }

        /// <summary>
        ///     Подпись отправителя (например TEST)
        /// </summary>
        public string? Sender { get; }

        /// <summary>
        ///     Id сообщения на стороне клиента (A-Z 0-9, макс. 72 симв.)
        /// </summary>
        public Guid? ClientId { get; }

        /// <summary>
        ///     Текст сообщения, в UTF-8 кодировке
        /// </summary>
        public string Text { get; }
    }
}