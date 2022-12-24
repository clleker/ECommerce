namespace ECommerce.CoreApplication.CrossCuttingConcerns.Logging.Models;

public class LogDetailWithException : LogDetail
{
    /// <summary>
    /// Exception Error
    /// </summary>
    public string ExceptionMessage { get; set; }
}