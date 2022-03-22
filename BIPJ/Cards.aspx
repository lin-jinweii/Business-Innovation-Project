<%@ Page Title="" Language="C#" MasterPageFile="~/Cards.Master" AutoEventWireup="true" CodeBehind="Cards.aspx.cs" Inherits="BIPJ.Cards" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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

    .btnAddNewCard {
        top: 120px;
        margin-left: 60px;
        border-radius: 10px;
        height: 100px;
        width: 350px;
        position: absolute;
    }

    .pnlAddNewCard {
        position: absolute;
        left: 250px;
        top: 50px;
        width: 800px;
        border: solid 1px black;
        border-radius: 10px;
        padding: 10px;
        background-color: white;
    }

    .imgbtnClose {
        margin-left: 600px;
    }

    .imgbtnCloseV2 {
        margin-left: 320px;
    }

    .lblCVC {
        margin-left: 135px;
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
        margin-left: 30px;
    }

    .lblPrivacyTxt {
        color: grey;
    }

    .btnSaveCard {
        height: 35px;
        width: 55px;
        border-radius: 5px;
        border-color: black;
        margin-top: 20px;
        margin-left: 740px;
    }

    .pnlAddSuccess {
        position: absolute;
        left: 500px;
        top: 150px;
        width: 350px;
        height: 150px;
        border: solid 1px black;
        border-radius: 10px;
        padding: 10px;
        background-color: white;
    }

    .lblSuccess {
        color: green;
        margin-left: 55px;
    }

    .pnlDeleteSuccess {
        position: absolute;
        left: 500px;
        top: 150px;
        width: 350px;
        height: 150px;
        border: solid 1px black;
        border-radius: 10px;
        padding: 10px;
        background-color: white;
    }

    .lblDelete {
        color: black;
        margin-left: 55px;
    }

    .btnClose {
        height: 35px;
        width: 60px;
        border-radius: 10px;
        border-color: black;
        margin-left: 150px;
        margin-top: 5px;
    }

    .rfvCVC {
        margin-left: 10px;
    }

    .gvAllCards {
        margin-left: 60px;
        top: 45%;
        position: absolute;
    }

</style>

