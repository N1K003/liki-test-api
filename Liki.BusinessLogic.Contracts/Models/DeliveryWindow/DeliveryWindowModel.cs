using System;

namespace Liki.BusinessLogic.Contracts.Models.DeliveryWindow
{
    public class DeliveryWindowModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset End { get; set; }
        public decimal Price { get; set; }
        public DeliveryWindowType WindowType { get; set; }
        public bool IsAvailable { get; set; }
    }
}