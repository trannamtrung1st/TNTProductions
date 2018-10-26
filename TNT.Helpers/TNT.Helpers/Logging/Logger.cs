using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Helpers.Logging
{
    public enum LogMode
    {
        OneFile,
        ByDate,
        Console
    }

    public interface ILoggerAdapter
    {
        StringBuilder Buffer { get; set; }
        string LogFolder { get; set; }
        string LogName { get; set; }
        string FileExtension { get; set; }
        bool AutoDateHeader { get; set; }
        Action<ILoggerAdapter, Exception> ErrorHandler { get; set; }
        void Log(string content, bool push = false);
        void ClearBuffer();
    }

    interface ILoggerAdaptee
    {
        StringBuilder Buffer { get; set; }
        string LogFolder { get; set; }
        string LogName { get; set; }
        string FileExtension { get; set; }
        bool AutoDateHeader { get; set; }
        void Log(string content, bool push = false);
        void ClearBuffer();
    }

    abstract class BaseLogger : ILoggerAdaptee
    {
        public StringBuilder Buffer { get; set; }
        public virtual string LogName { get; set; }
        protected string logFolder;
        public virtual string LogFolder
        {
            get
            {
                return logFolder;
            }
            set
            {
                if (value != null)
                {
                    logFolder = value;
                    var lastSplash1 = value.LastIndexOf('/');
                    var lastSplash2 = value.LastIndexOf('\\');
                    var lastCharIdx = value.Length - 1;
                    var needSplash = lastSplash1 != lastCharIdx && lastSplash2 != lastCharIdx;
                    if (needSplash)
                    {
                        logFolder += "/";
                    }
                }
            }
        }

        public bool AutoDateHeader { get; set; } = true;

        public virtual string FileExtension { get; set; } = "txt";

        public void ClearBuffer()
        {
            Buffer = null;
        }

        public void Log(string content, bool push = false)
        {
            if (Buffer == null)
                Buffer = new StringBuilder("");
            Buffer.AppendLine(content);
            if (push)
            {
                PushLog();
            }
        }
        protected abstract void PushLog();
    }

    class OneFileLogger : BaseLogger
    {
        protected override void PushLog()
        {
            var path = LogFolder + LogName + "." + FileExtension;
            var content = "";
            if (AutoDateHeader)
                content += "------------- " + DateTime.Now + " -------------\r\n";
            content += Buffer.ToString();
            File.AppendAllText(path, content);
            Buffer = null;
        }
    }

    class ByDateLogger : BaseLogger
    {
        protected override void PushLog()
        {
            var path = LogFolder + LogName + DateTime.Now.ToString("_dd_MM_yyyy") + "." + FileExtension;
            var content = "";
            if (AutoDateHeader)
                content += "------------- " + DateTime.Now + " -------------\r\n";
            content += Buffer.ToString();
            File.AppendAllText(path, content);
            Buffer = null;
        }
    }

    class ConsoleLogger : BaseLogger
    {
        public override string LogName { get { return "Console mode"; } set { } }
        public override string LogFolder { get { return "Console mode"; } set { } }
        public override string FileExtension { get { return "Console mode"; } set { } }

        protected override void PushLog()
        {
            var content = "";
            if (AutoDateHeader)
                content += "------------- " + DateTime.Now + " -------------\r\n";
            content += Buffer.ToString();
            Console.Write(content);
            Buffer = null;
        }
    }

    public class LoggerBuilder
    {
        private ILoggerAdapter logger;
        public LoggerBuilder(LogMode mode = LogMode.Console)
        {
            switch (mode)
            {
                case LogMode.Console:
                    logger = new Logger(new ConsoleLogger());
                    break;
                case LogMode.OneFile:
                    logger = new Logger(new OneFileLogger());
                    break;
                case LogMode.ByDate:
                    logger = new Logger(new ByDateLogger());
                    break;
            }
        }

        public LoggerBuilder LogFolder(string folder)
        {
            logger.LogFolder = folder;
            return this;
        }
        public LoggerBuilder LogName(string name)
        {
            logger.LogName = name;
            return this;
        }
        public LoggerBuilder FileExtension(string extension)
        {
            logger.FileExtension = extension;
            return this;
        }
        public LoggerBuilder AutoDateHeader(bool auto)
        {
            logger.AutoDateHeader = auto;
            return this;
        }
        public LoggerBuilder ErrorHandler(Action<ILoggerAdapter, Exception> errHandler)
        {
            logger.ErrorHandler = errHandler;
            return this;
        }
        public ILoggerAdapter Build()
        {
            return logger;
        }
    }

    class Logger : ILoggerAdapter
    {
        private ILoggerAdaptee Adaptee { get; set; }
        public bool AutoDateHeader
        {
            get
            {
                return Adaptee.AutoDateHeader;
            }

            set
            {
                Adaptee.AutoDateHeader = value;
            }
        }

        public StringBuilder Buffer
        {
            get
            {
                return Adaptee.Buffer;
            }
            set
            {
                Adaptee.Buffer = value;
            }
        }

        public Action<ILoggerAdapter, Exception> ErrorHandler { get; set; }

        public string FileExtension
        {
            get
            {
                return Adaptee.FileExtension;
            }

            set
            {
                Adaptee.FileExtension = value;
            }
        }

        public string LogFolder
        {
            get
            {
                return Adaptee.LogFolder;
            }

            set
            {
                Adaptee.LogFolder = value;
            }
        }

        public string LogName
        {
            get
            {
                return Adaptee.LogName;
            }

            set
            {
                Adaptee.LogName = value;
            }
        }

        public void ClearBuffer()
        {
            Adaptee.ClearBuffer();
        }

        public void Log(string content, bool push = false)
        {
            try
            {
                Adaptee.Log(content, push);
            }
            catch (Exception e)
            {
                if (ErrorHandler != null)
                    ErrorHandler.Invoke(this, e);
            }
        }

        public Logger(ILoggerAdaptee adaptee)
        {
            Adaptee = adaptee;
        }
    }
}
