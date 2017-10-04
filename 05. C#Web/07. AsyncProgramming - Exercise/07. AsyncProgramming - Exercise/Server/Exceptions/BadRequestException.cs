using System;

public class BadRequestException : Exception
{
    private const string requestIsInvalid = "Request is invalid.";

    public static object ThrowFromInvalidRequest()
    {
        throw new BadRequestException(requestIsInvalid);
    }

    public BadRequestException(string message)
        : base(message)
    {
    }
}
