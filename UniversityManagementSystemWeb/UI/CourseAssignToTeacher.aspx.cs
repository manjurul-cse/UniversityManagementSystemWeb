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
    public partial class CourseAssignToTeacher : System.Web.UI.Page
    {
        
        private DepartmentManager aDepartmentManager;
        private CourseManager aCourseManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLabel.Text = "";
            try
            {
                List<Department> departments = new List<Department>();
                List<Course> courses = new List<Course>();
                departmentDropDownList.DataTextField = "DepartmentCode";
                departmentDropDownList.DataValueField = "departmentId";
                courseTitleDropDownList.DataTextField = "courseCode";
                courseTitleDropDownList.DataValueField = "courseId";
                teacherDropDownList.DataTextField = "name";
                teacherDropDownList.DataValueField = "teacherId";
                if (!IsPostBack)
                {
                    aDepartmentManager = new DepartmentManager();
                    aCourseManager = new CourseManager();
                    courses = aCourseManager.GetAllCourses();
                    departments = aDepartmentManager.GetAllDepartments();
                    departmentDropDownList.DataSource = departments;
                    departmentDropDownList.DataBind();
                    courseTitleDropDownList.DataSource = courses;
                    courseTitleDropDownList.DataBind();
                    GetTeachers();
                    GetCourses();

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

        protected void assignButton_Click(object sender, EventArgs e)
        {
            try
            {
                TeacherCourse aTeacherCourse = new TeacherCourse();
                TeacherManager aTeacherManager = new TeacherManager();
                aTeacherCourse.CourseId = Convert.ToInt16(courseTitleDropDownList.Text);
                aTeacherCourse.DepartmentId = Convert.ToInt16(departmentDropDownList.Text);
                aTeacherCourse.TeacherId = teacherDropDownList.Text;
                aTeacherCourse.AssignDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                aTeacherCourse.Status = 0;
                float credit = float.Parse(creditTextBox.Value);
                string msg = aTeacherManager.SaveTeacerCourse(aTeacherCourse, credit);
                if (msg == "Saved")
                {
                    msgLabel.ForeColor = Color.Green;
                    msgLabel.Text = msg;
                    GetTeacherAssignCredit();
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

        protected void departmentDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetTeachers();
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

        private void GetTeachers()
        {
            try
            {
                int departmentId = Convert.ToInt16(departmentDropDownList.Text);
                List<Teacher> teahers = new List<Teacher>();
                TeacherManager aTeacherManager = new TeacherManager();
                teahers = aTeacherManager.GetAllTeachers(departmentId);
                teacherDropDownList.DataSource = teahers;
                teacherDropDownList.DataBind();
                GetTeacherAssignCredit();
            }
            catch (Exception exception)
            {

                throw exception;
            }

           
        }


        protected void courseTitleDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                GetCourses();
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

        private void GetCourses()
        {
            try
            {
                Course aCourse = new Course();
                CourseManager aCourseManager = new CourseManager();
                aCourse = aCourseManager.GetCourse(Convert.ToInt16(courseTitleDropDownList.Text));
                nameTextBox.Value = aCourse.CourseName;
                creditTextBox.Value = aCourse.Credit.ToString();
            }
            catch (Exception exception)
            {
                
                throw exception;
            }
           
        }

        protected void teacherDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetTeacherAssignCredit();
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

        private void GetTeacherAssignCredit()
        {
            try
            {
                Teacher aTeacher = new Teacher();
                aTeacher.ADepartment = new Department();
                aTeacher.ADepartment.DepartmentId = Convert.ToInt16(departmentDropDownList.Text);
                aTeacher.TeacherId = teacherDropDownList.Text;
                TeacherManager aTeacherManager = new TeacherManager();
                aTeacher = aTeacherManager.GetTeacherCreditInfo(aTeacher);
                assignCreditTextBox.Text = aTeacher.AssignCredit.ToString();
                remainingCreditTextBox.Value = aTeacher.RemaningCredit.ToString();
            }
            catch (Exception exception)
            {

                throw exception;
            }

        }
    }
}