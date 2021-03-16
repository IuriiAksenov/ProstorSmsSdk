using System;

namespace ProstorSmsSdk.Enums
{
    public static class SenderStatusTypeConverter
    {
        public static SendersStatusType FromString(string senderStatus)
        {
            if (!Enum.TryParse<SendersStatusType>(senderStatus, true, out var result))
            {
                throw new ArgumentOutOfRangeException($"{nameof(SendersStatusType)} has not value: '{senderStatus}'");
            }

            return result;
        }
    }

    public enum SendersStatusType
    {
        Default,
        Active,
        New,
        Pending,
        Blocked
    }
}