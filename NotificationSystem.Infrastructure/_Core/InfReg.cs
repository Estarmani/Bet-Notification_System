using Microsoft.Extensions.DependencyInjection;
using NotificationSystem.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem.Infrastructure._Core
{
    public static class InfReg 
    {
        public static IServiceCollection AddCoreInf(this IServiceCollection services)
        {
            services.AddScoped<INotificationSystemContext, NotificationSystemContext>();
            return services;
        }
    }
}
