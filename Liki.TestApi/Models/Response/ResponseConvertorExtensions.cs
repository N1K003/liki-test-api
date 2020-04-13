using System;
using Liki.BusinessLogic.Contracts.Models.DeliveryWindow;
using Liki.Common.Exceptions;
using Liki.TestApi.Models.Response.Common;
using Liki.TestApi.Models.Response.DeliveryWindow;

namespace Liki.TestApi.Models.Response
{
    public static class ResponseConvertorExtensions
    {
        public static ExceptionResponse ToResponse(this Exception model)
        {
            if (model is LikiException likiException)
            {
                return new ExceptionResponse {Errors = likiException.Errors};
            }

            return new ExceptionResponse {Errors = new[] {model.Message}};
        }

        public static DeliveryWindowResponse ToResponse(this DeliveryWindowModel model)
        {
            return new DeliveryWindowResponse
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Available = model.IsAvailable,
                Start = model.Start,
                Finish = model.End,
                Type = model.WindowType
            };
        }

        public static DeliveryWindowRuleResponse ToResponse(this DeliveryWindowRule model)
        {
            return new DeliveryWindowRuleResponse
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                IsAvailable = model.IsAvailable,
                AvailableByHoursBefore = model.AvailableByHoursBefore,
                Start = model.Start,
                End = model.End,
                Type = model.WindowType
            };
        }
    }
}