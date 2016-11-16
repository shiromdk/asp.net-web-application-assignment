<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="CharacterCreation.aspx.cs" Inherits="Assign2_c3131950.CharacterCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <th>CREATE NEW CHARACTER</th>
        </tr>
        <tr>
            <td>Character Name</td>
            <td><asp:TextBox ID="Character" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ControlToValidate="Character" ErrorMessage="Character Name Required"></asp:RequiredFieldValidator><asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="Character" ErrorMessage="Enter characters a-z only"
                      
                     ValidationExpression ="^[a-zA-Z''-'\s]{1,40}$" ></asp:RegularExpressionValidator></td>
            
        </tr>
        <tr>
            <td>Element</td>
            <td><asp:DropDownList runat="server" ID="elementList" AutoPostBack="false" style="height: 22px" >
                <asp:ListItem>EARTH</asp:ListItem>
                <asp:ListItem>AIR</asp:ListItem>
                <asp:ListItem>WATER</asp:ListItem>
                <asp:ListItem>FIRE</asp:ListItem>
                </asp:DropDownList></td>
            <td> </td>
        </tr> 
        <tr>
            <td>
            <asp:Button ID="Create" Text="Create Character" runat="server" OnClick="Create_Click"/>
            <asp:Button ID="Cancel" Text="Cancel" runat="server" OnClick="CancelChar" CausesValidation="False"/>
                </td>
        </tr>
    </table>
    </asp:Content>
