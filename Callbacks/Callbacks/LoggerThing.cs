using log4net;
using log4net.Repository;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

namespace Callbacks
{
    interface ILogger
    {
        void LogError(Exception ex);
        void LogWarning(string ex) ;
        void LogInfo(string ex) ;
        void LogFatal(Exception ex) ;

    }
    public sealed class Logger : ILogger
    {
        #region Singleton Instantiation https://csharpindepth.com/articles/singleton version 4

        private static readonly Logger instance = new Logger();

        private ILog _logger = LogManager.GetLogger("root");

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Logger() { }

        public static Logger Instance
        {
            get { return instance; }
        }

        #endregion
        private Logger()
        {
            ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());

            var fileInfo = new FileInfo(@"log4net.config");

            log4net.Config.XmlConfigurator.Configure(repository, fileInfo);
        }
        public void LogError(Exception ex) 
        {
            try
            {
                _logger.Error(ex);
            }
            catch { }
        }
        public void LogWarning(string ex)
        {
            try
            {
                _logger.Warn(ex);
            }
            catch { }
        }
        public void LogFatal(Exception ex) 
        {
            try
            {
                _logger.Fatal(ex);
            }
            catch { }
        }
        public void LogInfo(string ex) 
        {
            try
            {
                _logger.Info(ex);
            }
            catch { }
        }
    }
}
