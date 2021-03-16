using System;
using ProstorSmsSdk.Enums;

namespace ProstorSmsSdk.Responses
{
    public class GetSendersResponse : SmsApiResponse
    {
        public GetSendersResponse()
        {
            Senders = Array.Empty<Sender>();
        }

        /// <summary>
        ///     Список доступных подписей
        /// </summary>
        public Sender[] Senders { get; set; }
    }

    public class Sender
    {
        public string Status { get; set; } = null!;

        public string Info { get; set; } = null!;

        public string Name { get; set; } = null!;

        public SendersStatusType GetStatusType()
        {
            return SenderStatusTypeConverter.FromString(Status);
        }
    }
}