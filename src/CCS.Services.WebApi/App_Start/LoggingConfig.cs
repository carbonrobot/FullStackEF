namespace CCS.Services.WebApi
{
    using Logging;
    using Logging.NLog;

    public static class LoggingConfig
    {
        public static void RegisterLogger()
        {
            Log.InitializeWith<NLogLog>();
        }
    }
}