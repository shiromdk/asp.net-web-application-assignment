<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="NpcFightOutcome.aspx.cs" Inherits="Assign2_c3131950.NpcFightOutcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <table>
        <tr>
               <td><asp:Image runat="server" ID="UserImage" /></td>
               <td><h1>VERSUS</h1> </td>
               <td><asp:Image runat="server" ID="NpcImage"/></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="UserLabel"></asp:Label></td>
            <td></td>
            <td><asp:Label runat="server" ID="NpcLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="UserResultLabel" />
            </td>
            <td>
                <asp:Button runat="server" Text="Back To Main Page" OnClick="Unnamed1_Click" />
            </td>
            <td>
                <asp:Label runat="server" ID="NpcResultLabel"/>
            </td>
        </tr>
    </table>
</asp:Content>
