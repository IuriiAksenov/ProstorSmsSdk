using ProstorSmsSdk.Constants;
using ProstorSmsSdk.Responses;

namespace ProstorSmsSdk.Requests
{
    public class GetVersionRequest : SmsApiRequest<GetVersionResponse>
    {
        public GetVersionRequest(string login, string password) : base(SmsApi.GetVersion, login, password)
        {
        }
    }
}