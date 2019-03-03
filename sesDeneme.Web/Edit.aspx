<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="sesDeneme.Web.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
             background-color: #051119;
        }
        .tasiyici{
            margin:auto;
            text-align:center;
            color:#ffffff;
        }
        .Satir{
            margin:10px 0;
        }
        form{
            margin-top:50px;
        }
        #btnEdit{
            margin-top:22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="tasiyici">
            <div class="Satir">
                <asp:Label ID="lblCommand" runat="server">Command : </asp:Label>
                <asp:TextBox ID="txtCommand" runat="server"></asp:TextBox>
            </div>
            <div class="Satir">
                <asp:Label ID="lblResponse" runat="server">Response : </asp:Label>
                <asp:TextBox ID="txtResponse" runat="server"></asp:TextBox>
            </div>
            <div class="Satir">
                <asp:Label ID="lblAction" runat="server">Action : </asp:Label>
                <asp:TextBox ID="txtAction" runat="server"></asp:TextBox>
            </div>

            <asp:RadioButtonList ID="RadioButtonList1" CssClass="tasiyici" runat="server">
                <asp:ListItem Selected="True" Value="True">True</asp:ListItem>
                <asp:ListItem Value="False">False</asp:ListItem>
            </asp:RadioButtonList>
             <br />
            <asp:Label ID="lblControl" runat="server" Text="Label" OnLoad="Page_Load"></asp:Label>
            <br />
            <asp:Button ID="btnEdit" runat="server"  Text="Kayıt" OnClick="btnEdit_Click"/>
             <asp:Button ID="btnSil" Visible="false" runat="server"  Text="Sil" OnClick="btnSil_Click" />

        </div>
        
    </form>
</body>
</html>
