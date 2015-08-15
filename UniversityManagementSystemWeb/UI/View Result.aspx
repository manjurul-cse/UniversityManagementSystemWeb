<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="View Result.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.View_Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

    <fieldset>
        <legend>Student Info </legend>
        <table style="width: 100%;" border="1">
            <tr>
                <td>
                    Reg No
                </td>
                <td>
                    <input id="regNoTextBox" type="text" runat="server" />&nbsp;<asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" 
                        ErrorMessage="Registation Number required" ControlToValidate="regNoTextBox" 
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator> &nbsp;<asp:Button ID="regNoSearchButton" runat="server" Text="Search" 
                        onclick="regNoSearchButton_Click" />
                </td>
          
            </tr>
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <input id="nameTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    Email
                </td>
                <td>
                    <input id="emailTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    Department
                </td>
                <td>
                    <input id="departmentTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            
            </table>
            </fieldset>
            
            
  Result as of :  <asp:Label ID="dateLabel" runat="server" Text=""></asp:Label>

                 <table border="1">

            <tr>
                <td>
                    No of enrolled courses
                </td>
                <td>
                    <input id="noOfEnrolledCoursesTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    No of completed courses
                </td>
                <td>
                    <input id="noOfCompletedCoursesTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    No of remaining courses
                </td>
                <td>
                    <input id="noOfRemainingCoursesTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    Total credit of enrolled courses
                </td>
                <td>
                    <input id="totalCreditEnrolledCoursesTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    Completed credit
                </td>
                <td>
                    <input id="completedCreditTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    Remaining credit
                </td>
                <td>
                    <input id="remainingCreditTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    CGPA
                </td>
                <td>
                    <input id="cgpaTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    Grade Letter
                </td>
                <td>
                    <input id="gradeLetterTextBox" type="text" runat="server" readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="resultLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>

     
            
           <fieldset>
        <legend>Details</legend>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:GridView ID="detailsResultGridView" runat="server" 
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="courseId" HeaderText="Serial No" />
                            <asp:BoundField DataField="courseName" HeaderText="Coures Name" />
                            <asp:BoundField DataField="credit" HeaderText="Credit" />
                            <asp:BoundField DataField="gradeLetter" HeaderText="State/Grade" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
    
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ForeColor="#FF3300" HeaderText="This page contains following errors:" />
    <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
</asp:Content>
