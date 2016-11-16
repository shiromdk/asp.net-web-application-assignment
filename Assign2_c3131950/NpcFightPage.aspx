<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="NpcFightPage.aspx.cs" Inherits="Assign2_c3131950.NpcFightPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
        <tr>
               <td><asp:Image runat="server" ID="User" /></td>
               <td><h1>VERSUS</h1> </td>
               <td><asp:Image runat="server" ID="NPC"/></td>
      
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="UserLabel"></asp:Label></td>
            <td></td>
            <td><asp:Label runat="server" ID="NPCLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="UserResult"/>
            </td>
            <td><asp:Button runat="server" Text="FIGHT" Width="189px" OnClick="Unnamed1_Click" /></td>
             <td>
                <asp:Label runat="server" ID="NPCResult"/>
            </td>
        </tr>
    </table>
</asp:Content>
