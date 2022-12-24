using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace ECommerce.CoreApplication.CrossCuttingConcerns.Logging.Serilog
{
    public class MssqlLogger:LoggerServiceBase
    {
        private IConfiguration _configuration;
        public MssqlLogger(IConfiguration configuration)
        {
            _configuration = configuration;

            Logger = new LoggerConfiguration()
                    .WriteTo
                    .MSSqlServer(
          connectionString: _configuration["Data:MainDbContext:ConnectionString"],
          sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs", AutoCreateSqlTable = true },
          restrictedToMinimumLevel: LogEventLevel.Warning,
          columnOptions: new ColumnOptions()
          )
           .Enrich.FromLogContext()
           .CreateLogger();
        }
    }
}
