using Navyki.Todo.Business.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navyki.Todo.Business.CustomLogger
{
    public class NLogLogger : ICustomLogger
    {
        public void LogError(string message)
        {
            var logger =LogManager.GetLogger("loggerFiles");
            logger.Log(LogLevel.Error, message);
        }
    }
}
