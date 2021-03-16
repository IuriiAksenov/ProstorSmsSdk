namespace ProstorSmsSdk.Constants
{
    /// <summary>
    ///     Содержит константы для создания запросов к Sms API
    /// </summary>
    internal class SmsApi
    {
        public const string SendMessages = "send";
        public const string GetMessageStatuses = "status";

        public const string GetStatusQueue = "statusQueue";
        public const string GetBalance = "balance";
        public const string GetSenders = "senders";
        public const string GetVersion= "version";

        public const string Status = "status";
        public const string StatusQueue = "statusQueue";
        public const string Balance = "balance";
        public const string Senders = "senders";
        public const string Version = "version";

        public const string Json = "application/json";
        public const string ApiVersion = "v2";
        public const string ApiUrlRelease = "http://api.prostor-sms.ru/messages/" + ApiVersion + "/[0].json";
        public const string ApiUrlDebug = "http://localhost/";
    }
}