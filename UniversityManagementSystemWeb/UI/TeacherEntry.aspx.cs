using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.Manager;

namespace UniversityManagementSystemWeb.UI
{
    public partial class TeacherEntry : System.Web.UI.Page
    {
        private List<Department> departments = new List<Department>();
        private List<Designation> designation = new List<Designation>();
        private TeacherManager aTeacherManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLabel.Text = "";
            try
            {
                departmentDropDownList.DataTextField = "DepartmentCode";
                departmentDropDownList.DataValueField = "departmentId";
                designationDropDownList.DataTextField = "DesignationName";
                designationDropDownList.DataValueField = "Id";
                if (!IsPostBack)
                {
                    DepartmentManager aDepartmentManager = new DepartmentManager();
                    departments = aDepartmentManager.GetAllDepartments();
                    DesignationManager aDesignationManager = new DesignationManager();
                    aTeacherManager = new TeacherManager();
                    designation = aDesignationManager.GetAllDesignations();
                    departmentDropDownList.DataSource = departments;
                    departmentDropDownList.DataBind();
                    designationDropDownList.DataSource = designation;
                    designationDropDownList.DataBind();
                }
            }
            catch (SqlException sqlException)
            {
                msgLabel.ForeColor = Color.Red;
                msgLabel.Text = "Database error.See details error: " + sqlException.Message;
            }
            catch (Exception exception)
            {
                msgLabel.ForeColor = Color.Red;
                string errorMessage = "Unknow error occured.";
                errorMessage += exception.Message;
                if (exception.InnerException != null)
                {
                    errorMessage += exception.InnerException.Message;
                }
                msgLabel.Text = errorMessage;
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if(!IsValid)
            {
                return;
            }

            try
            {
                aTeacherManager = new TeacherManager();
                Teacher aTeacher = new Teacher();
                aTeacher.Name = nameTextBox.Value;
                aTeacher.Address = addressTextBox.Value;
                aTeacher.Email = emailTextBox.Value;
                aTeacher.ContactNo = contactNoTextBox.Value;
                aTeacher.AssignCredit = Convert.ToDouble(assignCreditTextBox.Value);
                DesignationManager aDesignationManager = new DesignationManager();
                aTeacher.ADesignation = aDesignationManager.GetDesignation(Convert.ToInt16(designationDropDownList.Text));
                DepartmentManager aDepartmentManager = new DepartmentManager();
                aTeacher.ADepartment = aDepartmentManager.GetDepartment(Convert.ToInt16(departmentDropDownList.Text));
                string teacherId = aTeacherManager.GetTeacherId(Convert.ToInt16(departmentDropDownList.Text));
                aTeacher.TeacherId = aTeacher.ADepartment.DepartmentCode.ToString() + "-" + teacherId + contactNoTextBox.Value;
                string msg = aTeacherManager.SaveTeacher(aTeacher);

                if (msg == aTeacher.TeacherId)
                {
                    msgLabel.ForeColor = Color.Green;
                    msgLabel.Text =aTeacher.Name+" your Id is :"+ msg;
                    ClearAllTextBoxes();
                }
                else
                {
                    msgLabel.ForeColor = Color.Red;
                    msgLabel.Text = msg;
                }
            }
            catch (SqlException sqlException)
            {
                msgLabel.ForeColor = Color.Red;
                msgLabel.Text = "Database error.See details error: " + sqlException.Message;
            }
            catch (Exception exception)
            {
                msgLabel.ForeColor = Color.Red;
                string errorMessage = "Unknow error occured.";
                errorMessage += exception.Message;
                if (exception.InnerException != null)
                {
                    errorMessage += exception.InnerException.Message;
                }
                msgLabel.Text = errorMessage;
            }
        }

        private void ClearAllTextBoxes()
        {
            nameTextBox.Value = "";
            addressTextBox.Value = "";
            emailTextBox.Value = "";
            contactNoTextBox.Value = "";
            assignCreditTextBox.Value = "";
        }
    }
}