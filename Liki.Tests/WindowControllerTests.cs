using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Liki.BusinessLogic.Contracts.Models.DeliveryWindow;
using Liki.TestApi;
using Liki.TestApi.Models.Request.DeliveryWindow;
using Liki.TestApi.Models.Response.DeliveryWindow;
using Liki.Tests.Helpers;
using Xunit;

namespace Liki.Tests
{
    public class WindowControllerTests : IClassFixture<TestWebApplicationFactory<Startup>>
    {
        public WindowControllerTests(TestWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        private static HttpClient _client;


        [Fact]
        public async Task CanCreateDeliveryWindow()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/windows")
            {
                Content = new CreateDeliveryWindowRequest
                {
                    Name = "Test create window",
                    Description = "Test window description",
                    Start = new TimeSpan(9, 0, 0),
                    End = new TimeSpan(13, 0, 0),
                    AvailableByHoursBefore = new TimeSpan(3, 0, 0),
                    WindowType = DeliveryWindowType.Regular,
                    Price = 50,
                    IsAvailable = true
                }.CreateJsonContext()
            };

            var response = await _client.SendAsync(request, default(CancellationToken));

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task CanUpdateDeliveryWindow()
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "api/windows/1")
            {
                Content = new CreateDeliveryWindowRequest
                {
                    Name = "Test update window",
                    Description = "Test window description",
                    Start = new TimeSpan(9, 0, 0),
                    End = new TimeSpan(13, 0, 0),
                    AvailableByHoursBefore = new TimeSpan(3, 0, 0),
                    WindowType = DeliveryWindowType.Regular,
                    Price = 50,
                    IsAvailable = true
                }.CreateJsonContext()
            };

            var response = await _client.SendAsync(request, default(CancellationToken));

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task DailyDeliveryWindowsNotEmpty()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/windows/available?currentDate=2020-04-13T09:00:00&horizon=0");

            var response = await _client.SendAsync<IEnumerable<DeliveryWindowResponse>>(request);

            Assert.NotEmpty(response);
        }

        [Fact]
        public async Task DeliveryWindowRulesNotEmpty()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/windows");

            var response = await _client.SendAsync<IEnumerable<DeliveryWindowRuleResponse>>(request);

            Assert.NotEmpty(response);
        }

        [Fact]
        public async Task NightlyDeliveryWindowsNotEmpty()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/windows/available?currentDate=2020-04-13T23:59:59&horizon=0");

            var response = await _client.SendAsync<IEnumerable<DeliveryWindowResponse>>(request);

            Assert.Empty(response);
        }
    }
}