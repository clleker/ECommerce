using System;

using System.Transactions;
using Castle.DynamicProxy;
using ECommerce.Core.Utilities.Interceptors;

namespace ECommerce.Core.Application.CrossCuttingConcerns.Aspects.Transactions
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
