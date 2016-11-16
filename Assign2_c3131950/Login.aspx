<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assign2_c3131950.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Enter your username and password to Login</h2>
    <table border ="0">
        <tr>
            <td>Username</td>
            <td>
                <asp:TextBox id ="usernameText" runat="server"></asp:TextBox></td>
               <td> <asp:RequiredFieldValidator runat="server" ForeColor="Red" ErrorMessage="Required" ControlToValidate="usernameText">

                  </asp:RequiredFieldValidator></td>
           
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td><asp:TextBox id ="passwordText" runat="server" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ForeColor="Red" ErrorMessage="Required" ControlToValidate="passwordText">

                  </asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td><asp:Button ID="loginButton" runat="server" Text="Login" Width="125px" OnClick="loginButton_Click" /></td>
            <td></td>
        </tr>

    </table>
    </asp:Content>
