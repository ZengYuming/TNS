using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using System.IO;
using System;

namespace TNS.Upgrade
{
    public class ZipUtil
    {
        private static FastZip fastZip = new FastZip();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipFileName"> Format : @"G:\2\Test.zip" </param>
        /// <param name="sourceDirectory"> Format : @"G:\xxx" </param>
        public static void CreateZip(string zipFileName, string sourceDirectory)
        {
            //如果文件没有找到，则报错
            if (!Directory.Exists(sourceDirectory))
            {
                throw new FileNotFoundException("The specified source path " + sourceDirectory + " could not be found. Create zip aborderd");
            }

            string[] filenames = Directory.GetFiles(sourceDirectory);


            fastZip.CreateZip(zipFileName, sourceDirectory, true, "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="zipFilePath"> Format : @"G:\xxx\Test.zip"</param>
        /// <param name="targetDirectory"></param>
        public static void ExtractZip(string zipFilePath, String targetDirectory)
        {
            //如果文件没有找到，则报错
            if (!File.Exists(zipFilePath))
            {
                throw new FileNotFoundException("The specified zip file path " + zipFilePath + " could not be found. ExtractZip aborderd");
            }
            fastZip.ExtractZip(zipFilePath, targetDirectory, "");
        }
    }
}
