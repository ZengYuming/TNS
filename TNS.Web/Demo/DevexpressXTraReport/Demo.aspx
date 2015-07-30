<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="TNS.Web.Demo.DevexpressXTraReport.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dexpress xtraReport Dome</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
    
        <asp:Button ID="btnSaveToRepx" runat="server" Text="将报表保存到(repx)文件" OnClick="btnSaveToRepx_Click" />
    
    </div>
    </form>
</body>
</html>
