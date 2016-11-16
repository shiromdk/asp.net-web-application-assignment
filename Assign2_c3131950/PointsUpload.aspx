<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="PointsUpload.aspx.cs" Inherits="Assign2_c3131950.PointsUpload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <th>Points Upload</th>
        </tr>
        <tr>
            <td>Enter Points</td>
            <td><asp:TextBox ID ="points" runat="server"></asp:TextBox></td>

        </tr>
        <tr>
            <td>PIN</td>
            <td><asp:TextBox ID ="pin" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Button ID="submit" runat="server" text="Submit" OnClick="STUBFUNCTION"/></td>
            <%-- This button doesnt actually do anything at the moment. Just in here to show how the website looks --%>
        </tr>
    </table>
</asp:Content>
