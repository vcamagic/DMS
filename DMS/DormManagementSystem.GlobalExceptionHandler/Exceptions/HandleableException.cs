namespace DormManagementSystem.GlobalExceptionHandler.Exceptions;

public abstract class HandleableException : Exception
{
    public HandleableException(string errorMessage) : base(errorMessage)
    {
        
    }

    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; }
}
