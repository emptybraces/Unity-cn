using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public static class cn
{
    static StringBuilder _sb;
    static Logger _logger;
    static List<Logger> _loggerCurrent;
    static Dictionary<string, float> _spanManageDict;
    public static int EditorFrameCount;
    const string DELIM = " ";
    const string COLOR_RED = "ff7777";
    const string COLOR_GREEN = "77ff77";
    const string COLOR_YELLOW = "ffff77";
    const string COLOR_BLUE = "4499ff";

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

    public sealed class PreventArg { };
    [Conditional("DEBUG")] public static void log(PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, "", path, line);
    [Conditional("DEBUG")] public static void log<T1>(T1 t1) => _LogFormattedT(LogType.Log, "", t1, "", "");
    [Conditional("DEBUG")] public static void log<T1, T2>(T1 t1, T2 t2) => _LogFormattedT(LogType.Log, "", t1, t2, "", "");
    [Conditional("DEBUG")] public static void log<T1, T2, T3>(T1 t1, T2 t2, T3 t3) => _LogFormattedT(LogType.Log, "", t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void log<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4) => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void log<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void log(params object[] args) => _LogFormattedT(LogType.Log, "", "", "", args);
    [Conditional("DEBUG")] public static void logf(PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Log, "", path, member);
    [Conditional("DEBUG")] public static void logf<T1>(T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, "", t1, path, member);
    [Conditional("DEBUG")] public static void logf<T1, T2>(T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, "", t1, t2, path, member);
    [Conditional("DEBUG")] public static void logf<T1, T2, T3>(T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, "", t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logf<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logf<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logSpan(float span, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, "", path, line, span);
    [Conditional("DEBUG")] public static void logSpan<T1>(float span, T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, "", t1, path, line, span);
    [Conditional("DEBUG")] public static void logSpan<T1, T2>(float span, T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, "", t1, t2, path, line, span);
    [Conditional("DEBUG")] public static void logSpan<T1, T2, T3>(float span, T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, "", t1, t2, t3, path, line, span);
    [Conditional("DEBUG")] public static void logSpan<T1, T2, T3, T4>(float span, T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, path, line, span);
    [Conditional("DEBUG")] public static void logSpan<T1, T2, T3, T4, T5>(float span, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, "", t1, t2, t3, t4, t5, path, line, span);

    [Conditional("DEBUG")] public static void logw(PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Warning, COLOR_YELLOW, path, line);
    [Conditional("DEBUG")] public static void logw<T1>(T1 t1) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, "", "");
    [Conditional("DEBUG")] public static void logw<T1, T2>(T1 t1, T2 t2) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, "", "");
    [Conditional("DEBUG")] public static void logw<T1, T2, T3>(T1 t1, T2 t2, T3 t3) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void logw<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void logw<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void logw(params object[] args) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, "", "", args);
    [Conditional("DEBUG")] public static void logwf(PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Warning, COLOR_YELLOW, path, member);
    [Conditional("DEBUG")] public static void logwf<T1>(T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, path, member);
    [Conditional("DEBUG")] public static void logwf<T1, T2>(T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, path, member);
    [Conditional("DEBUG")] public static void logwf<T1, T2, T3>(T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logwf<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logwf<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logwSpan(float span, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Warning, COLOR_YELLOW, path, line, span);
    [Conditional("DEBUG")] public static void logwSpan<T1>(float span, T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, path, line, span);
    [Conditional("DEBUG")] public static void logwSpan<T1, T2>(float span, T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, path, line, span);
    [Conditional("DEBUG")] public static void logwSpan<T1, T2, T3>(float span, T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, path, line, span);
    [Conditional("DEBUG")] public static void logwSpan<T1, T2, T3, T4>(float span, T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, path, line, span);
    [Conditional("DEBUG")] public static void logwSpan<T1, T2, T3, T4, T5>(float span, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Warning, COLOR_YELLOW, t1, t2, t3, t4, t5, path, line, span);

    [Conditional("DEBUG")] public static void loge(PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Error, COLOR_RED, path, line);
    [Conditional("DEBUG")] public static void loge<T1>(T1 t1) => _LogFormattedT(LogType.Error, COLOR_RED, t1, "", "");
    [Conditional("DEBUG")] public static void loge<T1, T2>(T1 t1, T2 t2) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, "", "");
    [Conditional("DEBUG")] public static void loge<T1, T2, T3>(T1 t1, T2 t2, T3 t3) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void loge<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void loge<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void loge(params object[] args) => _LogFormattedT(LogType.Error, COLOR_RED, "", "", args);
    [Conditional("DEBUG")] public static void logef(PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Error, COLOR_RED, path, member);
    [Conditional("DEBUG")] public static void logef<T1>(T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Error, COLOR_RED, t1, path, member);
    [Conditional("DEBUG")] public static void logef<T1, T2>(T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, path, member);
    [Conditional("DEBUG")] public static void logef<T1, T2, T3>(T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logef<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logef<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logeSpan(float span, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Error, COLOR_RED, path, line, span);
    [Conditional("DEBUG")] public static void logeSpan<T1>(float span, T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Error, COLOR_RED, t1, path, line, span);
    [Conditional("DEBUG")] public static void logeSpan<T1, T2>(float span, T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, path, line, span);
    [Conditional("DEBUG")] public static void logeSpan<T1, T2, T3>(float span, T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, path, line, span);
    [Conditional("DEBUG")] public static void logeSpan<T1, T2, T3, T4>(float span, T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, path, line, span);
    [Conditional("DEBUG")] public static void logeSpan<T1, T2, T3, T4, T5>(float span, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Error, COLOR_RED, t1, t2, t3, t4, t5, path, line, span);

    [Conditional("DEBUG")] public static void logBlue(PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, COLOR_BLUE, path, line);
    [Conditional("DEBUG")] public static void logBlue<T1>(T1 t1) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, "", "");
    [Conditional("DEBUG")] public static void logBlue<T1, T2>(T1 t1, T2 t2) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, "", "");
    [Conditional("DEBUG")] public static void logBlue<T1, T2, T3>(T1 t1, T2 t2, T3 t3) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void logBlue<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void logBlue<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void logBlue(params object[] args) => _LogFormattedT(LogType.Log, COLOR_BLUE, "", "", args);
    [Conditional("DEBUG")] public static void logBluef(PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Log, COLOR_BLUE, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1>(T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1, T2>(T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1, T2, T3>(T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logBluef<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logBlueSpan(float span, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, COLOR_BLUE, path, line, span);
    [Conditional("DEBUG")] public static void logBlueSpan<T1>(float span, T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, path, line, span);
    [Conditional("DEBUG")] public static void logBlueSpan<T1, T2>(float span, T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, path, line, span);
    [Conditional("DEBUG")] public static void logBlueSpan<T1, T2, T3>(float span, T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, path, line, span);
    [Conditional("DEBUG")] public static void logBlueSpan<T1, T2, T3, T4>(float span, T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, path, line, span);
    [Conditional("DEBUG")] public static void logBlueSpan<T1, T2, T3, T4, T5>(float span, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_BLUE, t1, t2, t3, t4, t5, path, line, span);

    [Conditional("DEBUG")] public static void logGreen(PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, COLOR_GREEN, path, line);
    [Conditional("DEBUG")] public static void logGreen<T1>(T1 t1) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, "", "");
    [Conditional("DEBUG")] public static void logGreen<T1, T2>(T1 t1, T2 t2) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, "", "");
    [Conditional("DEBUG")] public static void logGreen<T1, T2, T3>(T1 t1, T2 t2, T3 t3) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void logGreen<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void logGreen<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void logGreen(params object[] args) => _LogFormattedT(LogType.Log, COLOR_GREEN, "", "", args);
    [Conditional("DEBUG")] public static void logGreenf(PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Log, COLOR_GREEN, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1>(T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1, T2>(T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1, T2, T3>(T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logGreenf<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logGreenSpan(float span, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, COLOR_GREEN, path, line, span);
    [Conditional("DEBUG")] public static void logGreenSpan<T1>(float span, T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, path, line, span);
    [Conditional("DEBUG")] public static void logGreenSpan<T1, T2>(float span, T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, path, line, span);
    [Conditional("DEBUG")] public static void logGreenSpan<T1, T2, T3>(float span, T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, path, line, span);
    [Conditional("DEBUG")] public static void logGreenSpan<T1, T2, T3, T4>(float span, T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, path, line, span);
    [Conditional("DEBUG")] public static void logGreenSpan<T1, T2, T3, T4, T5>(float span, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_GREEN, t1, t2, t3, t4, t5, path, line, span);

    [Conditional("DEBUG")] public static void logRed(PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, COLOR_RED, path, line);
    [Conditional("DEBUG")] public static void logRed<T1>(T1 t1) => _LogFormattedT(LogType.Log, COLOR_RED, t1, "", "");
    [Conditional("DEBUG")] public static void logRed<T1, T2>(T1 t1, T2 t2) => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, "", "");
    [Conditional("DEBUG")] public static void logRed<T1, T2, T3>(T1 t1, T2 t2, T3 t3) => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void logRed<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4) => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void logRed<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void logRed(params object[] args) => _LogFormattedT(LogType.Log, COLOR_RED, "", "", args);
    [Conditional("DEBUG")] public static void logRedf(PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Log, COLOR_RED, path, member);
    [Conditional("DEBUG")] public static void logRedf<T1>(T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_RED, t1, path, member);
    [Conditional("DEBUG")] public static void logRedf<T1, T2>(T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, path, member);
    [Conditional("DEBUG")] public static void logRedf<T1, T2, T3>(T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logRedf<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logRedf<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logRedSpan(float span, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, COLOR_RED, path, line, span);
    [Conditional("DEBUG")] public static void logRedSpan<T1>(float span, T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_RED, t1, path, line, span);
    [Conditional("DEBUG")] public static void logRedSpan<T1, T2>(float span, T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, path, line, span);
    [Conditional("DEBUG")] public static void logRedSpan<T1, T2, T3>(float span, T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, t3, path, line, span);
    [Conditional("DEBUG")] public static void logRedSpan<T1, T2, T3, T4>(float span, T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, t3, t4, path, line, span);
    [Conditional("DEBUG")] public static void logRedSpan<T1, T2, T3, T4, T5>(float span, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, COLOR_RED, t1, t2, t3, t4, t5, path, line, span);

    [Conditional("DEBUG")] public static void logColored(PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, _MakeColorCode((uint)line), path, line);
    [Conditional("DEBUG")] public static void logColored<T1>(T1 t1) => _LogFormattedT(LogType.Log, _MakeColorCode(t1?.ToString()), t1, "", "");
    [Conditional("DEBUG")] public static void logColored<T1, T2>(T1 t1, T2 t2) => _LogFormattedT(LogType.Log, _MakeColorCode(t1?.ToString()), t1, t2, "", "");
    [Conditional("DEBUG")] public static void logColored<T1, T2, T3>(T1 t1, T2 t2, T3 t3) => _LogFormattedT(LogType.Log, _MakeColorCode(t1?.ToString()), t1, t2, t3, "", "");
    [Conditional("DEBUG")] public static void logColored<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4) => _LogFormattedT(LogType.Log, _MakeColorCode(t1?.ToString()), t1, t2, t3, t4, "", "");
    [Conditional("DEBUG")] public static void logColored<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) => _LogFormattedT(LogType.Log, _MakeColorCode(t1?.ToString()), t1, t2, t3, t4, t5, "", "");
    [Conditional("DEBUG")] public static void logColored(params object[] args) => _LogFormattedT(LogType.Log, _MakeColorCode(args[0]?.ToString()), "", "", args);
    [Conditional("DEBUG")] public static void logColoredf(PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormatted(LogType.Log, _MakeColorCode(path), path, member);
    [Conditional("DEBUG")] public static void logColoredf<T1>(T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, _MakeColorCode(path), t1, path, member);
    [Conditional("DEBUG")] public static void logColoredf<T1, T2>(T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, _MakeColorCode(path), t1, t2, path, member);
    [Conditional("DEBUG")] public static void logColoredf<T1, T2, T3>(T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, _MakeColorCode(path), t1, t2, t3, path, member);
    [Conditional("DEBUG")] public static void logColoredf<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, _MakeColorCode(path), t1, t2, t3, t4, path, member);
    [Conditional("DEBUG")] public static void logColoredf<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerMemberName] string member = "") => _LogFormattedT(LogType.Log, _MakeColorCode(path), t1, t2, t3, t4, t5, path, member);
    [Conditional("DEBUG")] public static void logColoredSpan(float span, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedLine(LogType.Log, _MakeColorCode(path), path, line, span);
    [Conditional("DEBUG")] public static void logColoredSpan<T1>(float span, T1 t1, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, _MakeColorCode(path), t1, path, line, span);
    [Conditional("DEBUG")] public static void logColoredSpan<T1, T2>(float span, T1 t1, T2 t2, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, _MakeColorCode(path), t1, t2, path, line, span);
    [Conditional("DEBUG")] public static void logColoredSpan<T1, T2, T3>(float span, T1 t1, T2 t2, T3 t3, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, _MakeColorCode(path), t1, t2, t3, path, line, span);
    [Conditional("DEBUG")] public static void logColoredSpan<T1, T2, T3, T4>(float span, T1 t1, T2 t2, T3 t3, T4 t4, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, _MakeColorCode(path), t1, t2, t3, t4, path, line, span);
    [Conditional("DEBUG")] public static void logColoredSpan<T1, T2, T3, T4, T5>(float span, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, PreventArg _ = null, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0) => _LogFormattedT(LogType.Log, _MakeColorCode(path), t1, t2, t3, t4, t5, path, line, span);

    static string _MakeColorCode(string s)
    {
        s ??= "null";
        return _MakeColorCode((byte)s.GetHashCode());
    }
    static string _MakeColorCode(uint n)
    {
        return ColorUtility.ToHtmlStringRGB(Color.HSVToRGB(n / 255f, 0.5f, 1f));
    }

    [Conditional("DEBUG")]
    static void _LogFormatted(LogType logType, string color, string filePath, string member)
    {
        _sb.Append("[").Append(GetFrameCount()).Append("] ");
        if (color != "") _sb.Append("<color=#").Append(color).Append(">");
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
        _sb.Append("[").Append(GetFrameCount()).Append("] ");
        if (color != "") _sb.Append("<color=#").Append(color).Append(">");
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
        _sb.Append("[").Append(GetFrameCount()).Append("] ");
        if (color != "") _sb.Append("<color=#").Append(color).Append(">");
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
        _sb.Append("[").Append(GetFrameCount()).Append("] ");
        if (color != "") _sb.Append("<color=#").Append(color).Append(">");
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
        _sb.Append("[").Append(GetFrameCount()).Append("] ");
        if (color != "") _sb.Append("<color=#").Append(color).Append(">");
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
        _sb.Append("[").Append(GetFrameCount()).Append("] ");
        if (color != "") _sb.Append("<color=#").Append(color).Append(">");
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
    static void _LogFormattedT(LogType logType, string color, string filePath, string member, params object[] args)
    {
        _sb.Append("[").Append(GetFrameCount()).Append("] ");
        if (color != "") _sb.Append("<color=#").Append(color).Append(">");
        if (filePath != "") _sb.Append(Path.GetFileName(filePath)).Append("#").Append(member).Append(": ");
        foreach (var i in args)
            _sb.Append(i?.ToString() ?? "null").Append(DELIM);
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1>(LogType logType, string color, T1 t1, string filePath, int lineNo, float span)
    {
        if (_TryPassSpanLog(filePath + lineNo, span)) _LogFormattedT(logType, color, t1, "", "");
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1, T2>(LogType logType, string color, T1 t1, T2 t2, string filePath, int lineNo, float span)
    {
        if (_TryPassSpanLog(filePath + lineNo, span)) _LogFormattedT(logType, color, t1, t2, "", "");
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1, T2, T3>(LogType logType, string color, T1 t1, T2 t2, T3 t3, string filePath, int lineNo, float span)
    {
        if (_TryPassSpanLog(filePath + lineNo, span)) _LogFormattedT(logType, color, t1, t2, t3, "", "");
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1, T2, T3, T4>(LogType logType, string color, T1 t1, T2 t2, T3 t3, T4 t4, string filePath, int lineNo, float span)
    {
        if (_TryPassSpanLog(filePath + lineNo, span)) _LogFormattedT(logType, color, t1, t2, t3, t4, "", "");
    }
    [Conditional("DEBUG")]
    static void _LogFormattedT<T1, T2, T3, T4, T5>(LogType logType, string color, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5, string filePath, int lineNo, float span)
    {
        if (_TryPassSpanLog(filePath + lineNo, span)) _LogFormattedT(logType, color, t1, t2, t3, t4, t5, "", "");
    }
    static bool _TryPassSpanLog(string key, float span)
    {
        _spanManageDict ??= new Dictionary<string, float>();
        if (_spanManageDict.TryGetValue(key, out var goal) && Time.unscaledTime < goal)
            return false;
        _spanManageDict[key] = Time.unscaledTime + span;
        return true;
    }

    [Conditional("DEBUG")]
    static void _LogFormattedLine(LogType logType, string color, string filePath, int lineNo)
    {
        _sb.Append("[").Append(GetFrameCount()).Append("] ");
        if (color != "") _sb.Append("<color=#").Append(color).Append(">");
        _sb.Append(Path.GetFileName(filePath)).Append("#").Append("LineNo=").Append(lineNo);
        if (color != "") _sb.Append("</color>");
        var s = _sb.ToString();
        foreach (var logger in _loggerCurrent)
            logger.Log(logType, s);
        _sb.Clear();
    }
    [Conditional("DEBUG")]
    static void _LogFormattedLine(LogType logType, string color, string filePath, int lineNo, float span)
    {
        var key = filePath + lineNo;
        _spanManageDict ??= new Dictionary<string, float>();
        if (_spanManageDict.TryGetValue(key, out var goal) && Time.unscaledTime < goal)
            return;
        _spanManageDict[key] = Time.unscaledTime + span;
        _LogFormattedLine(logType, color, filePath, lineNo);
    }

    [Conditional("DEBUG")]
    public static void logmem<T>(T obj, BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
    {
        if (obj == null)
            log("null");
        else
        {
            var type = typeof(T);
            _sb.Append("[").Append(GetFrameCount()).Append("] ");
            _sb.Append(type).AppendLine(", GetFields(): ");
            foreach (var i in type.GetFields(flags))
                _sb.Append(i.Name).Append("=").Append(i.GetValue(obj) ?? "null").Append(Environment.NewLine);
            _sb.AppendLine("GetProperties(): ");
            foreach (var i in type.GetProperties(flags))
            {
                try
                {
                    _sb.Append(i.Name).Append("=").Append(i.GetValue(obj) ?? "null").Append(Environment.NewLine);
                }
                catch
                {
                    // _sb.AppendLine(e.Message);
                }
            }
            var s = _sb.ToString();
            foreach (var logger in _loggerCurrent)
                logger.Log(LogType.Log, s);
            _sb.Clear();
        }
    }
    static int GetFrameCount() => Application.isPlaying ? Time.frameCount : EditorFrameCount;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void _DomainReset()
    {
        _sb = new StringBuilder(256);
        _logger = new Logger(UnityEngine.Debug.unityLogger);
        _loggerCurrent = new List<Logger>() { _logger };
    }
}
