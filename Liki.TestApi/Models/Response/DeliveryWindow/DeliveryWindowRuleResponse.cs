using System;
using Liki.BusinessLogic.Contracts.Models.DeliveryWindow;

namespace Liki.TestApi.Models.Response.DeliveryWindow
{
    public class DeliveryWindowRuleResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public decimal Price { get; set; }
        public DeliveryWindowType Type { get; set; }
        public bool IsAvailable { get; set; }
        public TimeSpan AvailableByHoursBefore { get; set; }
    }
}