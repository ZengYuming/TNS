using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections;
using System.ComponentModel;


namespace TNS.Upgrade
{
    /// <summary>
    /// updater 的摘要说明。
    /// </summary>
    public class Upgrade : IDisposable
    {
        #region 成员与字段属性
        private const string ZIP_FILE_NAME = "update.zip";
        private bool disposed = false;
        private IntPtr handle;
        private Component component = new Component();
        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);
        #endregion

        /// <summary>
        /// AppUpdater构造函数
        /// </summary>
        public Upgrade()
        {
            this.handle = handle;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {

                    component.Dispose();
                }
                CloseHandle(handle);
                handle = IntPtr.Zero;
            }
            disposed = true;
        }

        ~Upgrade()
        {
            Dispose(false);
        }

        public bool CheckUpdate(string serverXmlFile, string localXmlFile)
        {
            if (!File.Exists(localXmlFile) || !File.Exists(serverXmlFile))
            {
                return false;
                //TODO:Need to write log message.
            }

            XmlFiles serverXmlFiles = new XmlFiles(serverXmlFile);
            XmlFiles localXmlFiles = new XmlFiles(localXmlFile);

            string newVersion = serverXmlFiles.GetNodeValue("Upgrader/Version");
            string oldVersion = localXmlFiles.GetNodeValue("Upgrader/Version");

            return newVersion != oldVersion;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="downDirectory">G:/xxx/xxx</param>
        /// <param name="saveDirectory">G:/xxx/xxx</param>
        public void DownAutoUpdateFile(string downDirectory, string saveDirectory)
        {
            if (!System.IO.Directory.Exists(downDirectory))
            {
                //todo:log
            }
            string fileName = downDirectory + ZIP_FILE_NAME;

            try
            {
                WebRequest request = WebRequest.Create(downDirectory);
                WebResponse response = request.GetResponse();
                long contentLength = response.ContentLength;
                Stream st = response.GetResponseStream();
                byte[] byteLength = new byte[contentLength];
                int allByte = (int)contentLength;
                int startByte = 0;
                while (contentLength > 0)
                {
                    int downByte = st.Read(byteLength, startByte, allByte);
                    if (downByte == 0)
                    {
                        break;
                    }
                    startByte += downByte;

                    allByte -= downByte;
                }
                FileStream stream = new FileStream(downDirectory, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(byteLength, 0, byteLength.Length);
                stream.Close();
                response.Close();

            }
            catch (Exception ex)
            {
                //todo:
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverPath">G:\Client</param>
        /// <param name="clientPath">G:\Server\zipFileName.zip</param>
        /// <returns></returns>
        public bool Update()
        {
            bool flag = false;
            //DownAutoUpdateFile(@"G:/Lib.zip", @"G:/client");
            ZipUtil.ExtractZip(@"G:/client/" + ZIP_FILE_NAME, @"G:/client");
            File.Delete(@"G:/client/" + ZIP_FILE_NAME);
            return flag;
        }
    }
}
