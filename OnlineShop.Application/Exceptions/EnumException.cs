namespace OnlineShop.Application.Exceptions;

public class EnumException : Exception
{
    public EnumException() : base() {}

    public EnumException(string message) : base(message) { }

    public EnumException(string message, Exception inner) : base(message, inner) { }
}
