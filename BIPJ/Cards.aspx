<%@ Page Title="" Language="C#" MasterPageFile="~/Cards.Master" AutoEventWireup="true" CodeBehind="Cards.aspx.cs" Inherits="BIPJ.Cards" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</style>
</header>
    <h2 id="heading">All Linked Cards</h2>
    <button>Add New Card</button>
</asp:Content>
