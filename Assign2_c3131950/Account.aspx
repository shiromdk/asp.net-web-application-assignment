<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Assign2_c3131950.AccountManagement" %>
<%-- 
* Title              : INFT3050 Assignment 2
* File Name          : Account.aspx
* Author             : Alan Nguyen
* Student Number     : 3131950
*
* Description        : This is the Account Management Page. It contains buttons which leads to the change password form, Delete Account Form and a logout button.
       
    --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:Button runat="server" ID="pointsUpload" Text="Upload Points" OnClick="pointsUpload_Click" />
         <asp:Button runat ="server" ID="ChangePasswordButton" Text="Change Password" OnClick="ChangePasswordButton_Click" />
            <asp:Button runat ="server" ID="DeleteAccount" Text="Delete Account" OnClick="DeleteAccount_Click" />
            <asp:Button runat="server" ID="Logout" Text="Logout" OnClick="Logout_Click" />
 
</asp:Content>
