using System;
using NLog;

namespace Utils
{
    public abstract class Log
    {
        private static readonly Logger Logger = LogManager.GetLogger("Logger");

        //Trace 0

        public static void Trace(string format, params object[] args)
        {
            Logger.Trace(format, args);
        }

        public static void TraceException(string message, Exception ex)
        {
            Logger.TraceException(message, ex);
        }

        //Debug 1

        public static void Debug(string format, params object[] args)
        {
            Logger.Debug(format, args);
        }

        public static void DebugException(string message, Exception ex)
        {
            Logger.DebugException(message, ex);
        }

        //Info  2

        public static void Info(string format, params object[] args)
        {
            Logger.Info(format, args);
        }

        public static void InfoException(string message, Exception ex)
        {
            Logger.InfoException(message, ex);
        }

        //Warn  3

        public static void Warn(string format, params object[] args)
        {
            Logger.Warn(format, args);
        }

        public static void WarnException(string message, Exception ex)
        {
            Logger.WarnException(message, ex);
        }

        //Error 4

        public static void Error(string format, params object[] args)
        {
            Logger.Error(format, args);
        }

        public static void ErrorException(string message, Exception ex)
        {
            Logger.ErrorException(message, ex);
        }

        //Fatal 5

        public static void Fatal(string format, params object[] args)
        {
            Logger.Fatal(format, args);
        }

        public static void FatalException(string message, Exception ex)
        {
            Logger.FatalException(message, ex);
        }
    }
}