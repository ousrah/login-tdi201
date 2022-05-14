<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inscription.aspx.cs" Inherits="WebApplication11.inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <style>

        #cadre{
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
        <div id="cadre">

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
                        <td>Nom</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtnom" runat="server"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtnom" ErrorMessage="le nom est obligatoire" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>Mot de passe</td>
                        <td>&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtpwd1" runat="server" TextMode="Password"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtpwd1" ErrorMessage="le mot de passe est obligatoire" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td >
                        &nbsp;Confirmer le&nbsp; mot de passe</td> <td >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td> <td >
                        &nbsp;<asp:TextBox ID="txtpwd2" runat="server" TextMode="Password"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtpwd2" ErrorMessage="la validation du mot de passe est obligatoire" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <br />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpwd1" ControlToValidate="txtpwd2" ErrorMessage="La validation du mot de passe est incorrecte" ForeColor="#FF3300"></asp:CompareValidator>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td> <td >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td> <td >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td >
                            &nbsp;</td> <td >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td> <td >
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnInscription" runat="server" Text="inscription" OnClick="btnInscription_Click" />
                            &nbsp;&nbsp;
                            </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblErrExist" runat="server" ForeColor="#FF3300" Text="cet email existe déjà, choisissez un autre" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;</td>
                    </tr>
                </table>
        </div>
    </form>
</body>
</html>
