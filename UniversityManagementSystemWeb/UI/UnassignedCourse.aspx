<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnassignedCourse.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.UnassignedCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
     <fieldset>
        <legend>Unsaaigned Courses</legend>
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
                 Semester
                </td>
                <td>
                   <asp:DropDownList ID="semesterDropDownList" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="semesterDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
      
            </tr>

          <tr>
              <td colspan="2" align="right">
                  <fieldset>
                             <legend>Unassigned Courses</legend>
                  <asp:GridView ID="courseGridView" runat="server" AutoGenerateColumns="False">
                      <Columns>
                          <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                          <asp:BoundField DataField="CourseName" HeaderText="Course Title" />
                          <asp:BoundField DataField="Credit" HeaderText="Credit" />
                          <asp:BoundField DataField="Description" HeaderText="Description" />
                      </Columns>
                  </asp:GridView>
                  </fieldset>
           
                  <asp:Button ID="pdfButton" runat="server" Text="PDF" 
                      onclick="pdfButton_Click" />
              </td>
          </tr>
        </table> 
        
    </fieldset>
    <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>

</asp:Content>
