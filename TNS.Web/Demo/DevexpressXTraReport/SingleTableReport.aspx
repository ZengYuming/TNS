<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleTableReport.aspx.cs" Inherits="TNS.Web.Demo.xtraReport.SingleTableReport" %>

<%@ Register Assembly="DevExpress.XtraReports.v12.1.Web, Version=12.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>单表 - 报表</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a>先用XtraReportWard向导设计报表，然后调用XtraReport的SaveLayout方法生成repx模板文件，然后给XtraReport对象的DataSource赋上对应的DataSet，就可以了</a><br />
            <dx:ReportToolbar ID="ReportToolbar1" runat="server" ShowDefaultButtons="False">
                <Items>
                    <dx:ReportToolbarButton ItemKind="Search" />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind="PrintReport" />
                    <dx:ReportToolbarButton ItemKind="PrintPage" />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton Enabled="False" ItemKind="FirstPage" />
                    <dx:ReportToolbarButton Enabled="False" ItemKind="PreviousPage" />
                    <dx:ReportToolbarLabel ItemKind="PageLabel" />
                    <dx:ReportToolbarComboBox ItemKind="PageNumber" Width="65px">
                    </dx:ReportToolbarComboBox>
                    <dx:ReportToolbarLabel ItemKind="OfLabel" />
                    <dx:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount" />
                    <dx:ReportToolbarButton ItemKind="NextPage" />
                    <dx:ReportToolbarButton ItemKind="LastPage" />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind="SaveToDisk" />
                    <dx:ReportToolbarButton ItemKind="SaveToWindow" />
                    <dx:ReportToolbarComboBox ItemKind="SaveFormat" Width="70px">
                        <Elements>
                            <dx:ListElement Value="pdf" />
                            <dx:ListElement Value="xls" />
                            <dx:ListElement Value="xlsx" />
                            <dx:ListElement Value="rtf" />
                            <dx:ListElement Value="mht" />
                            <dx:ListElement Value="html" />
                            <dx:ListElement Value="txt" />
                            <dx:ListElement Value="csv" />
                            <dx:ListElement Value="png" />
                        </Elements>
                    </dx:ReportToolbarComboBox>
                </Items>
                <Styles>
                    <LabelStyle>
                        <Margins MarginLeft='3px' MarginRight='3px' />
                    </LabelStyle>
                </Styles>
            </dx:ReportToolbar>
            <br />
            <dx:ReportViewer ID="reportViewer1" runat="server">
            </dx:ReportViewer>
        </div>
        
    </form>
</body>
</html>


<script type="text/javascript">
            //例如：在某按钮的点击事件中包括代码，onclick="PrintReportView(window,'ReportViewerYsqd');"

            //得到ReportView控件生成的客户端代码的报表内容区的FRAME对象
            //参数：objWindow——包含ReportView控件的window对象
            //      strReportViewerId——需要被打印的ReportViewer控件的ID
            //返回：得到的报表内容区FRAME对象；如果获取失败，返回null。
            function GetReportViewContentFrame(objWindow, strReportViewerId) {
                var frmContent = null;    //报表内容区对象的FRAME对象
                var strFrameId = "ReportFrame" + strReportViewerId;  //asp.net自动生成的iframe 的id为：ReportFrame+报表控件id
                try {
                    frmContent = window.frames[strFrameId].frames["report"];  //报表内容框架的id为report
                }
                catch (e) {
                }
                return frmContent;
            }

            //打印ReportView控件中的报表内容
            //参数：objWindow——包含ReportView控件的window对象
            //      strReportViewerId——需要被打印的ReportViewer控件的ID
            //返回：（无）
            function PrintReportView(objWindow, strReportViewerId) {
                var frmContent = GetReportViewContentFrame(objWindow, strReportViewerId);
                if (frmContent != null && frmContent != undefined) {
                    frmContent.focus();
                    frmContent.print();
                }
                else {
                    alert("在获取报表内容时失败，无法通过程序打印。如果要手工打印，请鼠标右键点击报表内容区域，然后选择菜单中的打印项。");
                }
            }
            function PrintReport() {
                PrintReportView(window, "reportViewer1");
                return false;
            }
        </script>