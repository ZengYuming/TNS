using System.Diagnostics;
using System.Windows.Forms;
using TNS.Win.Util;

namespace TNS.Upgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            Upgrade appUpdater = new Upgrade();
            string localXmlFile = @"G:\Job\DMS\TNS.Upgrade\Upgrader.xml";//Application.StartupPath + "\\AutoUpdater.xml";
            string serviceXmlFile = @"G:\Job\DMS\TNS.Win\Upgrader.xml";//Application.StartupPath + "\\AutoUpdater.xml";
            if (appUpdater.CheckUpdate(serviceXmlFile, localXmlFile))
            {
                if (MessageDxUtil.ShowYesNoAndTips("亲，新版本已为您备好.是否现在升级？") == DialogResult.Yes)
                {
                    //Update windows application.
                    appUpdater.Update();
                    MessageDxUtil.ShowTips("升级成功!");

                    //Run windows application in new process.
                    Process dmsProcess = new Process();
                    string fileName = Application.StartupPath + @"\TNS.Win.exe";
                    string arguments = "数据管理系统";
                    dmsProcess.StartInfo = new ProcessStartInfo(fileName, arguments);
                    dmsProcess.Start();

                    Application.Exit();
                }
            }
        }
    }
}
