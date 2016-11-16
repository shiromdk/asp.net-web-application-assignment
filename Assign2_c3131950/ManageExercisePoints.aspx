<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="ManageExercisePoints.aspx.cs" Inherits="Assign2_c3131950.ManageExercisePoints" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%-- THe final page will be able to generate the appropriate number of unnassigned experience points to the page
    
     --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Manage Exercise Points</h2>
    <p>You have x amount of points</p>
    <asp:DropDownList runat="server">
        <asp:ListItem>Your Example TItan 1</asp:ListItem>

    </asp:DropDownList>
    <asp:TextBox ID="enternumber" runat="server"></asp:TextBox>
    <asp:Button ID="submitbutton" Text="Submit" runat="server" OnClick="submitbutton_Click" />
</asp:Content>
