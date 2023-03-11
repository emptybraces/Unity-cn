using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Diagnostics;
using UnityEngine;

public static class cn
{
    static StringBuilder _sb;
    static Logger _logger;
    static List<Logger> _loggerCurrent;
    const string DELIM = " ";
    const string COLOR_RED = "#ff7777";
    const string COLOR_GREEN = "#77ff77";
    const string COLOR_YELLOW = "#ffff77";
    const string COLOR_BLUE = "#4499ff";

#if DEBUG
    static cn()
    {
        _sb = new StringBuilder(256);
        _logger = new Logger(UnityEngine.Debug.unityLogger);
        _loggerCurrent = new List<Logger>() { _logger };
    }
#endif
    [Conditional("DEBUG")]
    public static void LogEnable(bool enabled)
    {
        foreach (var i in _loggerCurrent)
            i.logEnabled = enabled;
    }
    [Conditional("DEBUG")]
    public static void PushLogger(Logger logger)
    {
        _loggerCurrent.Add(logger);
    }
    [Conditional("DEBUG")]
    public static void PopLogger(Logger logger)
    {
        _loggerCurrent.Remove(logger);
    }
    [Conditional("DEBUG")]
    public static void PopLogger()
    {
        if (1 < _loggerCurrent.Count)
            _loggerCurrent.RemoveAt(_loggerCurrent.Count - 1);
    }

