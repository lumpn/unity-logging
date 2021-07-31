using UnityEngine;
using DebuggerHiddenAttribute = System.Diagnostics.DebuggerHiddenAttribute;
using Exception = System.Exception;

namespace Lumpn.Logging
{
    [CreateAssetMenu(menuName = "Data/Debug Logger")]
    public sealed class DebugLogger : ScriptableObject
    {
        [SerializeField] private string tag;
        [SerializeField] private LogType filterLogType = LogType.Log;

        private ILogger unityLogger => Debug.unityLogger;

        [DebuggerHidden]
        public void Log(object message, Object context = null)
        {
            Log(LogType.Log, message, context);
        }

        [DebuggerHidden]
        public void LogWarning(object message, Object context = null)
        {
            Log(LogType.Warning, message, context);
        }

        [DebuggerHidden]
        public void LogError(object message, Object context = null)
        {
            Log(LogType.Error, message, context);
        }

        [DebuggerHidden]
        public void LogException(Exception exception, Object context = null)
        {
            unityLogger.LogException(exception, context);
        }

        [DebuggerHidden]
        public void LogAssertion(object message, Object context = null)
        {
            Log(LogType.Assert, message, context);
        }

        [DebuggerHidden]
        public void LogFormat(string format, params object[] args)
        {
            LogFormat(LogType.Log, null, format, args);
        }

        [DebuggerHidden]
        public void LogFormat(Object context, string format, params object[] args)
        {
            LogFormat(LogType.Log, context, format, args);
        }

        [DebuggerHidden]
        public void LogWarningFormat(string format, params object[] args)
        {
            LogFormat(LogType.Warning, null, format, args);
        }

        [DebuggerHidden]
        public void LogWarningFormat(Object context, string format, params object[] args)
        {
            LogFormat(LogType.Warning, context, format, args);
        }

        [DebuggerHidden]
        public void LogErrorFormat(string format, params object[] args)
        {
            LogFormat(LogType.Error, null, format, args);
        }

        [DebuggerHidden]
        public void LogErrorFormat(Object context, string format, params object[] args)
        {
            LogFormat(LogType.Error, context, format, args);
        }

        [DebuggerHidden]
        public void LogAssertionFormat(string format, params object[] args)
        {
            LogFormat(LogType.Assert, null, format, args);
        }

        [DebuggerHidden]
        public void LogAssertionFormat(Object context, string format, params object[] args)
        {
            LogFormat(LogType.Assert, context, format, args);
        }

        [DebuggerHidden]
        private void Log(LogType logType, object message, Object context)
        {
            if (IsLogTypeAllowed(logType))
            {
                unityLogger.Log(logType, tag, message, context);
            }
        }

        [DebuggerHidden]
        private void LogFormat(LogType logType, Object context, string format, object[] args)
        {
            if (IsLogTypeAllowed(logType))
            {
                var message = string.Format(format, args);
                unityLogger.Log(logType, tag, message, context);
            }
        }

        private bool IsLogTypeAllowed(LogType logType)
        {
            if (logType == LogType.Exception)
            {
                return true;
            }
            if (filterLogType != LogType.Exception)
            {
                return logType <= filterLogType;
            }
            return false;
        }
    }
}
