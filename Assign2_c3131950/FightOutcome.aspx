﻿<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="FightOutcome.aspx.cs" Inherits="Assign2_c3131950.FightOutcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                <asp:Label runat="server" ID="ChallengedResultLabel" />
            </td>
            <td>
                <asp:Button runat="server" Text="Back To Main Page" OnClick="Unnamed1_Click" />
            </td>
            <td>
                <asp:Label runat="server" ID="ChallengerResultLabel"/>
            </td>
        </tr>
    </table>
</asp:Content>
