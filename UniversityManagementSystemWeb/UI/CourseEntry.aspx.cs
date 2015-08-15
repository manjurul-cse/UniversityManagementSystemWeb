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
    public partial class CourseEntry : System.Web.UI.Page
    {

        private DepartmentManager aDepartmentManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLabel.Text = "";
            try
            {

                List<Department> departments = new List<Department>();
                List<Semester> semester = new List<Semester>();
                departmentDropDownList.DataTextField = "DepartmentCode";
                departmentDropDownList.DataValueField = "departmentId";
                semesterDropDownList.DataTextField = "SemesterName";
                semesterDropDownList.DataValueField = "SemesterId";
                aDepartmentManager = new DepartmentManager();
                departments = aDepartmentManager.GetAllDepartments();
                SemesterManager aSemesterManager = new SemesterManager();
                semester = aSemesterManager.GetAllSemesters();

                if (!IsPostBack)
                {
                    departmentDropDownList.DataSource = departments;
                    departmentDropDownList.DataBind();
                    semesterDropDownList.DataSource = semester;
                    semesterDropDownList.DataBind();
                }
            }
            catch (Exception exception)
            {
                msgLabel.ForeColor = Color.Red;
                msgLabel.Text = exception.Message;
            }

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
              return;  
            }

            try
            {
                Course aCourse = new Course();
                aCourse.CourseCode = codeTextBox.Value;
                aCourse.CourseName = titleTextBox.Value;
                aCourse.Credit = Convert.ToDouble(creditTextBox.Value);
                aCourse.Description = descriptionTextBox.Value;
                aCourse.CourseStatus = 0;
                aDepartmentManager = new DepartmentManager();

                aCourse.ADepartment = aDepartmentManager.GetDepartment(Convert.ToInt16(departmentDropDownList.Text));
                SemesterManager aSemesterManager = new SemesterManager();
                aCourse.ASemester = aSemesterManager.GetSemester(Convert.ToInt16(semesterDropDownList.Text));
                CourseManager aCourseManager = new CourseManager();
                string msg = aCourseManager.SaveCourse(aCourse);

                if (msg == "Saved")
                {
                    msgLabel.ForeColor = Color.Green;
                    msgLabel.Text = msg;
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
            codeTextBox.Value = "";
            titleTextBox.Value = "";
            creditTextBox.Value = "";
            descriptionTextBox.Value = "";
        }
    }
}