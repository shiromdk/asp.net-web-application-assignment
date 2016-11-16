<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="ChallengeAccept.aspx.cs" Inherits="Assign2_c3131950.ChallengeAccept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DropDownList ID="challengerDropDown" runat="server">
        
    </asp:DropDownList>
    <asp:Button ID="fight" Text="Fight" runat="server" OnClick="fight_Click" />
    <asp:Button ID="decline" Text="Decline Challenge" runat="server" OnClick="decline_Click" />

</asp:Content>
