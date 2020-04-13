using System.Linq;
using System.Threading.Tasks;
using Liki.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Liki.TestApi.Infrastructure.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var modelState = context.ModelState;

            if (!modelState.IsValid)
            {
                throw new ValidationException(modelState.Where(kvp => kvp.Value.Errors.Any())
                    .SelectMany(
                        x => x.Value.Errors.Select(e => string.IsNullOrEmpty(e.ErrorMessage) ? e.Exception.Message : e.ErrorMessage)));
            }

            await next();
        }
    }
}