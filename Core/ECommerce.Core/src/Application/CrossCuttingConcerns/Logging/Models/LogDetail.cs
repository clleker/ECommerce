namespace ECommerce.Core.Application.CrossCuttingConcerns.Logging.Models;

public class LogDetail
{
    /// <summary>
    /// MethodName
    /// </summary>
    public string MethodName { get; set; }

    /// <summary>
    /// User Email
    /// </summary>
    public string UserEmail { get; set; }  

    /// <summary>
    /// Method'a girilen parametreler
    /// </summary>
    public List<LogParameter> LogParameters { get; set; }
}