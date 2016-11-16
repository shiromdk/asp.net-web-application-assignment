<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Assign2_c3131950.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <th>Account Deletion</th>
        </tr>
        <tr>
            <td>
                Enter Password
            </td>
             <td><asp:TextBox runat="server" ID="password" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ControlToValidate="password" ErrorMessage="Enter New Password"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>Confirm Password</td>
            <td><asp:TextBox runat="server" ID="confirmpassword" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ControlToValidate="confirmpassword" ErrorMessage="Enter password again"></asp:RequiredFieldValidator>
            <asp:CompareValidator runat="server" ControlToCompare="password" ControlToValidate="confirmPassword" ErrorMessage="Passwords do not match" ></asp:CompareValidator></td>
        </tr>
        <tr>
            <td><asp:Button runat="server" ID="button" Text="Delete Account" OnClick="button_Click" /></td>
        </tr>
    </table>
</asp:Content>
