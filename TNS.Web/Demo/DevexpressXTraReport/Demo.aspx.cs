using System;
using System.IO;
using DevExpress.XtraReports.UI;
using TNS.Web.Demo.DevexpressXTraReport.Report;

namespace TNS.Web.Demo.DevexpressXTraReport
{
    public partial class Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaveToRepx_Click(object sender, EventArgs e)
        {

            XtraReport_SingleTable report = new XtraReport_SingleTable();
            Label1.Text = StoreReportToFile(report);
        }

        // Save a report to a file. 
        private string StoreReportToFile(XtraReport report)
        {
            try
            {
                string path = @"G:\1.job\DMS\TNS.Web\Demo\DevexpressXTraReport\Report\XtraReport-SingleTable.repx";
                report.SaveLayout(path);
                return path;
            }
            catch (IOException ioExpection)
            {
                return "出错了！" + ioExpection.Message;
            }
        }

        // Save a report to a stream. 
        private MemoryStream StoreReportToStream(XtraReport report)
        {
            MemoryStream stream = new MemoryStream();
            report.SaveLayout(stream);
            return stream;
        }
    }
}