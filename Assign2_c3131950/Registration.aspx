<%--
* Title              : INFT3050 Assignment 2
* File Name          : Registration.aspx
* Author             : Alan Nguyen
* Student Number     : 3131950
*
* Description        : This is the registration page for the web application.
                  
*
--%>



<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Assign2_c3131950.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- Registration form is created using tables. All inputs have a RequiredFieldValidator which will force every
        Textbox to have some input before being submitted  --%>
      <table border="0">
        <tr>
            <th colspan="3">Registration</th>
        </tr>
        <tr>
            <td>Email Address</td>
            <td><asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server" ErrorMessage="Required" ForeColor="Red" ControlToValidate="emailTextBox">
                </asp:RequiredFieldValidator>
                <%--The RegularExpressionValidator forces email addresses to be in the correct format  --%>
                 <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ControlToValidate="emailTextBox" ForeColor="Red" ErrorMessage="Invalid email address." />

            </td>

        </tr>
          <%-- COmpare Validators forces both password fields to be the same --%>
        <tr>
            <td>Password</td>
            <td><asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password"></asp:TextBox></td>
            <td><asp:RequiredFieldValidator runat="server"  ForeColor="Red" ErrorMessage="Required" ControlToValidate="passwordTextBox"></asp:RequiredFieldValidator></td>
            <td><asp:RegularExpressionValidator ID="RegExp1" runat="server"    
                ErrorMessage="Password length must be between 7 to 50 characters"
                ControlToValidate="passwordTextBox"    
                ValidationExpression="^[a-zA-Z0-9'@&#.\s]{7,50}$" /></td>
        </tr>
          <tr>
            <td>Confirm Password</td>
            <td><asp:TextBox ID="confirmPasswordText" runat="server" TextMode="Password"></asp:TextBox></td>
            <td><asp:CompareValidator runat="server" ErrorMessage="Passwords do not match." ControlToCompare="passwordTextBox" ControlToValidate="confirmPasswordText" ></asp:CompareValidator></td>
        </tr>
          <%-- Validation expression forces both First Name and Last Name to consist of only uppercase and lowercase letters --%>
          <tr>
              <td>First Name</td>
              <td><asp:TextBox runat="server" ID="firstNameText"></asp:TextBox></td>
              <td><asp:RequiredFieldValidator runat="server" ForeColor="Red" ErrorMessage="Required" ControlToValidate="firstNameText">

                  </asp:RequiredFieldValidator>
                  <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="firstNameText" ErrorMessage="Enter characters a-z only"
                      
                     ValidationExpression ="^[a-zA-Z''-'\s]{1,40}$" ></asp:RegularExpressionValidator>
              </td>
          </tr>
              <tr>
              <td>Surname</td>
              <td><asp:TextBox runat="server" ID="surnameText"></asp:TextBox></td>
              <td><asp:RequiredFieldValidator runat="server" ForeColor="Red" ErrorMessage="Required" ControlToValidate="surnameText">

                  </asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="surnameText" ErrorMessage="Enter characters a-z only"
                      
                     ValidationExpression ="^[a-zA-Z''-'\s]{1,40}$" ></asp:RegularExpressionValidator>
              </td>
          </tr>
          <%-- The Validation Expression forces the mobile number to be a 10 digit number --%>
          <tr>
              <td>Mobile Number</td>
              <td><asp:TextBox runat="server" ID="mobileNumberText"></asp:TextBox></td>
              <td><asp:RequiredFieldValidator runat="server" ForeColor="Red" ErrorMessage="Required" ControlToValidate="mobileNumberText">

                  </asp:RequiredFieldValidator></td>
              <asp:RegularExpressionValidator runat="server" Display="Dynamic" ControlToValidate="mobileNumberText" ErrorMessage="Invalid Phone Number" 
                  ValidationExpression="^\d{10}$"
                    ></asp:RegularExpressionValidator>
          </tr>
          <tr>
              <td><asp:Button Text="Submit" runat="server" OnClick="RegisterAccountClick"  />
              </td>
          </tr>
           

    </table>
</asp:Content>
