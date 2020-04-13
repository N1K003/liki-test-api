using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Liki.BusinessLogic.Contracts.Models.DeliveryWindow;
using Liki.BusinessLogic.Contracts.Services;
using Liki.TestApi.Infrastructure;
using Liki.TestApi.Models.Request.Common;
using Liki.TestApi.Models.Request.DeliveryWindow;
using Liki.TestApi.Models.Response;
using Liki.TestApi.Models.Response.DeliveryWindow;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Liki.TestApi.Controllers
{
    [Produces(Constants.DefaultMimeType)]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IDeliveryWindowService _deliveryWindowService;

        public WindowController(IDeliveryWindowService deliveryWindowService)
        {
            _deliveryWindowService = deliveryWindowService;
        }

        /// <summary>
        ///     Get available windows
        /// </summary>
        [HttpGet]
        [Route("api/windows/available")]
        [SwaggerResponse((int) HttpStatusCode.OK, Type = typeof(IEnumerable<DeliveryWindowResponse>))]
        public async Task<IActionResult> GetWindows([FromQuery] AvailableDeliveryWindowsRequest model)
        {
            var result = await _deliveryWindowService.GetDeliveryWindowsAsync(model.CurrentDate, model.Horizon, HttpContext.RequestAborted);

            return Ok(result.Select(x => x.ToResponse()));
        }

        /// <summary>
        ///     Get window rules
        /// </summary>
        [HttpGet]
        [Route("api/windows")]
        [SwaggerResponse((int) HttpStatusCode.OK, Type = typeof(IEnumerable<DeliveryWindowRule>))]
        public async Task<IActionResult> GetWindowRules()
        {
            var result = await _deliveryWindowService.GetDeliveryWindowRulesAsync(HttpContext.RequestAborted);

            return Ok(result.Select(x => x.ToResponse()));
        }

        /// <summary>
        ///     Create delivery window
        /// </summary>
        [HttpPost]
        [Route("api/windows")]
        public async Task<IActionResult> CreateWindow([FromBody] CreateDeliveryWindowRequest model)
        {
            await _deliveryWindowService.CreateDeliveryWindowAsync(new CreateDeliveryWindowModel
                {
                    Name = model.Name,
                    Description = model.Description,
                    Start = model.Start,
                    End = model.End,
                    Price = model.Price,
                    IsAvailable = model.IsAvailable,
                    WindowType = model.WindowType,
                    AvailableByHoursBefore = model.AvailableByHoursBefore
                },
                HttpContext.RequestAborted);

            return Ok();
        }

        /// <summary>
        ///     Update delivery window
        /// </summary>
        [HttpPut]
        [Route("api/windows/{id:int}")]
        public async Task<IActionResult> UpdateWindow([FromRoute] ByIdRequest idModel, [FromBody] UpdateDeliveryWindowRequest model)
        {
            await _deliveryWindowService.UpdateDeliveryWindowAsync(idModel.Id,
                new UpdateDeliveryWindowModel
                {
                    Name = model.Name,
                    Description = model.Description,
                    Start = model.Start,
                    End = model.End,
                    Price = model.Price,
                    IsAvailable = model.IsAvailable,
                    WindowType = model.WindowType,
                    AvailableByHoursBefore = model.AvailableByHoursBefore
                },
                HttpContext.RequestAborted);

            return Ok();
        }
    }
}