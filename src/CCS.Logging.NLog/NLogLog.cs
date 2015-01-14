﻿namespace CCS.Logging.NLog
{
    using System;
    using global::NLog;
    using Logging;

    /// <summary>
    /// NLog implementation for Log
    /// </summary>
    public class NLogLog : ILog, ILog<NLogLog>
    {
        private Logger _logger;

        public void InitializeFor(string loggerName)
        {
            _logger = LogManager.GetLogger(loggerName);
        }

        public void Debug(string message, params object[] formatting)
        {
            if (_logger.IsDebugEnabled) _logger.Debug(message, formatting);
        }

        public void Debug(Func<string> message)
        {
            if (_logger.IsDebugEnabled) _logger.Debug(message());
        }

        public void Info(string message, params object[] formatting)
        {
            if (_logger.IsInfoEnabled) _logger.Info(message, formatting);
        }

        public void Info(Func<string> message)
        {
            if (_logger.IsInfoEnabled) _logger.Info(message());
        }

        public void Warn(string message, params object[] formatting)
        {
            if (_logger.IsWarnEnabled) _logger.Warn(message, formatting);
        }

        public void Warn(Func<string> message)
        {
            if (_logger.IsWarnEnabled) _logger.Warn(message());
        }

        public void Error(string message, params object[] formatting)
        {
            // don't check for enabled at this level
            _logger.Error(message, formatting);
        }

        public void Error(Func<string> message)
        {
            // don't check for enabled at this level
            _logger.Error(message());
        }

        public void Error(Func<string> message, Exception exception)
        {
            _logger.Error(message(), exception);
        }

        public void Fatal(string message, params object[] formatting)
        {
            // don't check for enabled at this level
            _logger.Fatal(message, formatting);
        }

        public void Fatal(Func<string> message)
        {
            // don't check for enabled at this level
            _logger.Fatal(message());
        }

        public void Fatal(Func<string> message, Exception exception)
        {
            _logger.Fatal(message(), exception);
        }
    }
}
