


using ECommerce.CoreApplication.CrossCuttingConcerns.Logging.Serilog;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace ECommerce.CoreApplication.ObjectDesign.Services
{
    public class ServiceResponseHelper : IServiceResponseHelper, IDisposable
    {
        private readonly LoggerServiceBase _logger;
        private bool isDisposed;

        public ServiceResponseHelper(LoggerServiceBase loggerServiceBase)
        {
            _logger = loggerServiceBase;
        }

        ~ServiceResponseHelper()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ServiceResponse<T> SetError<T>(T data, string errorMessage, int statusCode = StatusCodes.Status500InternalServerError, bool isLogging = false)
        {
            var error = new ErrorInfo(statusCode, errorMessage);

            if (isLogging)
            {
                _logger.Error(JsonConvert.SerializeObject(error));
            }

            return new ServiceResponse<T>(data, error);
        }

        public ServiceResponse SetError(string errorMessage, int statusCode = StatusCodes.Status500InternalServerError, bool isLogging = false)
        {
            var error = new ErrorInfo(statusCode, errorMessage);
          
            return this.SetError(error, isLogging);
        }

        public ServiceResponse SetError(ErrorInfo errorItem, bool isLogging = false)
        {
            if (isLogging)
            {
                _logger.Error(JsonConvert.SerializeObject(errorItem));
            }

            return new ServiceResponse(errorItem);
        }

        public ServiceResponse<T> SetError<T>(T data, ErrorInfo errorInfo, bool isLogging = false)
        {
            if (isLogging)
            {
                _logger.Error(JsonConvert.SerializeObject(errorInfo));
            }

            return new ServiceResponse<T>(data, errorInfo);
        }

        public ServiceResponse SetSuccess()
        {
            return new ServiceResponse();
        }

        public ServiceResponse<T> SetSuccess<T>(T data)
        {
            return new ServiceResponse<T>(data);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.isDisposed)
            {
                return;
            }

            this.isDisposed = true;

            if (disposing && _logger is IDisposable disposableInternalServiceProvider)
            {
                disposableInternalServiceProvider?.Dispose();
            }
        }
    }
}
