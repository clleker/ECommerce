namespace Core.CrossCuttingConcerns.Exceptions;

public class BusinessException : Exception
{
    //Business Expections
    public BusinessException(string message) : base(message)
    {

    }
}