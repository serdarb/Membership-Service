using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Castle.Core.Logging;
using System.Reflection;
using System.Globalization;

namespace Membership.Application
{
    class ExceptionInterceptor : IInterceptor
    {
        private ILogger logger;
        public ILogger Logger
        {
            get
            {
                if (logger == null) logger = NullLogger.Instance;
                return logger;
            }
            set { logger = value; }
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Logger.Fatal(string.Format("Hata Oluştu : {0} || {1}", ex.Message, CreateInvocationLogString(invocation)));
            }
        }

        private string CreateInvocationLogString(IInvocation invocation)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Called: {0}.{1} (", invocation.TargetType.Name, invocation.Method.Name);
            foreach (var argument in invocation.Arguments)
            {
                string argumentDescription = argument == null ? "null" : GetPropertiesAndValues(argument);
                sb.Append(argumentDescription).Append(",");
            }
            if (invocation.Arguments.Count() > 0) sb.Length--;
            sb.Append(")");
            return sb.ToString();
        }

        private string GetPropertiesAndValues(object argument)
        {
            var str = new StringBuilder();
            var propertyInfos = argument.GetType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                str.AppendFormat(" P: {0} # V: {1} ", propertyInfo.Name, propertyInfo.GetValue(argument, null));
            }

            return str.ToString();
        }
    }
}