    public class DummyArg { };
    [Conditional("DEBUG")] public static void log(DummyArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, "", path, line);
    [Conditional("DEBUG")] public static void log<T1>(T1 t1) => _LogFormattedT(LogType.Log, "", t1, "", "");
    [Conditional("DEBUG")] public static void log<T1, T2>(T1 t1, T2 t2) => _LogFormattedT(LogType.Log, "", t1, t2, "", "");
    [Conditional("DEBUG")] public static void log<T1, T2, T3>(T1 t1, T2 t2, T3 t3) => _LogFormattedT(LogType.Log, "", t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void log<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4) => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void log<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void log<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6) => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, t5, t6, "", "");
    [Conditional("DEBUG")] public static void log<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7) => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, t5, t6, t7, "", "");
    [Conditional("DEBUG")] public static void log<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8) => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, t5, t6, t7, t8, "", "");

    [Conditional("DEBUG")] public static void logf(DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Log, "", path, member);
    [Conditional("DEBUG")] public static void logf<T1>(T1 t1, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT<T1>(LogType.Log, "", t1, path, member);
    [Conditional("DEBUG")] public static void logf<T1, T2>(T1 t1, T2 t2, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT<T1, T2>(LogType.Log, "", t1, t2, path, member);
    [Conditional("DEBUG")] public static void logf<T1, T2, T3>(T1 t1, T2 t2, T3 t3, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, "", t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logf<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logf<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logf<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, t5, t6, path, member);
    [Conditional("DEBUG")] public static void logf<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, t5, t6, t7, path, member);
    [Conditional("DEBUG")] public static void logf<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, t5, t6, t7, t8, path, member);

    [Conditional("DEBUG")] public static void logw(DummyArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Warning, COLOR_YELLOW, path, line);
    [Conditional("DEBUG")] public static void logw<T1>(T1 t1, DummyArg _ = null) => _LogFormattedT<T1>(LogType.Warning, COLOR_YELLOW, t1, "", "");
    [Conditional("DEBUG")] public static void logw<T1, T2>(T1 t1, T2 t2, DummyArg _ = null) => _LogFormattedT<T1, T2>(LogType.Warning, COLOR_YELLOW, t1, t2, "", "");
    [Conditional("DEBUG")] public static void logw<T1, T2, T3>(T1 t1, T2 t2, T3 t3, DummyArg _ = null) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void logw<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, DummyArg _ = null) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void logw<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, DummyArg _ = null) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void logw<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, DummyArg _ = null) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, t5, t6, "", "");
    [Conditional("DEBUG")] public static void logw<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, DummyArg _ = null) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, t5, t6, t7, "", "");
    [Conditional("DEBUG")] public static void logw<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, DummyArg _ = null) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, t5, t6, t7, t8, "", "");

    [Conditional("DEBUG")] public static void logwf(DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Warning, COLOR_YELLOW, path, member);
    [Conditional("DEBUG")] public static void logwf<T1>(T1 t1, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT<T1>(LogType.Warning, COLOR_YELLOW, t1, path, member);
    [Conditional("DEBUG")] public static void logwf<T1, T2>(T1 t1, T2 t2, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT<T1, T2>(LogType.Warning, COLOR_YELLOW, t1, t2, path, member);
    [Conditional("DEBUG")] public static void logwf<T1, T2, T3>(T1 t1, T2 t2, T3 t3, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logwf<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logwf<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logwf<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, t5, t6, path, member);
    [Conditional("DEBUG")] public static void logwf<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, t5, t6, t7, path, member);
    [Conditional("DEBUG")] public static void logwf<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, t5, t6, t7, t8, path, member);

    [Conditional("DEBUG")] public static void loge(DummyArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Error, COLOR_RED, path, line);
    [Conditional("DEBUG")] public static void loge<T1>(T1 t1, DummyArg _ = null) => _LogFormattedT<T1>(LogType.Error, COLOR_RED, t1, "", "");
    [Conditional("DEBUG")] public static void loge<T1, T2>(T1 t1, T2 t2, DummyArg _ = null) => _LogFormattedT<T1, T2>(LogType.Error, COLOR_RED, t1, t2, "", "");
    [Conditional("DEBUG")] public static void loge<T1, T2, T3>(T1 t1, T2 t2, T3 t3, DummyArg _ = null) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void loge<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, DummyArg _ = null) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void loge<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, DummyArg _ = null) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void loge<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, DummyArg _ = null) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, t5, t6, "", "");
    [Conditional("DEBUG")] public static void loge<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, DummyArg _ = null) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, t5, t6, t7, "", "");
    [Conditional("DEBUG")] public static void loge<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, DummyArg _ = null) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, t5, t6, t7, t8, "", "");

    [Conditional("DEBUG")] public static void logef(DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Error, COLOR_RED, path, member);
    [Conditional("DEBUG")] public static void logef<T1>(T1 t1, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT<T1>(LogType.Error, COLOR_RED, t1, path, member);
    [Conditional("DEBUG")] public static void logef<T1, T2>(T1 t1, T2 t2, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT<T1, T2>(LogType.Error, COLOR_RED, t1, t2, path, member);
    [Conditional("DEBUG")] public static void logef<T1, T2, T3>(T1 t1, T2 t2, T3 t3, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logef<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logef<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logef<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, t5, t6, path, member);
    [Conditional("DEBUG")] public static void logef<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, t5, t6, t7, path, member);
    [Conditional("DEBUG")] public static void logef<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, t5, t6, t7, t8, path, member);

    [Conditional("DEBUG")] public static void logBlue(DummyArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, COLOR_BLUE, path, line);
    [Conditional("DEBUG")] public static void logBlue<T1>(T1 t1, DummyArg _ = null) => _LogFormattedT<T1>(LogType.Log, COLOR_BLUE, t1, "", "");
    [Conditional("DEBUG")] public static void logBlue<T1, T2>(T1 t1, T2 t2, DummyArg _ = null) => _LogFormattedT<T1, T2>(LogType.Log, COLOR_BLUE, t1, t2, "", "");
    [Conditional("DEBUG")] public static void logBlue<T1, T2, T3>(T1 t1, T2 t2, T3 t3, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void logBlue<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void logBlue<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void logBlue<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, t5, t6, "", "");
    [Conditional("DEBUG")] public static void logBlue<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, t5, t6, t7, "", "");
    [Conditional("DEBUG")] public static void logBlue<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, t5, t6, t7, t8, "", "");


    [Conditional("DEBUG")] public static void logBluef(DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Log, COLOR_BLUE, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1>(T1 t1, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT<T1>(LogType.Log, COLOR_BLUE, t1, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1, T2>(T1 t1, T2 t2, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT<T1, T2>(LogType.Log, COLOR_BLUE, t1, t2, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1, T2, T3>(T1 t1, T2 t2, T3 t3, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, t5, t6, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, t5, t6, t7, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, t5, t6, t7, t8, path, member);

    [Conditional("DEBUG")] public static void logGreen(DummyArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, COLOR_GREEN, path, line);
    [Conditional("DEBUG")] public static void logGreen<T1>(T1 t1, DummyArg _ = null) => _LogFormattedT<T1>(LogType.Log, COLOR_GREEN, t1, "", "");
    [Conditional("DEBUG")] public static void logGreen<T1, T2>(T1 t1, T2 t2, DummyArg _ = null) => _LogFormattedT<T1, T2>(LogType.Log, COLOR_GREEN, t1, t2, "", "");
    [Conditional("DEBUG")] public static void logGreen<T1, T2, T3>(T1 t1, T2 t2, T3 t3, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void logGreen<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void logGreen<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void logGreen<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, t5, t6, "", "");
    [Conditional("DEBUG")] public static void logGreen<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, t5, t6, t7, "", "");
    [Conditional("DEBUG")] public static void logGreen<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, DummyArg _ = null) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, t5, t6, t7, t8, "", "");

    [Conditional("DEBUG")] public static void logGreenf(DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Log, COLOR_GREEN, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1>(T1 t1, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT<T1>(LogType.Log, COLOR_GREEN, t1, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1, T2>(T1 t1, T2 t2, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT<T1, T2>(LogType.Log, COLOR_GREEN, t1, t2, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1, T2, T3>(T1 t1, T2 t2, T3 t3, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1, T2, T3, T4, T5, T6>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, t5, t6, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1, T2, T3, T4, T5, T6, T7>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, t5, t6, t7, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1, T2, T3, T4, T5, T6, T7, T8>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, DummyArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, t5, t6, t7, t8, path, member);
    [Conditional("DEBUG")]
    static void _LogFormatted(LogType logType, string color, string filePath, string member)
    {
        _sb.Append("[").Append(Time.frameCount).Append("] ");
        if (color != "") _sb.Append("<color=").Append(color).Append(">");
        if (filePath != "") _sb.Append(Path.GetFileName(filePath)).Append("#").Append(member).Append(": ");
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1>(LogType logType, string color, T1 t1, string filePath, string member)
    {
        _sb.Append("[").Append(Time.frameCount).Append("] ");
        if (color != "") _sb.Append("<color=").Append(color).Append(">");
        if (filePath != "") _sb.Append(Path.GetFileName(filePath)).Append("#").Append(member).Append(": ");
        _sb.Append(t1?.ToString() ?? "null");
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1, T2>(LogType logType, string color, T1 t1, T2 t2, string filePath, string member)
    {
        _sb.Append("[").Append(Time.frameCount).Append("] ");
        if (color != "") _sb.Append("<color=").Append(color).Append(">");
        if (filePath != "") _sb.Append(Path.GetFileName(filePath)).Append("#").Append(member).Append(": ");
        _sb.Append(t1?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t2?.ToString() ?? "null");
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1, T2, T3>(LogType logType, string color, T1 t1, T2 t2, T3 t3, string filePath, string member)
    {
        _sb.Append("[").Append(Time.frameCount).Append("] ");
        if (color != "") _sb.Append("<color=").Append(color).Append(">");
        if (filePath != "") _sb.Append(Path.GetFileName(filePath)).Append("#").Append(member).Append(": ");
        _sb.Append(t1?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t2?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t3?.ToString() ?? "null");
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1, T2, T3, T4>(LogType logType, string color, T1 t1, T2 t2, T3 t3, T4 t4, string filePath, string member)
    {
        _sb.Append("[").Append(Time.frameCount).Append("] ");
        if (color != "") _sb.Append("<color=").Append(color).Append(">");
        if (filePath != "") _sb.Append(Path.GetFileName(filePath)).Append("#").Append(member).Append(": ");
        _sb.Append(t1?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t2?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t3?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t4?.ToString() ?? "null");
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1, T2, T3, T4, T5>(LogType logType, string color, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string filePath, string member)
    {
        _sb.Append("[").Append(Time.frameCount).Append("] ");
        if (color != "") _sb.Append("<color=").Append(color).Append(">");
        if (filePath != "") _sb.Append(Path.GetFileName(filePath)).Append("#").Append(member).Append(": ");
        _sb.Append(t1?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t2?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t3?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t4?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t5?.ToString() ?? "null");
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1, T2, T3, T4, T5, T6>(LogType logType, string color, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, string filePath, string member)
    {
        _sb.Append("[").Append(Time.frameCount).Append("] ");
        if (color != "") _sb.Append("<color=").Append(color).Append(">");
        if (filePath != "") _sb.Append(Path.GetFileName(filePath)).Append("#").Append(member).Append(": ");
        _sb.Append(t1?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t2?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t3?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t4?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t5?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t6?.ToString() ?? "null");
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1, T2, T3, T4, T5, T6, T7>(LogType logType, string color, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, string filePath, string member)
    {
        _sb.Append("[").Append(Time.frameCount).Append("] ");
        if (color != "") _sb.Append("<color=").Append(color).Append(">");
        if (filePath != "") _sb.Append(Path.GetFileName(filePath)).Append("#").Append(member).Append(": ");
        _sb.Append(t1?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t2?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t3?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t4?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t5?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t6?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t7?.ToString() ?? "null");
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1, T2, T3, T4, T5, T6, T7, T8>(LogType logType, string color, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, T6 t6, T7 t7, T8 t8, string filePath, string member)
    {
        _sb.Append("[").Append(Time.frameCount).Append("] ");
        if (color != "") _sb.Append("<color=").Append(color).Append(">");
        if (filePath != "") _sb.Append(Path.GetFileName(filePath)).Append("#").Append(member).Append(": ");
        _sb.Append(t1?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t2?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t3?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t4?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t5?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t6?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t7?.ToString() ?? "null").Append(DELIM);
        _sb.Append(t8?.ToString() ?? "null");
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    static void _LogFormattedLine(LogType logType, string color, string filePath, int lineNo)
    {
        _sb.Append("[").Append(Time.frameCount).Append("] ");
        if (color != "") _sb.Append("<color=").Append(color).Append(">");
        _sb.Append(Path.GetFileName(filePath)).Append("#").Append("LineNo=").Append(lineNo);
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    public static void logmem<T>(T obj, BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
    {
        if (obj == null)
            log("null");
        else
        {
            var type = typeof(T);
            _sb.Append("[").Append(Time.frameCount).Append("] ");
            foreach (var i in type.GetFields(flags))
                _sb.Append(i.Name).Append("=").Append(i.GetValue(obj) ?? "null").Append(Environment.NewLine);
            foreach (var i in type.GetProperties(flags))
            {
                try
                {
                    _sb.Append(i.Name).Append("=").Append(i.GetValue(obj) ?? "null").Append(Environment.NewLine);
                }
                catch
                {
                }
            }
            log(_sb.ToString());
            _sb.Clear();
        }
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void _DomainReset()
    {
        _sb = new StringBuilder(256);
        _logger = new Logger(UnityEngine.Debug.unityLogger);
        _loggerCurrent = new List<Logger>() { _logger };
    }
}
