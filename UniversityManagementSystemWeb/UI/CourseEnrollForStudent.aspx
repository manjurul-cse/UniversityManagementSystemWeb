<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CourseEnrollForStudent.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.CourseEnrollForStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>
        
        <legend>Student Course Enroll</legend>
        <table border="1">
    <tr>
        <td>
            Registation No
        </td>
        <td>
            <asp:TextBox ID="registationNoTextBox" runat="server" Width="128px"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="Registation Number is required" 
                ControlToValidate="registationNoTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>  <asp:Button 
                ID="searchButton" runat="server" Text="search" Height="27px" Width="110px" 
                onclick="searchButton_Click" />
        </td>
    </tr>
    
    <tr>
        <td>
            Name
        </td>
        <td>
            <asp:TextBox ID="nameTextBox" runat="server" ReadOnly="True"></asp:TextBox>   
        </td>
    </tr>
    
    <tr>
        <td>
          Email  
        </td>
        <td>
            <asp:TextBox ID="emailTextBox" runat="server" ReadOnly="True"></asp:TextBox>    
        </td>
    </tr>
    
    <tr>
        <td class="style1">
        Department    
        </td>
        <td class="style1">
            <asp:TextBox ID="departmentTextBox" runat="server" ReadOnly="True"></asp:TextBox>  
        </td>
    </tr>
    
        <tr>
        <td>
        Date 
        </td>
        <td>
            <asp:TextBox ID="dateTextBox" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
    </tr>

    <tr>
        <td>
         Course to enroll   
        </td>
        <td>
            <asp:DropDownList ID="enrollDropDownList" runat="server" AutoPostBack="True">
            </asp:DropDownList>  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:Button ID="enrollButton" runat="server" Text="Enroll" Width="116px" 
                onclick="enrollButton_Click" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:HyperLink ID="HyperLink1" runat="server">Show all courses of university</asp:HyperLink> 
            <asp:Button ID="showAllCourseOfUniversityButton" runat="server" 
                Text="Show all Courses of University" 
                onclick="showAllCourseOfUniversityButton_Click" />
        </td>
    </tr>
</table>



    </fieldset>
      <fieldset>
          <legend>Enrolled Course</legend>
          <asp:GridView ID="enrollsubjectGridView" runat="server" 
              AutoGenerateColumns="False">
              <Columns>
                  <asp:BoundField DataField="CourseId" HeaderText="Serial No" />
                  <asp:BoundField DataField="courseCode" HeaderText="Course Title" />
                  <asp:BoundField DataField="courseName" HeaderText="Name" />
              </Columns>
          </asp:GridView>
           </fieldset>

           <asp:ValidationSummary ID="ValidationSummary2" runat="server" 
        ForeColor="Red" HeaderText="This page contains following errors:" />

           <asp:Label ID="msgLabel" runat="server" Text="Label"></asp:Label>

</asp:Content>
