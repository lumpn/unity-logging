using NUnit.Framework;
using UnityEngine;
using Exception = System.Exception;

namespace Lumpn.Logging
{
    [TestFixture]
    public sealed class DebugLoggerTest
    {
        private static readonly object _message = "Message";
        private static readonly Object _context = null;
        private static readonly Exception _exception = new Exception("Exception");
        private static readonly string _format = "{0}, {1}";
        private static readonly object[] _args = { 1, 2 };

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
            Debug.Log(_message);
            Debug.Log(_message, _context);

            Debug.LogWarning(_message);
            Debug.LogWarning(_message, _context);

            Debug.LogError(_message);
            Debug.LogError(_message, _context);

            Debug.LogException(_exception);
            Debug.LogException(_exception, _context);

            Debug.LogAssertion(_message);
            Debug.LogAssertion(_message, _context);
        }

        [Test]
        public void TestDebugLogFormat()
        {
            Debug.LogFormat(_format, _args);
            Debug.LogFormat(_context, _format, _args);

            Debug.LogWarningFormat(_format, _args);
            Debug.LogWarningFormat(_context, _format, _args);

            Debug.LogErrorFormat(_format, _args);
            Debug.LogErrorFormat(_context, _format, _args);

            Debug.LogAssertionFormat(_format, _args);
            Debug.LogAssertionFormat(_context, _format, _args);
        }

        [Test]
        public void TestLoggerLog()
        {
            var debug = ScriptableObject.CreateInstance<DebugLogger>();

            debug.Log(_message);
            debug.Log(_message, _context);

            debug.LogWarning(_message);
            debug.LogWarning(_message, _context);

            debug.LogError(_message);
            debug.LogError(_message, _context);

            debug.LogException(_exception);
            debug.LogException(_exception, _context);

            debug.LogAssertion(_message);
            debug.LogAssertion(_message, _context);

            Object.DestroyImmediate(debug);
        }

        [Test]
        public void TestLoggerLogFormat()
        {
            var debug = ScriptableObject.CreateInstance<DebugLogger>();

            debug.LogFormat(_format, _args);
            debug.LogFormat(_context, _format, _args);

            debug.LogWarningFormat(_format, _args);
            debug.LogWarningFormat(_context, _format, _args);

            debug.LogErrorFormat(_format, _args);
            debug.LogErrorFormat(_context, _format, _args);

            debug.LogAssertionFormat(_format, _args);
            debug.LogAssertionFormat(_context, _format, _args);

            Object.DestroyImmediate(debug);
        }
    }
}
