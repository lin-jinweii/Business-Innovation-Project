<%@ Page Title="" Language="C#" MasterPageFile="~/Calendar.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="BIPJ.Calendar1" %>
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
    #calendar {
        margin-left: 60px;
        top: 130px;
        position: absolute;
    }
    .lbldate {
        left: 800px;
        top: 140px;
        font-size: 28px;
        font-weight: bold;
        position: absolute;
        font-family: 'PT Sans', sans-serif;
    }
    .gvTransactionDate {
        left: 800px;
        top: 200px;
        position: absolute;
    }
    .lblnotransaction {
        left: 800px;
        top: 200px;
        position: absolute;
        font-weight: bold;
        font-size: 20px;
        font-family: 'PT Sans', sans-serif;
    }
    .bfTransaction {
        font-family: 'PT Sans', sans-serif;
    }
</style>
</header>
    <h2 id="heading">Calendar</h2>
    <div id="calendar">
        <asp:Calendar ID="calendartransaction" runat="server" OnDayRender="calendartransaction_DayRender" Width="450px" Height="350px" CssClass="calendar_transaction"></asp:Calendar>
    </div>
    <asp:Label runat="server" ID="lbldate" CssClass="lbldate"></asp:Label>
    <asp:Gridview runat="server" ID="gvTransactionDate" AutoGenerateColumns="False" CssClass="gvTransactionDate" GridLines="None" Width="25%">
        <Columns>
            <asp:BoundField DataField="Transaction_Name" ItemStyle-CssClass="bfTransaction" HeaderText="Transaction" HeaderStyle-HorizontalAlign="Left" />
            <asp:BoundField DataField="Card_Name" ItemStyle-CssClass="bfTransaction" HeaderText="Card Name" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="Transaction_Amt" DataFormatString="{0:c}" ItemStyle-CssClass="bfTransaction" HeaderText="Amount" HeaderStyle-HorizontalAlign="Left"/>
        </Columns>
    </asp:Gridview>

    <asp:Label runat="server" ID="lblnotransaction" CssClass="lblnotransaction"></asp:Label>
</asp:Content>
