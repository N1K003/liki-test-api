namespace Liki.Common.Exceptions
{
    public class NotFoundException : LikiException
    {
        public NotFoundException(string message = default) : base(new[] {message}) { }
    }
}