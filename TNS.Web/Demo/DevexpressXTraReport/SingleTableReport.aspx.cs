using DevExpress.XtraReports.UI;
using TNS.DataService.Interface;
using TNS.Db;
using TNS.Db.TestDataService;
using Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace TNS.Web.Demo.xtraReport
{
    public partial class SingleTableReport : System.Web.UI.Page
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
            reportViewer1.Report = xtraReport;
            reportViewer1.DataBind();
        }

        public void InitializeControlValues() {
            if (!IsPostBack) { 
             
            }
        }
    }
}