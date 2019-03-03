<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="sesDeneme.Web.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: #051119;
        }

        table {
            margin: auto;
            text-align: center;
            color: #fff;
            margin-top: -30px;
        }

            table tr {
                margin: 10px 10px;
                position: relative;
                height: 34px;
            }

        .btn-click {
            border-radius: 50% !important;
            font-size: 18px !important;
            width: 60px;
            height: 60px;
            margin-left: 25px;
        }

        .btn-click2 {
            font-size: 18px !important;
            width: 60px;
            height: 60px;
            margin-left: -60px;
            position: absolute;
            bottom: 4%;
            float: left;
        }

        table a {
            text-decoration: none;
            color: lightslategrey;
            font-weight: bold;
            font-size: 23px;
            padding: 5px 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnGeri" CssClass="btn btn-primary btn-lg btn-click" runat="server" Text="Geri" OnClick="btnGeri_Click" />
        <asp:Button ID="btnYeni" CssClass="btn btn-primary btn-lg btn-click2" runat="server" Text="Yeni" OnClick="btnYeni_Click" />

    </form>
    <asp:Table ID="Table1" runat="server"></asp:Table>
</body>
</html>
