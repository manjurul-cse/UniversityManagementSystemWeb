<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StudentEntry.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.StudentEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
<link href="../Styles/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
<script src="../Scripts/jquery-1.6.1.min.js" type="text/javascript"></script>
<script src="../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        $(".date").datepicker({
            dateFormat: "yy-mm-dd",
            changeMonth: true,
            changeYear: true,
            yearRange: "-5:+5"
        });
    });
    
     </script>

    <fieldset style=" width:100" border="1">
                <legend>Student Registation Process</legend>
    <table border="1" >
        <tr>
            <td>
                Name
            </td>
            <td>
                <input id="nameText" runat="server" type="text" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Name is required" ControlToValidate="nameText" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <input id="emailText" runat="server" type="text" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Email is required" ControlToValidate="emailText" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="emailText" ErrorMessage="Invalid email format" 
                    ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Contact No&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <input id="contactNoText" runat="server" type="text" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Contact Number is required " 
                    ControlToValidate="contactNoText" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Address
            </td>
            <td>
                <input id="addressText" runat="server" type="text" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="Address is required" ControlToValidate="addressText" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
        </tr>
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
                Registation Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <input id="dateText" type="text" runat="server" class="date" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator 
                    ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Registation date is required" ControlToValidate="dateText" 
                    ForeColor="#CC3300">*</asp:RequiredFieldValidator>
                &nbsp; &nbsp;&nbsp;
            </td>
        </tr>
        </table>
        
        <fieldset>
            
            <legend>Education</legend>
            
      <table border="1">
               <tr>
            <td>
                Exam
            </td>
            <td>
                <asp:DropDownList ID="examSelectDropDownList" runat="server">
                </asp:DropDownList>
            </td>
            </tr>
            <tr>
                <td>
                    Grade Letter/Others&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
                <td >
                      <input id="gradeLetterTextBox" type="text" runat="server" />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                          ErrorMessage="Grade letter is required" 
                          ControlToValidate="gradeLetterTextBox" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
              
            </tr>
            
            <tr>
                <td>
                   CGPA/Percentage  
                </td>
                <td>
                 <input id="cgpaTextBox" type="text" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ErrorMessage="Cgpa is required" ControlToValidate="cgpaTextBox" 
                        ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
            </tr>
      <tr>
          <td>
            Certificate Location   
          </td>
          <td>
           <asp:FileUpload ID="certificateUpload" runat="server" />&nbsp;
             
              <asp:Label ID="statusLabel" runat="server" Text=""></asp:Label>
          </td>
      </tr>
   <tr>
       <td colspan="2">
           <asp:Button ID="addIntoListButton" runat="server" Text="Add Into List" 
               onclick="addIntoListButton_Click" />  
           
           
       </td>
   </tr>
   </table>
        </fieldset>
        
        <fieldset>
            
            <legend>List</legend>
            
             <table>
  
   <tr>
       <td colspan="2">
           <asp:GridView ID="certificateGridView" runat="server" AutoGenerateColumns="False" 
               CellPadding="4" ForeColor="#333333" GridLines="None">
               <AlternatingRowStyle BackColor="White" />
               <Columns>
                   <asp:BoundField DataField="ExaminationType" HeaderText="Exam" />
                   <asp:BoundField DataField="GradeLetter" HeaderText="Grade Letter" />
                   <asp:BoundField DataField="Cgpa" HeaderText="CGPA" />
                   <asp:BoundField DataField="Status" 
                       HeaderText="Attached Certificate" />
               </Columns>
               <EditRowStyle BackColor="#7C6F57" />
               <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
               <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
               <RowStyle BackColor="#E3EAEB" />
               <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
               <SortedAscendingCellStyle BackColor="#F8FAFA" />
               <SortedAscendingHeaderStyle BackColor="#246B61" />
               <SortedDescendingCellStyle BackColor="#D4DFE1" />
               <SortedDescendingHeaderStyle BackColor="#15524A" />
           </asp:GridView>    
       </td>
   </tr>
   

    </table>
        </fieldset>
       
</fieldset>
 <asp:Button ID="registerButton" runat="server" Text="Register" 
               onclick="registerButton_Click" />   <br/>
               
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
        HeaderText="This page contains following errors: " />
    <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
    </asp:Content>
