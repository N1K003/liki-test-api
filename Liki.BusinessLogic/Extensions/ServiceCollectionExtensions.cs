using Liki.BusinessLogic.Contracts.Services;
using Liki.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Liki.BusinessLogic.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            return services.AddTransient<IDeliveryWindowService, DeliveryWindowService>();
        }
    }
}