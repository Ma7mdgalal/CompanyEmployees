using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contracts
{
    public interface ILoggerService
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(Exception ex, string message, params object[] args);
        void LogDebug(string message, params object[] args);
    }
}
