using System;
namespace WingsOfLiberty.Infrastructure.Logging
{
    public interface INLogger
    {
        void LogDebug(string message);
        void LogError(Exception x);
        void LogError(string message);
        void LogFatal(Exception x);
        void LogFatal(string message);
        void LogInfo(string message);
        void LogWarning(string message);
    }
}
