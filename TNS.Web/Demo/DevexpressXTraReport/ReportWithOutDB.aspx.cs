using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TNS.Web.Demo.DevexpressXTraReport
{
    public partial class ReportWithOutDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TNS.Web.Demo.DevexpressXTraReport.Report.ReportWithOutDB report = new TNS.Web.Demo.DevexpressXTraReport.Report.ReportWithOutDB();

            //string path = @"G:\ReportWithOutDB.repx";
            //    report.SaveLayout(path);
             
            

            TestDataSet dataSet = new TestDataSet();             
            DataRow row=dataSet.Weight.NewRow();
            
            row["CarNo"] = "4132";
            row["GrossWeight"] = 41;
            row["TareWeight"] = 143;
            row["SuttleWeight"] = 134;

            dataSet.Weight.Rows.Add(row);

            XtraReport xtraReport = null;
            if (dataSet != null)
            {
                xtraReport = XtraReport.FromFile(@"G:\ReportWithOutDB.repx", true);
                xtraReport.DataSource = dataSet;
            }
            xtraReport.CreateDocument();
            reportViewer1.Report = xtraReport;
            reportViewer1.DataBind();
        }

         
    }
}