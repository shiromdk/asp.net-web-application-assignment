<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Assign2_c3131950.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Form currently does not submit
        It only makes sure that everything is filled out and that the new password fields are matching
         --%>
    <table>
        <tr>
            <th>
             <p>Change Password Form</p>
            </th>
        </tr>
        <tr>
            <td>Enter Old Password</td>
            <td>
                <asp:TextBox runat="server" ID="oldpassword" TextMode="Password" ></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="oldpassword" ErrorMessage="Enter Old Password"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Enter New Password</td>
            <td><asp:TextBox runat="server" ID="newpassword" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ControlToValidate="newpassword" ErrorMessage="Enter New Password"></asp:RequiredFieldValidator></td>
            <td><asp:RegularExpressionValidator ID="RegExp1" runat="server"    
                ErrorMessage="Password length must be between 7 to 50 characters"
                ControlToValidate="newpassword"    
                ValidationExpression="^[a-zA-Z0-9'@&#.\s]{7,50}$" /></td>
        </tr>
        <tr>
            <td>Confirm New Password</td>
            <td><asp:TextBox runat="server" ID="confirmpass" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ControlToValidate="confirmpass" ErrorMessage="Confirm Password Required"></asp:RequiredFieldValidator></td>
            <td><asp:CompareValidator runat="server" ControlToCompare="newpassword" ControlToValidate="confirmpass" ErrorMessage="Passwords do not match"></asp:CompareValidator></td>
        </tr>
        <tr><td class="auto-style1"><asp:Button runat="server" ID="submitbutton" Text="Submit" Width="157px" OnClick="submitbutton_Click" /></td></tr>
    </table>
</asp:Content>
