
using System.Reflection;
using Castle.DynamicProxy;
using ECommerce.Core.Application.CrossCuttingConcerns.Aspects;
using ECommerce.Core.CrossCuttingConcerns.Logging.Serilog;

namespace ECommerce.Core.Utilities.Interceptors;
    public class AspectInterceptorSelector:IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(MssqlLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
