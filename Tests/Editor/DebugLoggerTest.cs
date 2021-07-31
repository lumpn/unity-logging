using NUnit.Framework;
using UnityEngine;
using Exception = System.Exception;

namespace Lumpn.Logging
{
    [TestFixture]
    public sealed class DebugLoggerTest
    {
        private static readonly object message = "Message";
        private static readonly Object context = null;
        private static readonly Exception exception = new Exception("Exception");
        private static readonly string format = "{0}, {1}";
        private static readonly object[] args = { 1, 2 };

        [SetUp]
        public void SetUp()
        {
            Debug.unityLogger.logEnabled = false;
        }

        [TearDown]
        public void TearDown()
        {
            Debug.unityLogger.logEnabled = true;
        }

        [Test]
        public void TestDebugLog()
        {
            Debug.Log(message);
            Debug.Log(message, context);

            Debug.LogWarning(message);
            Debug.LogWarning(message, context);

            Debug.LogError(message);
            Debug.LogError(message, context);

            Debug.LogException(exception);
            Debug.LogException(exception, context);

            Debug.LogAssertion(message);
            Debug.LogAssertion(message, context);
        }

        [Test]
        public void TestDebugLogFormat()
        {
            Debug.LogFormat(format, args);
            Debug.LogFormat(context, format, args);

            Debug.LogWarningFormat(format, args);
            Debug.LogWarningFormat(context, format, args);

            Debug.LogErrorFormat(format, args);
            Debug.LogErrorFormat(context, format, args);

            Debug.LogAssertionFormat(format, args);
            Debug.LogAssertionFormat(context, format, args);
        }

        [Test]
        public void TestLoggerLog()
        {
            var debug = ScriptableObject.CreateInstance<DebugLogger>();

            debug.Log(message);
            debug.Log(message, context);

            debug.LogWarning(message);
            debug.LogWarning(message, context);

            debug.LogError(message);
            debug.LogError(message, context);

            debug.LogException(exception);
            debug.LogException(exception, context);

            debug.LogAssertion(message);
            debug.LogAssertion(message, context);

            Object.DestroyImmediate(debug);
        }

        [Test]
        public void TestLoggerLogFormat()
        {
            var debug = ScriptableObject.CreateInstance<DebugLogger>();

            debug.LogFormat(format, args);
            debug.LogFormat(context, format, args);

            debug.LogWarningFormat(format, args);
            debug.LogWarningFormat(context, format, args);

            debug.LogErrorFormat(format, args);
            debug.LogErrorFormat(context, format, args);

            debug.LogAssertionFormat(format, args);
            debug.LogAssertionFormat(context, format, args);

            Object.DestroyImmediate(debug);
        }
    }
}
