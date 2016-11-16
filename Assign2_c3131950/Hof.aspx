<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="Hof.aspx.cs" Inherits="Assign2_c3131950.Hof" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>The Hall of Fame</h1>
    <p>Titans that have reached the level cap are inducted into the Hall of Fame</p>
    <p>They are no longer able to participate in fights</p>
    <asp:GridView id="gridview1" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="OnPaging">
        <Columns>
         <asp:BoundField DataField="TitanName" HeaderText="Titan Name" ReadOnly="True" SortExpression="BattleID" />
        </Columns>
    </asp:GridView>
</asp:Content>
