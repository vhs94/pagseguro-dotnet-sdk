using Microsoft.Extensions.DependencyInjection;
using Pagseguro.Sdk.RecurringPayment.Application.Inteface;
using Pagseguro.Sdk.RecurringPayment.Application.Service;
using Pagseguro.Sdk.RecurringPayment.Domain.Entity;
using Pagseguro.Sdk.RecurringPayment.Domain.Interface;
using Pagseguro.Sdk.RecurringPayment.Infra.Helper;
using System;

namespace Pagseguro.Sdk.RecurringPayment.Infra.Configuration
{
    public static class Setup
    {
        public static void AddRecurringPayment(this IServiceCollection services, PagSeguroOptions options)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));


            services.Configure<PagSeguroOptions>(opt =>
            {
                opt.Email = options.Email;
                opt.SandboxMode = options.SandboxMode;
                opt.Token = options.Token;
                opt.SandboxBuyerEmail = options.SandboxBuyerEmail;
            });
            services.AddSingleton<IHttpHelper, HttpHelper>();
            services.AddScoped<IPagseguroPaymentMethodService, PagseguroPaymentMethodService>();
            services.AddScoped<IPagseguroPlanService, PagseguroPlanService>();
            services.AddScoped<IPagseguroSessionService, PagseguroSessionService>();
        }
    }
}
