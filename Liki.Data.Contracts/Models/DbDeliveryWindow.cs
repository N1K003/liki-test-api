using System;
using Liki.Data.Contracts.Abstractions;

namespace Liki.Data.Contracts.Models
{
    public class DbDeliveryWindow : BaseIdEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public decimal Price { get; set; }
        public int WindowType { get; set; }
        public TimeSpan AvailableByHoursBefore { get; set; }
        public bool IsAvailable { get; set; }
    }
}