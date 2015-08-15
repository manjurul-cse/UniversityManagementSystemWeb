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
    public partial class Result : System.Web.UI.Page
    {
        private DepartmentManager aDepartmentManager;
        private CourseManager aCourseManager;
        protected void Page_Load(object sender, EventArgs e)
        {

            msgLabel.Text = "";
            try
            {
                List<Course> courses = new List<Course>();
                List<Department> departments = new List<Department>();
                departmentDropDownList.DataTextField = "DepartmentCode";
                departmentDropDownList.DataValueField = "departmentId";
                courseDropDownList.DataTextField = "courseCode";
                courseDropDownList.DataValueField = "courseId";
                if (!IsPostBack)
                {
                    aDepartmentManager = new DepartmentManager();
                    departments = aDepartmentManager.GetAllDepartments();
                    aCourseManager = new CourseManager();
                    courses = aCourseManager.GetAllCourses();
                    departmentDropDownList.DataSource = departments;
                    departmentDropDownList.DataBind();
                    courseDropDownList.DataSource = courses;
                    courseDropDownList.DataBind();
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
     

            try
            {
                StudentResult aStudentResult = new StudentResult();
                aStudentResult.DepartmentId = Convert.ToInt16(departmentDropDownList.Text);
                aStudentResult.CourseId = Convert.ToInt16(courseDropDownList.Text);
                aStudentResult.RegistationNo = regNoTextBox.Value;
                aStudentResult.GradeLetter = gradeLetterDropDownList.SelectedItem.Text;
                ResultManager aResultManager = new ResultManager();
                string msg = aResultManager.SaveASubjectGrade(aStudentResult);
                if (msg == "Saved")
                {
                    msgLabel.ForeColor = Color.Green;
                    msgLabel.Text = msg;
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

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if(!IsValid)
            {
                return;
                
            }


            try
            {
                string regNo = regNoTextBox.Value;
                int depeartmentId = Convert.ToInt16(departmentDropDownList.Text);
                StudentManager aStudentManager = new StudentManager();
                Student aStudent = new Student();
                aStudent = aStudentManager.GetStudentInformation(regNo, depeartmentId);
                if (aStudent.RegistationNo == null)
                {
                    msgLabel.ForeColor = Color.Red;
                    msgLabel.Text = "Invalid Registation Number";
                }
                nameTextBox.Value = aStudent.Name;
                emailTextBox.Value = aStudent.Email;
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


    }
}