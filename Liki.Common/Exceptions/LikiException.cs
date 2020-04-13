using System;
using System.Collections.Generic;

namespace Liki.Common.Exceptions
{
    public class LikiException : Exception
    {
        public LikiException(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; }
    }
}