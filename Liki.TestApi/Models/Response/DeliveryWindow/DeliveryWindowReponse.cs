using System;
using Liki.BusinessLogic.Contracts.Models.DeliveryWindow;

namespace Liki.TestApi.Models.Response.DeliveryWindow
{
    public class DeliveryWindowResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Start { get; set; }
        public DateTimeOffset Finish { get; set; }
        public decimal Price { get; set; }
        public DeliveryWindowType Type { get; set; }
        public bool Available { get; set; }
    }
}