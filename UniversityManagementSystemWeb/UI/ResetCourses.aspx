<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetCourses.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.ResetCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="resetButton" runat="server" Text="Reset" 
        onclick="resetButton_Click" />
    <br />
    <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
    <br />
</asp:Content>
