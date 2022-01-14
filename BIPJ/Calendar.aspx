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
</style>
</header>
    <h2 id="heading">Calendar</h2>
    <div id="calendar">
        <asp:Calendar ID="calendartransaction" runat="server" OnDayRender="calendartransaction_DayRender" Width="450px" Height="350px" CssClass="calendar_transaction"></asp:Calendar>
    </div>
</asp:Content>
