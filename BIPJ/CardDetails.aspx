<%@ Page Title="" Language="C#" MasterPageFile="~/Cards.Master" AutoEventWireup="true" CodeBehind="CardDetails.aspx.cs" Inherits="BIPJ.CardDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
<style type="text/css">

    @import url('https://fonts.googleapis.com/css2?family=PT+Sans:wght@400;700&display=swap');

    * {
        padding: 0;
        margin: 0;
    }

    .lblCardName {
        font-family: 'PT Sans', sans-serif;
        font-weight: bolder;
        font-size: 30px;
        top: 50px;
        margin-left: 60px;
        position: absolute;
    }

    .btnBack {
        top: 60px;
        margin-left: 850px;
        border-radius: 5px;
        border-color: none;
        width: 80px;
        height: 30px;
        position: absolute;
    }

    .ImgCard {
        margin-left: 58px;
        top: 120px;
        position: absolute;
        width: 320px;
        height: 180px;
        border-radius: 5px;
    }

    .lblTransactions {
        margin-left: 450px;
        top: 120px;
        position: absolute;
        font-family: 'PT Sans', sans-serif;
        font-size: 25px;
        font-weight: bold;
    }

    .lblTransactionsName {
        margin-left: 450px;
        top: 170px;
        position: absolute;
        font-family: 'PT Sans', sans-serif;
        font-size: 23px;
    }

    .lblTransactionsDate {
        margin-left: 450px;
        top: 200px;
        position: absolute;
        font-family: 'PT Sans', sans-serif;
        font-size: 23px;
    }

    .lblsign {
        margin-left: 800px;
        top: 200px;
        position: absolute;
        font-family: 'PT Sans', sans-serif;
        font-size: 23px;
    }

    .lblTransactionsAmt {
        margin-left: 860px;
        top: 200px;
        position: absolute;
        font-family: 'PT Sans', sans-serif;
        font-size: 23px;
    }

    .lblCardDetails {
        margin-left: 60px;
        top: 350px;
        position: absolute;
        font-family: 'PT Sans', sans-serif;
        font-size: 25px;
        font-weight: bold;
    }

    .lblBankName {
        margin-left: 130px;
        top: 410px;
        position: absolute;
        font-family: 'PT Sans', sans-serif;
        font-size: 25px;
        font-weight: bold;
    }

    .ImgBankName {
        margin-left: 58px;
        top: 400px;
        position: absolute;
        width: 60px;
        height: 55px;
        border-radius: 5px;
    }

    .hypViewMore {
        margin-left: 830px;
        top: 290px;
        position: absolute;
        font-family: 'PT Sans', sans-serif;
        font-size: 18px;
        text-decoration: none;
        color: blue;
    }


</style>
</header>

    <asp:Label ID="lblCardName" CssClass="lblCardName" runat="server" Text=""></asp:Label>

    <asp:Button ID="btnBack" CssClass="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"/>

    <asp:Image ID="ImgCard" runat="server" CssClass="ImgCard"/>

    <asp:Label runat="server" CssClass="lblTransactions" Text="Recent Transaction"></asp:Label>
    <asp:Label runat="server" ID="lblTransactionsName" CssClass="lblTransactionsName"></asp:Label>
    <asp:Label runat="server" ID="lblTransactionsDate" CssClass="lblTransactionsDate"></asp:Label>
    <asp:Label runat="server" Text="SGD $" CssClass="lblsign"></asp:Label>
    <asp:Label runat="server" ID="lblTransactionsAmt" CssClass="lblTransactionsAmt"></asp:Label>

   
    <asp:Label runat="server" CssClass="lblCardDetails" Text="Card Details"></asp:Label>
    <asp:Image ID="ImgBankName" runat="server" CssClass="ImgBankName"/>
    <asp:Label ID="lblBankName" runat="server" CssClass="lblBankName"></asp:Label>

</asp:Content>
