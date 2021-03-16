namespace ProstorSmsSdk.Responses
{
    public class GetVersionResponse : SmsApiResponse
    {
        /// <summary>
        ///     Номер активной версии API
        /// </summary>
        public int Version { get; set; }
    }
}