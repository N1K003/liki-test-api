using System;
using FluentValidation;
using Liki.BusinessLogic.Contracts.Models.DeliveryWindow;

namespace Liki.TestApi.Models.Request.DeliveryWindow
{
    public class CreateDeliveryWindowRequest
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

    public class CreateDeliveryWindowRequestValidator<T> : AbstractValidator<T> where T : CreateDeliveryWindowRequest
    {
        public CreateDeliveryWindowRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(x => x.Length >= 5)
                .WithMessage("Name is required and minimum length is 5");
            When(x => !string.IsNullOrWhiteSpace(x.Description), () =>
            {
                RuleFor(x => x.Description)
                    .Must(x => x.Length >= 10)
                    .WithMessage("Description minimum length is 10");
            });

            RuleFor(x => x.Start)
                .InclusiveBetween(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 59))
                .WithMessage("Start should be in range from 00:00:00 to 23:59:59");

            RuleFor(x => x.End)
                .GreaterThan(x => x.Start)
                .InclusiveBetween(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 59))
                .WithMessage("End should be in range from 00:00:00 to 23:59:59 and greater than start");

            RuleFor(x => x.AvailableByHoursBefore)
                .InclusiveBetween(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 59))
                .WithMessage("AvailableByHoursBefore should be in range from 00:00:00 to 23:59:59");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Price should be greater than -1");

            RuleFor(x => x.WindowType)
                .IsInEnum();
        }
    }
}