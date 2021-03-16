using ProstorSmsSdk.Constants;
using ProstorSmsSdk.Responses;

namespace ProstorSmsSdk.Requests
{
    public class GetBalanceRequest : SmsApiRequest<GetBalanceResponse>
    {
        public GetBalanceRequest(string login, string password) : base(SmsApi.GetBalance, login, password)
        {
        }
    }
}