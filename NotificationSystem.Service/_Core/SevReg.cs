using Microsoft.Extensions.DependencyInjection;
using NotificationSystem.Contract;
using NotificationSystem.Contract._Core;
using NotificationSystem.Service;
using NotificationSystem.Utilities;
using NotificationSystem.Utilities._Core;


namespace NotificationSystem.Services._Core
{
    public static class SevReg
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<ISubscriberService, SubscriberService>();
            services.AddScoped<IValidatorHelper, ValidatorHelper>();
            services.AddScoped<IVoucherProdServices, VoucherProdServices>();
            return services;

        }
    }
}
