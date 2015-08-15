<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseEntry.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.CourseEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
    <legend>Course Entry</legend>
        <table style="width: 100%;" border="1">
        <tr>
            <td>
             Course Code 
                
            </td>
            <td>
            
              <input id="codeTextBox" type="text" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="codeTextBox" ErrorMessage="Course Code is required" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
            </td>
           
           
        </tr>
            <tr>
            <td>
             Course Title
                
            </td>
            <td>
            
              <input id="titleTextBox" type="text" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="titleTextBox" ErrorMessage="Course title is required" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
            </td>
           
           
        </tr>
            <tr>
            <td>
            Credit
                
            </td>
            <td>
            
              <input id="creditTextBox" type="text" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="creditTextBox" ErrorMessage="Credit is required" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
            </td>
           
           
        </tr>
            <tr>
            <td>
             Description
                
            </td>
            <td>
            
              <input id="descriptionTextBox" type="text" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Description is required" ForeColor="#FF3300" 
                    ControlToValidate="descriptionTextBox">*</asp:RequiredFieldValidator>
            </td>
           
           
        </tr>
            <tr>
            <td>
            Department
                
            </td>
            <td>
             <asp:DropDownList ID="departmentDropDownList" runat="server" 
                    AutoPostBack="True" Height="25px" Width="120px">
                </asp:DropDownList>
            
            </td>
           
           
        </tr>
            <tr>
            <td>
       Semester
                
            </td>
            <td>
            <asp:DropDownList ID="semesterDropDownList" runat="server" 
                    AutoPostBack="True" Height="25px" Width="120px">
                </asp:DropDownList>
               
            </td>
           
           
        </tr>
            <tr>
            <td colspan="2" align="justify">
                <asp:Button ID="saveButton" runat="server" Text="Save" 
                    onclick="saveButton_Click" style="height: 26px" Width="77px" />
                
                
                </td>
        
           
           
        </tr>
    
    </table>
</fieldset>    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ForeColor="#FF3300" HeaderText="This page contains following errors:" />
<asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>

</asp:Content>
