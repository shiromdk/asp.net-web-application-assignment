<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="FightScreen.aspx.cs" Inherits="Assign2_c3131950.FightScreen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>        h1 {
        font-size:40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
               <td><asp:Image runat="server" ID="Challenged" /></td>
               <td><h1>VERSUS</h1> </td>
               <td><asp:Image runat="server" ID="Challenger"/></td>
      
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="ChallengedLabel"></asp:Label></td>
            <td></td>
            <td><asp:Label runat="server" ID="ChallengerLabel"></asp:Label></td>
        </tr>
        <tr>
            <td>
                <asp:Label runat="server" ID="ChallengedResult"/>
            </td>
            <td><asp:Button runat="server" Text="FIGHT" Width="189px" OnClick="Unnamed1_Click" /></td>
             <td>
                <asp:Label runat="server" ID="ChallengerResult"/>
            </td>
        </tr>
    </table>
</asp:Content>
