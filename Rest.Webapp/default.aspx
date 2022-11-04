<%@ Page
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="default.aspx.cs"
    Inherits="Rest.Webapp._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Twilio Test</h1>
            <div>
                From: <asp:TextBox ID="txtPhone" runat="server" />
            </div>
            <div>
                To: <asp:TextBox ID="txtPhone1" runat="server" />
            </div>
            <div>
                <asp:Button ID="btnSubmit" runat="server"
                    Text="Submit"
                    OnClick="btnSubmit_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
