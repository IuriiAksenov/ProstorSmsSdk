using System.Threading.Tasks;
using Xunit;

namespace ProstorSmsSdk.UnitTests
{
    public class SmsApiClientTests
    {
        private readonly SmsApiClient _client;

        /// <summary>
        /// Работает только с официальными логином и паролем (более подробно в readme)
        /// </summary>
        public SmsApiClientTests()
        {
           // SmsApiClient.IsDeveloperMode = true;
            _client = new SmsApiClient(TestApiData.TestLogin, TestApiData.TestPassword);
        }

        [Fact]
        public async Task Get_a_balance_of_the_account()
        {
            var response = await _client.GetBalanceAsync();

            Assert.True(response.IsSuccess);
        }
    }
}