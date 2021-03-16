using System;

namespace ProstorSmsSdk.Responses
{
    public class GetBalanceResponse : SmsApiResponse
    {
        public GetBalanceResponse()
        {
            Balance = Array.Empty<Balance>();
        }

        public Balance[] Balance { get; set; }
    }
}