<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestApplication.aspx.cs" Inherits="WebApplication11.TestApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Test des variables application</h1>
    <br />
    <br />
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ecrire" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Lire" />
&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <div>
        </div>
        <p>
            <asp:Button ID="Button3" runat="server" Text="Ecrire" OnClick="Button3_Click" />
        </p>
    </form>
</body>
</html>
