using System.Net;

namespace DormManagementSystem.GlobalExceptionHandler.Exceptions;

public class BadRequestException : HandleableException
{
    public BadRequestException(string errorMessage) : base(errorMessage)
    {
        StatusCode = (int)HttpStatusCode.BadRequest;
        ErrorMessage = errorMessage;
    }
}
