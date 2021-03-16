using ProstorSmsSdk.Constants;
using ProstorSmsSdk.Responses;

namespace ProstorSmsSdk.Requests
{
    public class GetSendersRequest : SmsApiRequest<GetSendersResponse>
    {
        public GetSendersRequest(string login, string password) : base(SmsApi.GetSenders, login, password)
        {
        }
    }
}