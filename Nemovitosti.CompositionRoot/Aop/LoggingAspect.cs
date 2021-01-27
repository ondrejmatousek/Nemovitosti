using Castle.DynamicProxy;
using NLog;
using System;
using System.Linq;

namespace Nemovitosti.CompositionRoot.Aop
{
    public class LoggingAspect : IInterceptor
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                ZalogujVyjimku(invocation, exception);
                throw exception;
            }
        }

        private void ZalogujVyjimku(IInvocation invocation, Exception exception)
        {
            string parametry = $"[{String.Join(",", invocation.Arguments.Select(arg => arg.ToString()))}]";
            logger.Error("Hodnoty parametru pred chybou: " + parametry, exception);
        }

    }
}
