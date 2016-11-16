<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="IssueChallenge.aspx.cs" Inherits="Assign2_c3131950.IssueChallenge" %>
<%-- This page does not issue challenges currently. THis is just an example of what the page would look like. --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Issue Challenge</h1>
    <asp:DropDownList ID="characterList" runat="server">
    
    </asp:DropDownList>
    <asp:Button Text="Issue Challenge" runat="server" ID="challenge" OnClick="challenge_Click"  />
     <asp:Button Text="Cancel" runat="server" ID="cancel" OnClick="cancelChallenge"  />
</asp:Content>
