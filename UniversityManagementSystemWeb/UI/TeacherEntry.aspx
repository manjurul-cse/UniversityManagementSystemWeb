<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeacherEntry.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.TeacherEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
  
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
    <legend>Teacher Entry</legend>


       <table style="width: 100%" border="1">
        <tr>
            <td>
            Name
               
            </td>
            <td>
            
              <input id="nameTextBox" type="text" runat="server" onblur="name()" />    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="nameTextBox" ErrorMessage="Name is required" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
           
           
        </tr>
            <tr>
            <td>
             Address
                
            </td>
            <td>
            
              <input id="addressTextBox" type="text" runat="server"/>    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="addressTextBox" ErrorMessage="Address is required" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
            </td>
           
           
        </tr>
            <tr>
            <td>
           Email
                
            </td>
            <td> 
            
              <input id="emailTextBox" type="text" runat="server" />    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="emailTextBox" ErrorMessage="Email is required" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="emailTextBox" ErrorMessage="Invalid Email" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
           
           
        </tr>
            <tr>
            <td>
            Contact No
                
            </td>
            <td>
            
              <input id="contactNoTextBox" type="text" runat="server" />    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="contactNoTextBox" ErrorMessage="Contact number is required" 
                    ForeColor="#FF3300">*</asp:RequiredFieldValidator>
            </td>
           
           
        </tr>
            <tr>
            <td>
            Designation
                
            </td>
            <td>
             <asp:DropDownList ID="designationDropDownList" runat="server" 
                    AutoPostBack="True" Height="25px" Width="120px">
                </asp:DropDownList>
            
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
           Assign Credit
                
            </td>
            <td>
            
              <input id="assignCreditTextBox" type="text" runat="server" />    
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="assignCreditTextBox" 
                    ErrorMessage="Assign credit is required" ForeColor="#FF3300">*</asp:RequiredFieldValidator>
            </td>
           
           
        </tr>
            <tr>
            <td colspan="2" align="center">
                
                <asp:Button ID="saveButton" runat="server" Text="Save" 
                    onclick="saveButton_Click" style="height: 26px" Width="77px" />
                
            </td>
        
           
           
        </tr>
    
    </table>
  </fieldset>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ForeColor="#FF3300" HeaderText="This page contains following errors: " />
  <asp:Label ID="teacherIdLebel" runat="server"></asp:Label><br/>
  <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
</asp:Content>
