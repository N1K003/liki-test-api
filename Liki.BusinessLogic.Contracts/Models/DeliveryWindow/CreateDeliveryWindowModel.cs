using System;

namespace Liki.BusinessLogic.Contracts.Models.DeliveryWindow
{
    public class CreateDeliveryWindowModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public decimal Price { get; set; }
        public DeliveryWindowType WindowType { get; set; }
        public TimeSpan AvailableByHoursBefore { get; set; }
        public bool IsAvailable { get; set; }
    }
}