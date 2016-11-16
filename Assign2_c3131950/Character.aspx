<%@ Page Title="" Language="C#" MasterPageFile="~/BetterMaster.Master" AutoEventWireup="true" CodeBehind="Character.aspx.cs" Inherits="Assign2_c3131950.Character" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h2>Character Management</h2>
   <h3>Selected Character:<asp:Label ID="characterNameLabel" runat="server"></asp:Label>
    </h3>
   <asp:Image runat="server" ID="characterImage" Visible="false"/>
   <br />
   <asp:Label ID="Level" runat="server" Text="Level: "></asp:Label><asp:Label runat="server" ID="LevelText"></asp:Label>
   <br />
   <asp:Label ID="Experience" Text="Experience: " runat="server"></asp:Label><asp:Label runat="server" ID="XPText" />
   <br />
   <asp:Button ID ="SelectCharacter" Text="Select Character" runat="server" OnClick="SelectCharacter_Click" />
   <asp:Button ID="CreateCharacter" Text ="Create Character" runat="server" OnClick="CreateCharacter_Click"/>
   <asp:Button ID="ManagePoints" Text="Manage Points" runat="server" OnClick="ManagePoints_Click"/>

</asp:Content>
