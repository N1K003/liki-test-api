using System;
using FluentValidation;

namespace Liki.TestApi.Models.Request.DeliveryWindow
{
    public class AvailableDeliveryWindowsRequest
    {
        public DateTimeOffset CurrentDate { get; set; }
        public int Horizon { get; set; }
    }

    public class AvailableDeliveryWindowsRequestValidator : AbstractValidator<AvailableDeliveryWindowsRequest>
    {
        public AvailableDeliveryWindowsRequestValidator()
        {
            RuleFor(x => x.CurrentDate)
                .GreaterThanOrEqualTo(DateTime.Today.Date)
                .WithMessage("Current date should be not less than today");
            RuleFor(x => x.Horizon)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Horizon should be greater than -1");
        }
    }
}