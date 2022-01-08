<%@ Page Title="" Language="C#" MasterPageFile="~/Cards.Master" AutoEventWireup="true" CodeBehind="CardDetails.aspx.cs" Inherits="BIPJ.CardDetails" %>
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

    .auto-style1 {
        width: 100%;
    }

</style>
</header>

<h2 id="heading">Card Details></h2>

    <table class="auto-style1">
    <tr>
        <td rowspan="3">
            <!--<asp:Image ID="ImgCard" runat="server" Height="89px" Width="126px" ImageUrl="~/assets/"/>-->
        </td>
        <td>Recent Transactions</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblCardName" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    </table>

</asp:Content>
