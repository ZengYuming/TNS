<%@ Page Title="DevExpress Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DevExpressReport.aspx.cs" Inherits="TNS.Web.Demo.DevExpressReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="DevExpress.XtraReports.v12.1.Web, Version=12.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>DevExpress Report</h3>
    <ol class="round">
        <li class="one">
            <h5>先用XtraReportWard向导设计报表</h5>
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Learn more…</a><br />
        </li>
        <li class="two">
            <h5>调用XtraReport的SaveLayout方法生成repx模板文件</h5>
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Learn more…</a>
        </li>
        <li class="three">
            <h5>给XtraReport对象的DataSource赋上对应的DataSet，就可以了</h5>
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Learn more…</a>
        </li>
    </ol>

    <dx:ReportToolbar ID="ReportToolbar1" runat='server' ShowDefaultButtons='False'>
        <Items>
            <dx:ReportToolbarButton ItemKind='PrintReport' />
            <dx:ReportToolbarSeparator />
            <dx:ReportToolbarButton Enabled='False' ItemKind='FirstPage' />
            <dx:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' />
            <dx:ReportToolbarLabel ItemKind='PageLabel' />
            <dx:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'></dx:ReportToolbarComboBox>
            <dx:ReportToolbarLabel ItemKind='OfLabel' />
            <dx:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
            <dx:ReportToolbarButton ItemKind='NextPage' />
            <dx:ReportToolbarButton ItemKind='LastPage' />
        </Items>
        <Styles>
            <LabelStyle>
                <Margins MarginLeft='3px' MarginRight='3px' />
            </LabelStyle>
        </Styles>
    </dx:ReportToolbar>
    <dx:ReportViewer ID="ReportViewer1" runat="server"></dx:ReportViewer>

    <script type="text/javascript">
        function printReportView() {
            var frmContent = null;    //报表内容区对象的FRAME对象           
            try {
                frmContent = window.frames["MainContent_ReportViewer1_ContentFrame"];  //报表内容框架的id为report
                if (frmContent != null && frmContent != undefined) {
                    frmContent.focus();
                    frmContent.print();
                }
                else {
                    alert("在获取报表内容时失败，无法通过程序打印。如果要手工打印，请鼠标右键点击报表内容区域，然后选择菜单中的打印项。");
                }
            }
            catch (e) {
            }
        }
        $(function () {
            $("#MainContent_ReportToolbar1_Menu_DXI0_I").click(printReportView);
        });
    </script>
</asp:Content>
