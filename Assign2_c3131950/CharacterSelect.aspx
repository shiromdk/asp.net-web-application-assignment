<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="CharacterSelect.aspx.cs" Inherits="Assign2_c3131950.CharacterSelect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:DropDownList ID ="characterList" runat="server">

    </asp:DropDownList>
    <asp:Button runat="server" ID="selectbutton" Text="Select Character" OnClick="Select" />
</asp:Content>
