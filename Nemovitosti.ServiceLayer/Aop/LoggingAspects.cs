using Castle.DynamicProxy;
using System;

namespace Nemovitosti.ServiceLayer.Aop
{
    public class LoggingAspects : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }

            catch (Exception)
            {
                throw new Exception("V aplikaci došlo k chybě.");
            }
        }
    }
}
