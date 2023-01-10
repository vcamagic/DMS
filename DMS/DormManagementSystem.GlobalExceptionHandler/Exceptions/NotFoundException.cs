using System.Net;

namespace DormManagementSystem.GlobalExceptionHandler.Exceptions;

public class NotFoundException : HandleableException
{
    public NotFoundException(string errorMessage) : base(errorMessage)
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        ErrorMessage = errorMessage;
    }
}
