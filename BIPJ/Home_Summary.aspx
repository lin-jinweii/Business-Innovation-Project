<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home_Summary.aspx.cs" Inherits="BIPJ.Home_Summary" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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
    .chrtSummary {
        left: 250px;
        top: 320px;
        position: absolute;
    }
    .lblSummary {
        left: 270px;
        top: 290px;
        font-size: 23px;
        font-family: 'PT Sans', sans-serif;
        font-weight: bold;
        position: absolute;
    }
    .lblMth {
        left: 400px;
        top: 290px;
        font-size: 23px;
        font-family: 'PT Sans', sans-serif;
        font-weight: bold;
        position: absolute;
    }
    .lblYear {
        left: 435px;
        top: 290px;
        font-size: 23px;
        font-family: 'PT Sans', sans-serif;
        font-weight: bold;
        position: absolute;
    }
</style>
</header>
    <h2 id="heading">Total Spendings</h2>
    <p id="amount">SGD $</p>
    <asp:Label ID="lbltotalamt" runat="server" CssClass="lbltotalamt"></asp:Label>
    <a href="Home_Summary.aspx" id="summary_btn" style="color: black">
        Summary
    </a>
    <a href="Home_Transactions.aspx" id="transactions_btn">
        Transactions
    </a>
    <hr style="width: 70%; border: none; height: 1px; background-color: black; top: 280px; left: 270px; position: absolute;" />
    
    <asp:Label runat="server" CssClass="lblSummary" Text="Summary for"></asp:Label>
    <asp:Label runat="server" CssClass="lblMth"  ID="lblMth"></asp:Label>
    <asp:Label runat="server" CssClass="lblYear" ID="lblYear"></asp:Label>

    <asp:Chart ID="SummaryChart" runat="server" BackColor="Transparent" CssClass="chrtSummary">
        <series>
            <asp:Series Name="Series1"></asp:Series>
        </series>
        <Legends>
            <asp:Legend Alignment="Far" Docking="Bottom" IsTextAutoFit="false" LegendStyle="Row" BackColor="Transparent"></asp:Legend>
        </Legends>
        <chartareas>
            <asp:ChartArea Name="ChartArea1" BackColor="Transparent"></asp:ChartArea>
        </chartareas>
    </asp:Chart>    

    <asp:GridView runat="server" ID="gvCatAmt" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Transaction_Cat" HeaderText="Cat" />
            <asp:BoundField DataField="Transaction_Amt" HeaderText="Amt" />
        </Columns>

    </asp:GridView>
</asp:Content>
