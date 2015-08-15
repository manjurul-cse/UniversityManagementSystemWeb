<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Result.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Student Result Entry</legend>
        <table style="width: 100%;" border="1">
            <tr>
                <td>
                    Department
                </td>
                <td>
                    <asp:DropDownList ID="departmentDropDownList" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Course
                </td>
                <td>
                    <asp:DropDownList ID="courseDropDownList" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Student Reg No
                </td>
                <td>
                    <input id="regNoTextBox" type="text" runat="server" /> &nbsp;<asp:RequiredFieldValidator 
                        ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Registration Number is required" ControlToValidate="regNoTextBox" 
                        ForeColor="Red">*</asp:RequiredFieldValidator> &nbsp;<asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </td>
            
            </tr>
            <tr>
                <td class="style1">
                    Name
                </td>
                <td class="style1">
                    <input id="nameTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    Email
                </td>
                <td>
                    <input id="emailTextBox" type="text" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Obtained Grade Letter
                </td>
                <td>
                    <asp:DropDownList ID="gradeLetterDropDownList" runat="server" AutoPostBack="True">
                        <asp:ListItem>A+</asp:ListItem>
                        <asp:ListItem>A</asp:ListItem>
                        <asp:ListItem>A-</asp:ListItem>
                        <asp:ListItem>B+</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                        <asp:ListItem>B-</asp:ListItem>
                        <asp:ListItem>C+</asp:ListItem>
                        <asp:ListItem>C</asp:ListItem>
                        <asp:ListItem>C-</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" >
                    &nbsp;<asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click"
                        Width="79px" />
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
        HeaderText="This page contains following errors:" />
    <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
</asp:Content>

