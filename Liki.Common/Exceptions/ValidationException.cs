using System.Collections.Generic;

namespace Liki.Common.Exceptions
{
    public class ValidationException : LikiException
    {
        public ValidationException(string message) : base(new[] {message}) { }
        public ValidationException(IEnumerable<string> messages) : base(messages) { }
    }
}