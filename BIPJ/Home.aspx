<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BIPJ.Home" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
<style type="text/css">
    @import url('https://fonts.googleapis.com/css2?family=PT+Sans:wght@400;700&display=swap');
    * {
            padding: 0;
            margin: 0;
    }
    #heading {
        font-family: 'PT Sans', sans-serif;
        font-weight: bolder;
        font-size: 30px;
        margin-top: -255px;
        margin-left: 60px;
    }
    #amount {
        font-family: 'PT Sans', sans-serif;
        font-size: 30px;
        margin-left: 60px;
        margin-bottom: 100px;
    }
    #summary_btn {
        margin-left: 60px;
        font-size: 30px;
        font-family: 'PT Sans', sans-serif;
        font-weight: normal;
    }
    #transactions_btn {
        margin-left: 50px;
        font-size: 30px;
        font-family: 'PT Sans', sans-serif;
        font-weight: normal;
    }
</style>
</header>
    <h2 id="heading">Total Spendings</h2>
    <p id="amount">SGD $</p>
    <a href="Cards.aspx" id="summary_btn">
        Summary
    </a>
    <a href="Cards.aspx" id="transactions_btn">
        Transactions
    </a>
</asp:Content>
