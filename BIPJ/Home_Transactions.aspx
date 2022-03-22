<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home_Transactions.aspx.cs" Inherits="BIPJ.Home_Transactions" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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

    .chrtPrgBar {
        left: 750px;
        top: 110px;
        position: absolute;
    }

    .lblBudgetAmt {
        left: 1070px;
        top: 90px;
        font-size: 20px;
        font-family: 'PT Sans', sans-serif;
        position: absolute;
    }
    .lblBudget {
        left: 765px;
        top: 90px;
        font-size: 20px;
        font-family: 'PT Sans', sans-serif;
        position: absolute;
    }
    .btnAddCash {
        top: 300px;
        position: absolute;
        left: 800px;
        width: 120px;
        height: 25px;
        background-color: deepskyblue;
        border-radius: 7px;
    }
    .pnlAddCash {
        position: absolute;
        left: 250px;
        top: 50px;
        width: 800px;
        border: solid 1px black;
        border-radius: 10px;
        padding: 10px;
        background-color: white;
    }
    input.tbUnderlined {
        border:0;
        border-bottom:solid 1px #000;
        outline:none;
    }
    input.tbUnderlinedV2 {
        border:0;
        border-bottom:solid 1px #000;
        outline:none;
        margin-left: 120px;
    }
    .pnlAddCash {
        position: absolute;
        left: 250px;
        top: 80px;
        width: 800px;
        border: solid 1px black;
        border-radius: 10px;
        padding: 10px;
        background-color: white;
    }
    .imgbtnClose {
        top: 15px;
        left: 785px;
        position: absolute;
    }

    .lblDate {
        margin-left: 135px;
    }

    .btnAddCash {
        height: 30px;
        width: 120px;
        border-radius: 5px;
        border-color: black;
        margin-top: 0px;
        margin-left: 50px;
    }

    .imgbtnCalendar {
        position: absolute;
        top: 95px;
        left: 470px;
    }

    .rfvDate {
        margin-left: 85px;
    }

    .ddlCat {
        margin-left: 800px;
        margin-top: 5px;
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
    
    <asp:Label runat="server" ID="lblBudget" Text="Budget >" CssClass="lblBudget"></asp:Label>
    <asp:Chart ID="Chart1" runat="server" BackColor="Transparent" CssClass="chrtPrgBar" Height="40px" Width="500px">
        <series>
            <asp:Series Name="Series1" ChartType="Bar"></asp:Series>
            <asp:Series ChartType="Bar" Name="Series2"></asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1" BackColor="Transparent"></asp:ChartArea>
        </chartareas>
    </asp:Chart>
    <asp:Label runat="server" ID="lblBudgetAmt" CssClass="lblBudgetAmt"></asp:Label>

    <p id="title">All Transactions</p>
    <asp:Button runat="server" Text="Add Cash Invoice" CssClass="btnAddCash" OnClick="btnAddCash_Click"/>

     <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>

    <asp:DropDownList ID="ddlCat" runat="server" OnSelectedIndexChanged="ddlCat_SelectedIndexChanged" AutoPostBack="true" CssClass="ddlCat" Height="30px" Width="120px" AppendDataBoundItems="true"></asp:DropDownList>

    <asp:GridView ID="gvTransactions" CssClass="gvTransactions" runat="server" AutoGenerateColumns="False" Width="70%" BorderStyle="Inset" BorderWidth="1px" CellPadding="4" ForeColor="#333333">
        <Columns>
            <asp:BoundField DataField="Card_No" HeaderText="Card_No" />
            <asp:BoundField DataField="Transaction_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yy}" />
            <asp:BoundField DataField="Transaction_Name" HeaderText="Name" />
            <asp:BoundField DataField="Card_Name" HeaderText="Card Name" />
            <asp:BoundField DataField="Transaction_Amt" DataFormatString="{0:c}" HeaderText="Amount" />
            <asp:BoundField DataField="Transaction_Cat" HeaderText="Category" />
        </Columns>
    </asp:GridView>

    <asp:Panel ID="pnlAddCash" runat="server" CssClass="pnlAddCash" Visible="false">
        <asp:Label runat="server" Text="Add A Cash Transaction" Font-Bold="true" Font-Names="PT Sans" Font-Size="X-Large"></asp:Label>
        <asp:ImageButton runat="server" ImageUrl="~/assets/close.png" Width="28px" Height="28px" CssClass="imgbtnClose" CausesValidation="False" OnClick="imgbtnClose_Click"/>
        <br />
        <br />
        <br />

        <asp:Label runat="server" Text="Transaction Name" Font-Bold="true" Font-Names="PT Sans" Font-Size="Larger"></asp:Label>
        <asp:Label runat="server" Text="Date" CssClass="lblDate" Font-Bold="true" Font-Names="PT Sans" Font-Size="Larger"></asp:Label>

        <br />
        <asp:TextBox ID="tb_TransactionName" runat="server" CssClass="tbUnderlined"></asp:TextBox>
        <asp:TextBox ID="tb_Date" runat="server" CssClass="tbUnderlinedV2" onkeydown="return false;"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="rfvTransactionName" runat="server" ErrorMessage="Please enter Transaction Name" ControlToValidate="tb_TransactionName" ForeColor="Red"></asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="Please select Transaction Date" ControlToValidate="tb_Date" ForeColor="Red" CssClass="rfvDate"></asp:RequiredFieldValidator>

        <asp:ImageButton runat="server" ImageUrl="~/assets/calendar.png" Width="28px" Height="28px" OnClick="calendar_Click" CausesValidation="false" CssClass="imgbtnCalendar"/>
        <div style="margin-left: 280px;">
            <asp:Calendar runat="server" ID="calendarPopup" OnSelectionChanged="calendarPopup_SelectionChanged" OnDayRender="calendarPopup_DayRender"></asp:Calendar>
        </div>
        <br />
        <br />
        <asp:Label runat="server" Text="Category" Font-Bold="true" Font-Names="PT Sans" Font-Size="Larger"></asp:Label>
        <br />
        <asp:DropDownList runat="server" ID="ddl_Category">
            <asp:ListItem Value="" Selected="True"> </asp:ListItem>
            <asp:ListItem Value="Transport">Transport</asp:ListItem>
            <asp:ListItem Value="Food">Food</asp:ListItem>
            <asp:ListItem Value="Shopping">Shopping</asp:ListItem>
            <asp:ListItem Value="Utilities">Utilities</asp:ListItem>
            <asp:ListItem Value="Healthcare">Healthcare</asp:ListItem>
            <asp:ListItem Value="Subscription">Subscription</asp:ListItem>
            <asp:ListItem Value="Others">Others</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ErrorMessage="Please select Category" ControlToValidate="ddl_Category" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label runat="server" Text="Amount" Font-Bold="true" Font-Names="PT Sans" Font-Size="Larger"></asp:Label>
        <br />
        <asp:Label runat="server">SGD $</asp:Label>
        <asp:TextBox ID="tb_Amount" runat="server" CssClass="tbUnderlined"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="rfvAmt" runat="server" ErrorMessage="Please enter Amount" ControlToValidate="tb_Amount" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator ID="cvAmt" runat="server" ErrorMessage="Invalid Amount. Please try again." ControlToValidate="tb_Amount" ForeColor="Red" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
        <asp:Button ID="btn_AddCash" CssClass="btn_AddCash" runat="server" Text="Add" ForeColor="White" BackColor="Green" OnClick="btn_AddCash_Click"/>


    </asp:Panel>

</asp:Content>
