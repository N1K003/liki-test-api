using System.Collections.Generic;

namespace Liki.TestApi.Models.Response.Common
{
    public class ExceptionResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}