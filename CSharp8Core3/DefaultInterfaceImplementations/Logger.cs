using System;

namespace DefaultInterfaceImplementations
{
    public interface ILogger
    {
        void Log(LogLevel level, string message);

        LogLevel DefaultLevel => LogLevel.Info;
        void Log(Exception e) => Log(DefaultLevel, e.Message);

    }

    #region A
    public class LoggerA : ILogger
    {
        public void Log(LogLevel level, string message) => Console.WriteLine(message);
    }

    #endregion


    #region B
    public class LoggerB : ILogger
    {
        public void Log(LogLevel level, string message) => Console.WriteLine(message);

        public void Log(Exception e) => Log(LogLevel.Error, e.Message);
        // public void Log(Exception e) => Log(DefaultLevel, e.Message); // Does not compile!: DefaultLevel can't be used.
    }
    #endregion


    #region Extend

    public interface ILoggerEx : ILogger
    {
        LogLevel ILogger.DefaultLevel => LogLevel.Warn;


        void LogExtended(string message) => LogPrivate(message);
        private void LogPrivate(string message) => Console.WriteLine(DefaultLevel);
    }

    #endregion


    public enum LogLevel
    {
        Info,
        Warn,
        Error
    }
}
