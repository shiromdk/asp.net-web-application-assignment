<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="BattleResults.aspx.cs" Inherits="Assign2_c3131950.BattleResults" %>
<%-- Currently the Gridview control shows all battles that are in the database. THe final version will limit it to battles the logged in user has participated in --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gridview1" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="OnPaging">
        <Columns>
            <asp:BoundField DataField="BattleID" HeaderText="BattleID" ReadOnly="True" SortExpression="BattleID" />
            <asp:BoundField DataField="Winner" HeaderText="Winner" SortExpression="Winner" />
            <asp:BoundField DataField="Challenger" HeaderText="Challenger" SortExpression="Challenger" />
            <asp:BoundField DataField="Challenged" HeaderText="Challenged" SortExpression="Challenged" />
        </Columns>
    </asp:GridView>
    <asp:Button runat="server" Text="Return to Battle Home" ID="return" OnClick="return_Click" />
</asp:Content>
