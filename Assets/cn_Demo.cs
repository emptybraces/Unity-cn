using System;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Mmm
{
	public class cn_Demo : MonoBehaviour
	{
		Logger _loggerFile;
		Logger _loggerUI;
		[SerializeField] Text _text;
		public class FileLogHandler : ILogHandler
		{
			static StringBuilder _sb;
			string _outputPath;
			public FileLogHandler(string outputPath)
			{
				_outputPath = outputPath;
				_sb ??= new StringBuilder(256);
				if (!Directory.Exists(Path.GetDirectoryName(outputPath)))
					Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
			}
			void _Write(string msg)
			{
				var now = DateTime.Now.ToShortTimeString();
				_sb.Append(now).Append(msg).Append(Environment.NewLine);
				File.AppendAllText(_outputPath, _sb.ToString());
				_sb.Clear();
			}
			public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
			{
				if (args != null && 0 < args.Length)
					_Write(args[0].ToString());
				else
					_Write("null");
			}
			public void LogException(Exception exception, UnityEngine.Object context)
			{
				_Write(exception.Message);
			}
		}
		public class UILogHandler : ILogHandler
		{
			static StringBuilder _sb;
			Text _text;
			public UILogHandler(Text text)
			{
				_text = text;
				_sb ??= new StringBuilder(256);
			}
			void _Write(string msg)
			{
				_sb.Append(msg).Append(Environment.NewLine);
				_text.text = _sb.ToString();
			}
			public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
			{
				if (args != null && 0 < args.Length)
					_Write(args[0].ToString());
				else
					_Write("null");
			}
			public void LogException(Exception exception, UnityEngine.Object context)
			{
				_Write(exception.Message);
			}
		}

		void Start()
		{
			cn.log();
			cn.log(this);
			cn.log("cn.log");
			cn.log("1", 2f, 3.0, 4d, 5, 6);
			cn.logf("1", "2", "3", "4");

			// %appdata%\..\LocalLow\*\*\log.txt

			_loggerUI ??= new Logger(new UILogHandler(_text));
			cn.PushLogger(_loggerUI);
			_loggerFile ??= new Logger(new FileLogHandler(Application.persistentDataPath + "/log.txt"));
			cn.PushLogger(_loggerFile);

			cn.logw();
			cn.logw(this);
			cn.logw("cn.logw");
			cn.logwf("1", "2", "3", "4");

			cn.loge();
			cn.loge(this);
			cn.loge("cn.loge");
			cn.logef("1", "2", "3", "4", Vector3.up);
			cn.PopLogger();

			cn.logBlue();
			cn.logBlue(this);
			cn.logBlue("logBlue");
			cn.logBluef("1", "2", "3", "4");

			cn.logGreen();
			cn.logGreen(this);
			cn.logGreen("logGreen");
			cn.logGreenf("1", "2", "3", "4", Vector3.up);

			cn.logRed();
			cn.logRed(this);
			cn.logRed("logRed");
			cn.logRedf("1", "2", "3", "4", Vector3.up);

			cn.logColored();
			cn.logColored("log", "test");
			cn.logColored("colorcolor");
			cn.logColored("colorcolorcolor");

			cn.logmem(Vector3.one);
			// cn.logmem(this, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.FlattenHierarchy);

			cn.LogEnable(false);
			cn.logGreen("not show");
			cn.LogEnable(true);
			cn.PopLogger();
		}

		void Update()
		{
			if (Input.anyKeyDown)
			{
				UnityEngine.Profiling.Profiler.BeginSample("#1");
				Start();
				UnityEngine.Profiling.Profiler.EndSample();
				UnityEditor.EditorApplication.isPaused = true;
			}
			cn.logSpan(1);
			cn.logwSpan(1);
			cn.logeSpan(1);
			cn.logBlueSpan(1);
			cn.logGreenSpan(1);
			cn.logRedSpan(1);
			cn.logColoredSpan(1);
			cn.logSpan(2, "log every 2sec");
			cn.logwSpan(2, "log every 2sec");
			cn.logeSpan(2, "log every 2sec");
			cn.logBlueSpan(2, "log every 2sec");
			cn.logGreenSpan(2, "log every 2sec");
			cn.logRedSpan(2, "log every 2sec");
			cn.logColoredSpan(2, "log every 2sec");
		}
	}
}