</header>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h2 id="heading">All Linked Cards</h2>
    <asp:Button ID="btnAddNewCard" runat="server" CssClass="btnAddNewCard" OnClick="btnAddNewCard_Click" Text="Add A New Card" Font-Size="Larger"></asp:Button>
    <br />
    <br />

    <asp:GridView ID="gvAllCards" runat="server" GridLines="None" BorderStyle="Inset" BorderWidth="1px" CellPadding="4" ForeColor="#333333" CssClass="gvAllCards" Width="75%" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAllCard_SelectedIndexChanged" DataKeyNames="Card_No" OnRowDeleting="gvAllCards_RowDeleting" OnRowDataBound="gvAllCard_RowDataBound">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <HeaderStyle HorizontalAlign="Left"/>
        <Columns>
            <asp:BoundField DataField="Card_No" HeaderText="Card No" />
            <asp:ImageField DataImageUrlField="Card_Img" DataImageUrlFormatString="~/assets/{0}" ControlStyle-Width="70px" ControlStyle-Height="50px">
            <ControlStyle Height="50px" Width="70px"></ControlStyle>
            </asp:ImageField>
            <asp:BoundField DataField="Card_Name" HeaderText="Card Name" ControlStyle-Font-Names="PT Sans">
            <ControlStyle Font-Names="PT Sans"></ControlStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Expiry_Date" HeaderText="Expiry Date" ControlStyle-Font-Names="PT Sans" >
            <ControlStyle Font-Names="PT Sans"></ControlStyle>
            </asp:BoundField>
            <asp:CommandField ShowSelectButton="True" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/assets/delete.png" Width="30px" Height="30px" ID="deletebtn" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete the card?')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    </asp:GridView>

    <asp:Panel ID="pnlAddNewCard" Visible="false" CssClass="pnlAddNewCard" runat="server">
        <asp:Label ID="lblAddNewCardtxt" runat="server" Text="Add A New Card" Font-Bold="true" Font-Names="PT Sans" Font-Size="X-Large"></asp:Label>
        <asp:ImageButton runat="server" ImageUrl="~/assets/close.png" Width="28px" Height="28px" CssClass="imgbtnClose" OnClick="imgbtnClose_Click" CausesValidation="False"/>
        <br />
        <br />
        <br />

        <asp:Label ID="lblCardNo" runat="server" Text="Card Number (MASTER/VISA)" Font-Bold="true" Font-Names="PT Sans" Font-Size="Larger"></asp:Label>
        <br />
        <br />

        <asp:TextBox ID="tbcardNo" runat="server" CssClass="tbUnderlined" MaxLength="16"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="rfvcardNo" runat="server" ErrorMessage="Please enter a card number" ControlToValidate="tbcardNo" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />

        <asp:Label ID="lblMMYY" runat="server" Text="MM/YY" Font-Bold="true" Font-Names="PT Sans" Font-Size="Larger"></asp:Label>
        <asp:Label ID="lblCVC"  runat="server" CssClass="lblCVC" Text="CVC" Font-Bold="true" Font-Names="PT Sans" Font-Size="Larger"></asp:Label>
        <br />
        <br />

        <asp:TextBox ID="tbMMYY" runat="server" CssClass="tbUnderlined"></asp:TextBox>
        <asp:TextBox ID="tbCVC" runat="server" CssClass="tbUnderlinedV2" MaxLength="3"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="rfvMMYY" runat="server" ErrorMessage="Please enter MM/YY expiry" ControlToValidate="tbMMYY" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvCVC" runat="server" ErrorMessage="Please enter CVC" ControlToValidate="tbCVC" ForeColor="Red" CssClass="rfvCVC"></asp:RequiredFieldValidator>
        <br />
        <ajaxToolkit:MaskedEditExtender ID="MMYY" runat="server" TargetControlID="tbMMYY" Mask="99/99" MaskType="Date" InputDirection="LeftToRight"></ajaxToolkit:MaskedEditExtender>
        <br />

        <asp:Label runat="server" CssClass="lblPrivacyTxt" Text="By continuing, you agree to the $Z Terms of Service. The privacy notice describes how your data is handled." Font-Names="PT Sans" Font-Size="Small"></asp:Label>
        <br />
        <br />

        <asp:Label runat="server" CssClass="lblPrivacyTxt" Text="You agree that your use of $Z is subject to the $Z Terms of Service. The $Z Privacy Policy describes how $Z handles your data." Font-Names="PT Sans" Font-Size="Small"></asp:Label>
        <br />
        <br />

        <asp:Label runat="server" CssClass="lblPrivacyTxt" Text="In order for $Z to provide $Z services, such as setting up your card, controlling risk, and providing you with transactional details. $Z may share" Font-Names="PT Sans" Font-Size="Small"></asp:Label>
        <br />

        <asp:Label runat="server" CssClass="lblPrivacyTxt" Text="your device, payment, location, and account info with your payment method's issuer and network, and collect transaction, account and other" Font-Names="PT Sans" Font-Size="Small"></asp:Label>
        <br />

        <asp:Label runat="server" CssClass="lblPrivacyTxt" Text="personal info from third parties, including merchants and your bank." Font-Names="PT Sans" Font-Size="Small"></asp:Label>
        <br />
        <br />

        <asp:Label runat="server" CssClass="lblPrivacyTxt" Text="When necessary to keep track of your transactions, $Z may share your info with merchants." Font-Names="PT Sans" Font-Size="Small"></asp:Label>
        <br />
        <br />

        <asp:Label runat="server" CssClass="lblPrivacyTxt" Text="You acknowledge your card may be added to $Z for use on only $Z and elsewhere, unless policy states otherwise." Font-Names="PT Sans" Font-Size="Small"></asp:Label>
        <br />
        <br />

        <asp:Button ID="btnSaveCard" runat="server" CssClass="btnSaveCard" Text="Save" ForeColor="White" BackColor="Green" OnClick="btnSaveCard_Click" />
    </asp:Panel>

    <asp:Panel ID="pnlAddSuccess" runat="server" CssClass="pnlAddSuccess" Visible="false">
        <asp:ImageButton runat="server" ImageUrl="~/assets/close.png" Width="28px" Height="28px" CssClass="imgbtnCloseV2" OnClick="imgbtnClose_ClickV2"/>
        <asp:Label runat="server" CssClass="lblSuccess" Text="Card Added Successfully!" Font-Bold="true" Font-Names="PT Sans" Font-Size="X-Large"></asp:Label>
        <br />
        <br />

        <asp:Button ID="btnClose" runat="server" CssClass="btnClose" Text="Close" BackColor="Blue" ForeColor="White" OnClick="btnClose_Click"/>
    </asp:Panel>

    <asp:Panel ID="pnlDeleteSuccess" runat="server" CssClass="pnlAddSuccess" Visible="false">
        <asp:ImageButton runat="server" ImageUrl="~/assets/close.png" Width="28px" Height="28px" CssClass="imgbtnCloseV2" OnClick="imgbtnClose_ClickV2"/>
        <asp:Label runat="server" CssClass="lblDelete" Text="Card Deleted Successfully!" Font-Bold="true" Font-Names="PT Sans" Font-Size="X-Large"></asp:Label>
        <br />
        <br />

        <asp:Button ID="Button1" runat="server" CssClass="btnClose" Text="Close" BackColor="Blue" ForeColor="White" OnClick="btnClose_Click"/>
    </asp:Panel>

</asp:Content>
