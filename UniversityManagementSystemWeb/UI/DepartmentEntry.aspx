<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DepartmentEntry.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.DepartmentEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script language="javascript" type="text/javascript">

        function validate() {

//            if (document.getElementById("<%=codeTextBox.ClientID%>").value == "") {
//                alert("Department Code text Feild blank");
//                document.getElementById("<%=codeTextBox.ClientID%>").focus();
//                return false;
//            }

//            if (document.getElementById("<%=nameTextBox.ClientID%>").value == "") {
//                alert("Deapartment Name text Feild blank");
//                document.getElementById("<%=nameTextBox.ClientID%>").focus();
//                return false;
//            }

            var x = (document.getElementById("<%=codeTextBox.ClientID%>").value);
            var y = x.toString().length;
            if (y < 3 || y > 4) {
                alert("Department Code Must be Three Character");
                document.getElementById("<%=codeTextBox.ClientID%>").focus();
                return false;
            }
            return true;
        }

    </script>
    <fieldset>
        <legend>Department Entry</legend>
        <table border="1">
            <tr>
                <td>
                    Depaartment Code
                </td>
                <td >
                    <input id="codeTextBox" runat="server" type="text" /> &nbsp;
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="codeTextBox" ErrorMessage="Department Code is required" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Department Name
                </td>
                <td>
                    <input id="nameTextBox" runat="server" type="text" />&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="nameTextBox" ErrorMessage="Department Name is required" 
                        ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="saveButton" runat="server" Text="Save" Height="27px" Width="98px"
                        OnClientClick="return validate()" OnClick="saveButton_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ForeColor="#FF3300" HeaderText="This page contains following errors:" />
    <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
</asp:Content>
