<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ScheduleClass.aspx.cs" Inherits="UniversityManagementSystemWeb.UI.ScheduleClass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend>Schedule Class</legend>
        <table style="width:100%" border="1">
            <tr>
                <td>
                    Department
                </td>
                <td>
                    <asp:DropDownList ID="departmentDropDownList" runat="server" 
                        AutoPostBack="True">
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
                    Building
                </td>
                <td>
                    <asp:DropDownList ID="buildingDropDownList" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="buildingDropDownList_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Room
                </td>
                <td>
                    <asp:DropDownList ID="roomDropDownList" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Day
                </td>
                <td>
                    <asp:DropDownList ID="dayDropDownList" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Time From
                </td>
                <td>
                    <asp:DropDownList ID="startTimeDropDownList" runat="server" AutoPostBack="True">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                    
                    &nbsp; To&nbsp;
                     <asp:DropDownList ID="endingTimeDropDownList" runat="server" AutoPostBack="True">
                         <asp:ListItem>1.59</asp:ListItem>
                        <asp:ListItem>2.59</asp:ListItem>
                        <asp:ListItem>3.59</asp:ListItem>
                        <asp:ListItem>4.59</asp:ListItem>
                        <asp:ListItem>5.59</asp:ListItem>
                        <asp:ListItem>6.59</asp:ListItem>
                        <asp:ListItem>7.59</asp:ListItem>
                        <asp:ListItem>8.59</asp:ListItem>
                        <asp:ListItem>9.59</asp:ListItem>
                        <asp:ListItem>10.59</asp:ListItem>
                        <asp:ListItem>11.59</asp:ListItem>
                        <asp:ListItem>12.59</asp:ListItem>
                        <asp:ListItem>13.59</asp:ListItem>
                        <asp:ListItem>14.59</asp:ListItem>
                        <asp:ListItem>15.59</asp:ListItem>
                        <asp:ListItem>16.59</asp:ListItem>
                        <asp:ListItem>17.59</asp:ListItem>
                        <asp:ListItem>18.59</asp:ListItem>
                        <asp:ListItem>19.59</asp:ListItem>
                        <asp:ListItem>20.59</asp:ListItem>
                        <asp:ListItem>21.59</asp:ListItem>
                        <asp:ListItem>22.59</asp:ListItem>
                        <asp:ListItem>23.59</asp:ListItem>
                    </asp:DropDownList>
                </td>
           
       
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:Button ID="saveButton" runat="server" Text="Save" 
                        onclick="saveButton_Click" Width="76px" />
                    
                </td>
            </tr>
        </table>
    </fieldset>
    
    <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
</asp:Content>
