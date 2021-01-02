using Castle.DynamicProxy;
using System;

namespace Nemovitosti.CompositionRoot.Aop
{
    public class LoggingAspect : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }

            catch (Exception exception)
            {
                throw exception;
            }


        }

    }
}
