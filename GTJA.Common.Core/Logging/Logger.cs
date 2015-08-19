using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Config/Log4Net.config", Watch = true)]
namespace GTJA.Common.Core.Logging
{
    public static class Logger
    {
        private static ILog loger;

        static Logger()
        {
            loger = LogManager.GetLogger(typeof(Logger));
        }

        public static void Info(object msg)
        {
            loger.Info(msg);
        }
        public static void Error(object msg, Exception ex = null)
        {
            loger.Error(msg, ex);
        }
    }
}
