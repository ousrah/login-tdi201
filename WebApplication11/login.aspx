<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication11.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>

        #login{
            width:400px;
            height:400px;
            margin:auto;
            margin-top:200px;
            border: solid 2px black;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div id="login">
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Login</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLogin" ErrorMessage="le login est obligatoire" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLogin" ErrorMessage="Le login doit être un email" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Mot de passe</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" ErrorMessage="le mot de passe ne peut pas être vide" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button ID="btnConnection" runat="server" Text="Connection" OnClick="btnConnection_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/inscription.aspx">Inscription</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:CheckBox ID="chkConnexion" runat="server" Text="Garder ma session ouverte" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:Label ID="lblErrConnection" runat="server" ForeColor="#FF3300" Text="Login ou mot de passe incorrect" Visible="False"></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="getMac" ValidationGroup="a" />
            </div>



        </div>
    </form>
</body>
</html>
