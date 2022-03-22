<%@ Page Title="" Language="C#" MasterPageFile="~/Budget.Master" AutoEventWireup="true" CodeBehind="Budget.aspx.cs" Inherits="BIPJ.Budget1" %>
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
    .lblBudget {
        font-family: 'PT Sans', sans-serif;
        position: absolute;
        top: 200px;
        font-size: 25px;
    }
    .lblBudgetAmt {
        font-family: 'PT Sans', sans-serif;
        position: absolute;
        top: 200px;
        left: 975px;
        font-size: 25px;
    }

    .lbBudgetInsert {
        font-family: 'PT Sans', sans-serif;
        position: absolute;
        top: 200px;
        left: 975px;
        font-size: 25px;
    }

    .lblExpenseAmt {
        font-family: 'PT Sans', sans-serif;
        position: absolute;
        top: 250px;
        left: 975px;
        font-size: 25px;
    }
    .lblExpense {
        font-family: 'PT Sans', sans-serif;
        position: absolute;
        top: 250px;
        font-size: 25px;
    }
    .lblMth {
        font-family: 'PT Sans', sans-serif;
        position: absolute;
        top: 200px;
        left: 885px;
        font-size: 25px;
    }
    .lblMth2 {
        font-family: 'PT Sans', sans-serif;
        position: absolute;
        top: 250px;
        left: 905px;
        font-size: 25px;
    }
    .ddlBudget {
        position: absolute;
        top: 150px;
        left: 900px;
    }

    .pnlAddBudget {
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

    input.tbUnderlined {
        border:0;
        border-bottom:solid 1px #000;
        outline:none;
    }

    .btn_AddBudget {
        height: 30px;
        width: 80px;
        border-radius: 5px;
        border-color: black;
        margin-top: 0px;
        margin-left: 720px;
    }

    .lblareyousure {
        position:absolute;
        left: 180px;
        top: 30px;
    }

    .lblSGD {
        position:absolute;
        left: 350px;
        top: 65px;
    }

    .lblsure {
        position:absolute;
        left: 388px;
        top: 65px;
    }

    .lblnoteditable{
        position: absolute;
        left: 250px;
        top: 100px;
    }

    .btn_Yes {
        height: 30px;
        width: 80px;
        border-radius: 5px;
        border-color: black;
        margin-top: 60px;
        margin-left: 250px;
        margin-bottom: 20px;
    }

    .btn_No {
        height: 30px;
        width: 80px;
        border-radius: 5px;
        border-color: black;
        position: absolute;
        left: 480px;
        top: 160px;
    }

</style>
</header>
    <h2 id="heading">Budget</h2>

    <asp:Chart ID="BudgetChart" runat="server" BackColor="Transparent" Width="600px">
        <series>
            <asp:Series Name="Budget"></asp:Series>
        </series>
        <series>
            <asp:Series Name="Expense"></asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1" BackColor="Transparent"></asp:ChartArea>
        </chartareas>
        <Legends>
            <asp:Legend Name="Legends" Docking="Bottom" BackColor="Transparent" Alignment="Center"></asp:Legend>
        </Legends>
    </asp:Chart> 
    
    <asp:DropDownList ID="ddlBudget" runat="server" OnSelectedIndexChanged="ddlBudget_SelectedIndexChanged" AutoPostBack="true" CssClass="ddlBudget" Height="30px" Width="150px" AppendDataBoundItems="true">
    </asp:DropDownList>

    <asp:Label runat="server" Text="Budget" ID="lblBudget" CssClass="lblBudget"></asp:Label>
    <asp:Label runat="server" ID="lblMth" CssClass="lblMth"></asp:Label>
    <asp:Label runat="server" ID="lblBudgetAmt" CssClass="lblBudgetAmt"></asp:Label>
    <asp:Label runat="server" Text="Expenses" ID="lblExpense" CssClass="lblExpense"></asp:Label>
    <asp:Label runat="server" ID="lblMth2" CssClass="lblMth2"></asp:Label>
    <asp:Label runat="server" ID="lblExpenseAmt" CssClass="lblExpenseAmt"></asp:Label>

    <asp:LinkButton runat="server" ID="LBInsert" Width="150px" Height="40px" Text="Set A Budget" ForeColor="Blue" CssClass="lbBudgetInsert" Visible="false" OnClick="LBInsert_Click"></asp:LinkButton>

    <asp:Panel ID="pnlAddBudget" runat="server" CssClass="pnlAddBudget" Visible="false">
        <asp:Label runat="server" Text="Add A Budget" Font-Bold="true" Font-Names="PT Sans" Font-Size="X-Large"></asp:Label>
        <asp:ImageButton runat="server" ImageUrl="~/assets/close.png" Width="28px" Height="28px" CssClass="imgbtnClose" CausesValidation="False" OnClick="imgbtnClose_Click"/>
        <br />
        <br />
        <br />

        <asp:Label runat="server" Text="Budget" Font-Bold="true" Font-Names="PT Sans" Font-Size="Larger"></asp:Label>
        <br />
        <asp:Label runat="server" Font-Names="PT Sans">SGD $</asp:Label>
        <asp:TextBox ID="tb_Amount" runat="server" CssClass="tbUnderlined"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="rfvAmt" runat="server" ErrorMessage="Please enter Budget" ControlToValidate="tb_Amount" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator ID="cvAmt" runat="server" ErrorMessage="Invalid Budget Amount. Please try again." ControlToValidate="tb_Amount" ForeColor="Red" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
        <asp:Button ID="btn_AddBudget" CssClass="btn_AddBudget" runat="server" Text="Save" ForeColor="White" BackColor="Blue" OnClick="btn_AddBudget_Click"/>
    </asp:Panel>

    <asp:Panel ID="pnlAddBudgetCfm" runat="server" CssClass="pnlAddBudget" Visible="false">
        <asp:Label runat="server" Text="Are you sure you want to set your budget to" Font-Bold="true" Font-Names="PT Sans" Font-Size="X-Large" CssClass="lblareyousure"></asp:Label>
        <br />
        <asp:Label runat="server" Text="SGD" Font-Size="Larger" Font-Names="PT Sans" Font-Bold="true" ForeColor="DarkRed" CssClass="lblSGD"></asp:Label>
        <asp:Label runat="server" ID="lblsure" Font-Names="PT Sans" Font-Size="Larger" Font-Bold="true" ForeColor="DarkRed" CssClass="lblsure"></asp:Label>
        <asp:ImageButton runat="server" ImageUrl="~/assets/close.png" Width="28px" Height="28px" CssClass="imgbtnClose" CausesValidation="False" OnClick="imgbtnClose_Click"/>
        <br />
        <br />
        <br />

        <asp:Label runat="server" Text="This is not editable once you change it" Font-Bold="true" Font-Names="PT Sans" Font-Size="Larger" CssClass="lblnoteditable"></asp:Label>
        <br />
        <asp:Button ID="btnYes" CssClass="btn_Yes" runat="server" Text="Yes" ForeColor="White" BackColor="Green" OnClick="btnYes_Click" />
        <asp:Button ID="btnNo" CssClass="btn_No" runat="server" Text="No" ForeColor="White" BackColor="Red" OnClick="btnNo_Click"/>

    </asp:Panel>

</asp:Content>
