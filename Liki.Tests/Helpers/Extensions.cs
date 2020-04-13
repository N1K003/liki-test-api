using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Liki.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Liki.Tests.Helpers
{
    internal static class Extensions
    {
        public static async Task<T> SendAsync<T>(this HttpClient client, HttpRequestMessage request,
            CancellationToken cancellationToken = default)
        {
            var response = await client.SendAsync(request, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.ParseJsonResponseAsync<T>();
        }

        public static StringContent CreateJsonContext(this object model)
        {
            return new StringContent(model.SerializeToJson(), Encoding.UTF8, "application/json");
        }

        public static void RemoveService(this IServiceCollection services, Type serviceType)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == serviceType);

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }

        private static async Task<T> ParseJsonResponseAsync<T>(this HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent.DeserializeFromJson<T>();
        }
    }
}