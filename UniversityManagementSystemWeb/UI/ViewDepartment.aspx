<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDepartment.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.ViewDepartment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <fieldset>
        <legend>Show All Department</legend>
          <asp:GridView ID="departmentGridView" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="departmentCode" HeaderText="Code" 
                SortExpression="Code" />
            <asp:BoundField DataField="departmentName" HeaderText="Name" 
                SortExpression="Name" />
        </Columns>
    </asp:GridView>

        <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>

    </fieldset>
        
       
    
   
</asp:Content>
