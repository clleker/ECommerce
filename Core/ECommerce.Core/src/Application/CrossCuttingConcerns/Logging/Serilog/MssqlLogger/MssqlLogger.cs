using ECommerce.Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace ECommerce.Core.CrossCuttingConcerns.Logging.Serilog
{
    public class MssqlLogger:LoggerServiceBase
    {
        public MssqlLogger()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();

            Logger = new LoggerConfiguration()
                    .WriteTo
                    .MSSqlServer(
          connectionString: configuration["Data:MainDbContext:ConnectionString"],
          sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true },
          restrictedToMinimumLevel: LogEventLevel.Warning,
          columnOptions: new ColumnOptions())
           .Enrich.FromLogContext()
           .CreateLogger();
        }
    }
}
