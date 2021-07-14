<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="webapp._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btn" runat="server" Text="Call" OnClick="btn_Click" />
        </div>
        <div>
            <asp:Literal ID="litjson" runat="server" />
        </div>
    </form>
</body>
</html>
