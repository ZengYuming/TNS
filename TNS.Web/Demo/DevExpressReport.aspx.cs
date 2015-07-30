using System;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Reporting;
using TNS.Db.TestDataService;
using System.Data;
using DevExpress.XtraReports.UI;

namespace TNS.Web.Demo
{
    public partial class DevExpressReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet personList = PersonService.GetDataSet();
            XtraReport xtraReport = null;
            if (personList != null)
            {
                xtraReport = XtraReport.FromFile(Server.MapPath("~") + @"Demo\DevexpressXTraReport\Report\XtraReport-SingleTable.repx", true);
                xtraReport.DataSource = personList;
            }
            xtraReport.CreateDocument();
            ReportViewer1.Report = xtraReport;
            ReportViewer1.DataBind();
        }
    }
}