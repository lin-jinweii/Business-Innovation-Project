<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home_Transactions.aspx.cs" Inherits="BIPJ.Home_Transactions" %>
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
        top: 50px;
        margin-left: 60px;
        position: absolute;
    }
    #amount {
        font-family: 'PT Sans', sans-serif;
        font-size: 30px;
        margin-left: 60px;
        position: absolute;
        top: 100px;
    }
    .lbltotalamt {
        font-family: 'PT Sans', sans-serif;
        font-size: 30px;
        margin-left: 138px;
        position: absolute;
        top: 100px;
    }
    #summary_btn {
        left: 270px;
        top: 240px;
        font-size: 23px;
        font-family: 'PT Sans', sans-serif;
        font-weight: bold;
        position: absolute;
    }
    #transactions_btn {
        left: 420px;
        top: 240px;
        font-size: 23px;
        font-family: 'PT Sans', sans-serif;
        font-weight: bold;
        position: absolute;
    }

    #title {
        top: 300px;
        position: absolute;
        left: 270px;
        font-size: 23px;
        font-weight: bold;
    }

    .gvTransactions {
        top: 340px;
        position: absolute;
        left: 270px;
    }
</style>
</header>
    <h2 id="heading">Total Spendings</h2>
    <p id="amount">SGD $</p>
    <asp:Label ID="lbltotalamt" runat="server" CssClass="lbltotalamt"></asp:Label>
    <a href="Home_Summary.aspx" id="summary_btn">
        Summary
    </a>
    <a href="Home_Transactions.aspx" id="transactions_btn" style="color: black">
        Transactions
    </a>
    <hr style="width: 70%; border: none; height: 1px; background-color: black; top: 280px; left: 270px; position: absolute;" />
     
    <p id="title">All Transactions</p>

    <asp:GridView ID="gvTransactions" CssClass="gvTransactions" runat="server" AutoGenerateColumns="False" Width="70%" BorderStyle="Inset" BorderWidth="1px" CellPadding="4" ForeColor="#333333">
        <Columns>
            <asp:BoundField DataField="Card_No" HeaderText="Card_No" />
            <asp:BoundField DataField="Transaction_Name" HeaderText="Name" />
            <asp:BoundField DataField="Transaction_Amt" DataFormatString="{0:c}" HeaderText="Amount" />
            <asp:BoundField DataField="Transaction_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yy}" />
            <asp:BoundField DataField="Transaction_Cat" HeaderText="Category" />
        </Columns>
    </asp:GridView>
</asp:Content>
