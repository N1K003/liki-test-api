﻿using System.Threading.Tasks;
using Liki.Common.Exceptions;
using Liki.TestApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Liki.TestApi.Controllers
{
    [Produces(Constants.DefaultMimeType)]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/error/404")]
        public Task<IActionResult> Error404()
        {
            throw new NotFoundException();
        }

        [Route("/error/{code:int}")]
        public Task<IActionResult> Error([FromRoute] int code)
        {
            _logger.LogWarning($"Error code {code} not handled.");
            throw new LikiException(new[] {$"Error {code} occured"});
        }
    }
}