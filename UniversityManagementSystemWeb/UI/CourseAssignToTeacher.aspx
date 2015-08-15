<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CourseAssignToTeacher.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.CourseAssignToTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        function validate() {
            var remaningCredit = parseFloat(document.getElementById("<%=remainingCreditTextBox.ClientID%>").value);
            var credit = parseFloat(document.getElementById("<%=creditTextBox.ClientID%>").value);
            if (credit > remaningCredit) {
                var status= confirm("Exced Teacher Assigned Credit.\nAre u ready to get this subject.\nNow your Remaning credit is: " + (remaningCredit - credit).toString());
                if (status == true) {
                    return true;
                } else {
                    return false;
                }
            }
            else {
                return true;
            }
        }

    </script>
    <fieldset>
        <legend>Course Assign To Teacher </legend>
        <table style="width: 100%;" border="1">
            <tr>
                <td>
                    Department
                </td>
                <td>
                    <asp:DropDownList ID="departmentDropDownList" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="departmentDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Teacher
                </td>
                <td>
                    <asp:DropDownList ID="teacherDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="teacherDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Assign Credit
                </td>
                <td>
                    <asp:TextBox ID="assignCreditTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Remaining Credit
                </td>
                <td>
                    <input id="remainingCreditTextBox" type="text" runat="server" 
                        readonly="readonly" />
                </td>
            </tr>
            <tr>
                <td>
                    Course Title
                </td>
                <td>
                    <asp:DropDownList ID="courseTitleDropDownList" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="courseTitleDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
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
                    Credit
                </td>
                <td>
                    <input id="creditTextBox" type="text" runat="server" readonly="readonly" />
                </td>
                   </tr>
                <tr>
                    <td colspan="2">
                        <div align="right">
                            <asp:Button ID="assignButton" runat="server" Text="Assign" OnClick="assignButton_Click"
                                OnClientClick=" return validate()" />
                        </div>
                    </td>
                </tr>
         
        </table>
    </fieldset>
    <br />
    <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
</asp:Content>
