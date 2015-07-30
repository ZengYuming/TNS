using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TNF.Util.Log
{
    public class Logger
    {
        public static void WriteException(Exception ex)
        {
            try
            {
                string text = AppDomain.CurrentDomain.BaseDirectory + "Log\\";
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                string path = string.Format("{0}\\TZLog-{1}.txt", text, DateTime.Now.ToString("yyyyMMdd"));
                StreamWriter streamWriter = new StreamWriter(path, true, Encoding.UTF8);
                streamWriter.WriteLine("Log Time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                streamWriter.WriteLine(string.Format("Message Source : {0}", ex.Source));
                streamWriter.WriteLine(string.Format("Message : {0}", ex.Message));
                streamWriter.WriteLine(string.Format("Stack Trace : {0}", ex.StackTrace));
                if (ex.InnerException != null)
                {
                    streamWriter.WriteLine(string.Format("Message : {0}", ex.InnerException.Message));
                    streamWriter.WriteLine(string.Format("Inner Stack Trace : {0}", ex.InnerException.StackTrace));
                }
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch
            {
            }
        }
        public static void WriteException(Exception ex, string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string path2 = string.Format("{0}\\TZLog-{1}.txt", path, DateTime.Now.ToString("yyyyMMdd"));
                StreamWriter streamWriter = new StreamWriter(path2, true, Encoding.UTF8);
                streamWriter.WriteLine("Log Time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                streamWriter.WriteLine(string.Format("Message Source : {0}", ex.Source));
                streamWriter.WriteLine(string.Format("Message : {0}", ex.Message));
                streamWriter.WriteLine(string.Format("Stack Trace : {0}", ex.StackTrace));
                if (ex.InnerException != null)
                {
                    streamWriter.WriteLine(string.Format("Message : {0}", ex.InnerException.Message));
                    streamWriter.WriteLine(string.Format("Inner Stack Trace : {0}", ex.InnerException.StackTrace));
                }
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch
            {
            }
        }
        public static void Write(string message, string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string path2 = string.Format("{0}\\TZLog-{1}.txt", path, DateTime.Now.ToString("yyyyMMdd"));
                StreamWriter streamWriter = new StreamWriter(path2, true, Encoding.UTF8);
                streamWriter.WriteLine("Time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                string[] array = message.Split(new char[]
				{
					'|'
				});
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string value = array2[i];
                    streamWriter.WriteLine(value);
                }
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch
            {
            }
        }
        public static void Write(string message)
        {
            try
            {
                string text = AppDomain.CurrentDomain.BaseDirectory + "Log\\";
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                string path = string.Format("{0}\\TZLog-{1}.txt", text, DateTime.Now.ToString("yyyyMMdd"));
                StreamWriter streamWriter = new StreamWriter(path, true, Encoding.UTF8);
                streamWriter.WriteLine("Time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                string[] array = message.Split(new char[]
				{
					'|'
				});
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string value = array2[i];
                    streamWriter.WriteLine(value);
                }
                streamWriter.Flush();
                streamWriter.Close();
            }
            catch
            {
            }
        }
    }
}
