namespace ECommerce.Core.Application.CrossCuttingConcerns.Logging.Models;

public class LogParameter
{
    /// <summary>
    /// Property Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Property Value
    /// </summary>
    public object Value { get; set; }

    /// <summary>
    /// Property Variable Type
    /// </summary>
    public string Type { get; set; }
}