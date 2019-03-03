<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="Default.aspx.cs" Inherits="sesDeneme.Web.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .click-btns {
            /*margin-top :60px;*/
            text-align:center;
            /*margin-bottom:40px;*/
        }
        #btnSesKapa{
            margin-left : 8%;
        }
        .btn-click{
            border-radius:50%!important;
            font-size:18px!important;
            width:75px;
            height:75px;
        }
        .image-box
        {
                text-align: center;
                /*margin-top:20px;*/
                width: 100%;
                height: 100%;
                margin: 10px,10px,10px,10px;
                /*position: relative;
                display: block;*/
        }
        #btnYonlendir
        {
                float: right;
                bottom: 15%;
                position: absolute;
                z-index: 1;
                display: inline;
                right: 5vw;
        }
        #btnSesAc
        {
                float: right;
                bottom: 30%;
                position: absolute;
                z-index: 4;
                display: inline;
                right: 5vw;
        }
    </style>
</head>
<body style="background-color: #D4CCE1">
        <div class="click-btns">
            <form id="form1" runat="server">
                <asp:Button ID="btnSesAc" CssClass="btn btn-primary btn-lg btn-click" runat="server" Text="Başla" OnClick="btnSesAc_Click" BackColor="#464766" BorderColor="White" BorderStyle="None" />
                <asp:Button ID="btnSesKapa" CssClass="btn btn-primary btn-lg btn-click" runat="server" Text="Bitir" Visible="false" OnClick="btnSesKapa_Click" />
                <asp:Button ID="btnYonlendir" CssClass="btn btn-primary btn-lg btn-click" runat="server" Text="Ayarlar" OnClick="btnYonlendir_Click" BackColor="#464766" BorderColor="White" BorderStyle="None"/>


                <section class="image-box">
                    <asp:Image ID="imgdeneme"  runat="server"  ImageUrl="images/ah1.gif" CssClass="image-box" />
                 </section>
            </form>
        </div>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="scripts/jquery-3.0.0.min.js"></script>
</body>
</html>
