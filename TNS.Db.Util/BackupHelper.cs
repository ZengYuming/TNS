using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace TNS.Db.Util
{
    public class BackupHelper
    {
        public static void StartBackup(String directory)
        {
            using (Process process = new Process())
            {
                try
                {
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.WorkingDirectory = @"c:/";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();

                    //todo:need to replace actual path.
                    //note: Go to sepcil paht that contains mysqldump.exe file. 
                    process.StandardInput.WriteLine(@"cd C:/Program Files/MySQL/MySQL Server 5.6/bin");

                    string command = string.Format("mysqldump --quick --host=localhost --default-character-set=gbk --lock-tables --verbose  --force --port=3306 --user=root --password=123456 mysql -r  {0} ", directory);
                    process.StandardInput.WriteLine(command);
                    process.StandardInput.WriteLine("exit");
                }
                catch (Exception ex) { }
                finally
                {
                    process.Close();

                }
            }
        }
    }
}