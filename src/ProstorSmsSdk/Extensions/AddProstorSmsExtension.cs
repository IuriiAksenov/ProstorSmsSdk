using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProstorSmsSdk.Extensions
{
    public static class AddProstorSmsExtension
    {
        private const string SectionName = "ProstorSms";

        public static IServiceCollection AddProstorSms(this IServiceCollection services, string sectionName = SectionName)
        {
            if (services is null)
            {
                throw new ArgumentNullException($"{nameof(AddProstorSms)}: {nameof(services)} is null.");
            }

            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            var smsApiOptions = (configuration ?? throw new NullReferenceException("IConfiguration is null")).GetOptions<SmsApiOptions>(sectionName);
            services.AddSingleton(smsApiOptions);
            services.AddSingleton(new SmsApiClient(smsApiOptions.Login, smsApiOptions.Password));
            return services;
        }
    }
}