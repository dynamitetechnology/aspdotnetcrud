<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="edit.aspx.cs" Inherits="WebApplication.edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <div class="jumbotron rounded-0">
<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
      
       <asp:TextBox ID="updateFname" runat="server" Text='<%# Eval("fname") %>' />
        <asp:TextBox ID="updateLname" runat="server" Text='<%# Eval("lname") %>' />
       <asp:Button ID="Button1" OnClick="updateData" runat="server" Text="Button" />
    </ItemTemplate>
     
    </asp:Repeater>
    </div>


</asp:Content>
