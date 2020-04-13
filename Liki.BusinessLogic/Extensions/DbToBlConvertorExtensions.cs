using System;
using Liki.BusinessLogic.Contracts.Models.DeliveryWindow;
using Liki.Data.Contracts.Models;

namespace Liki.BusinessLogic.Extensions
{
    internal static class DbToBlConvertorExtensions
    {
        public static DeliveryWindowRule ToBlModel(this DbDeliveryWindow model)
        {
            return new DeliveryWindowRule
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Start = model.Start,
                End = model.End,
                Price = model.Price,
                WindowType = (DeliveryWindowType) model.WindowType,
                AvailableByHoursBefore = model.AvailableByHoursBefore,
                IsAvailable = model.IsAvailable
            };
        }

        public static DeliveryWindowModel ToBlModel(this DbDeliveryWindow model, DateTimeOffset fromDate)
        {
            return new DeliveryWindowModel
            {
                Name = model.Name,
                Description = model.Description,
                Start = fromDate.Date.Add(model.Start),
                End = fromDate.Date.Add(model.End),
                WindowType = (DeliveryWindowType) model.WindowType,
                Price = model.Price,
                IsAvailable = model.IsAvailable
            };
        }
    }
}