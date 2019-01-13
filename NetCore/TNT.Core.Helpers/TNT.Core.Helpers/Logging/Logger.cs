using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT.Core.Helpers.Logging
{
    public enum LogMode
    {
        OneFile,
        FileByDate,
        Console
    }

    public interface ITLogger
    {
        StringBuilder Buffer { get; set; }
        string LogFolder { get; set; }
        string LogName { get; set; }
        string FileExtension { get; set; }
        bool AutoDateHeader { get; set; }
        Action<ITLogger, Exception> ErrorHandler { get; set; }
        void Log(string content);
        void LogBuffer(string content);
        void ClearBuffer();
    }

    abstract class BaseLogger : ITLogger
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
        public Action<ITLogger, Exception> ErrorHandler { get; set; }

        public void ClearBuffer()
        {
            Buffer = null;
        }

        public void Log(string content)
        {
            if (Buffer == null)
                Buffer = new StringBuilder("");
            Buffer.AppendLine(content);
            try
            {
                PushLog();
            }
            catch (Exception e)
            {
                ErrorHandler.Invoke(this, e);
            }
        }
        public void LogBuffer(string content)
        {
            if (Buffer == null)
                Buffer = new StringBuilder("");
            Buffer.AppendLine(content);
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
        private ITLogger logger;
        public LoggerBuilder(LogMode mode)
        {
            switch (mode)
            {
                case LogMode.Console:
                    logger = new ConsoleLogger();
                    break;
                case LogMode.OneFile:
                    logger = new OneFileLogger();
                    break;
                case LogMode.FileByDate:
                    logger = new ByDateLogger();
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
        public LoggerBuilder ErrorHandler(Action<ITLogger, Exception> errHandler)
        {
            logger.ErrorHandler = errHandler;
            return this;
        }
        public ITLogger Build()
        {
            return logger;
        }
    }

}
