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
    public partial class CourseEnrollForStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLabel.Text = "";
            dateTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            enrollDropDownList.DataTextField = "CourseCode";
            enrollDropDownList.DataValueField = "CourseId";
        }

        protected void enrollButton_Click(object sender, EventArgs e)
        {
            if(!IsValid)
            {
                return;
            }

            try
            {
                StudentCourse aStudentCourse = new StudentCourse();
                aStudentCourse.RegistrationNo = registationNoTextBox.Text;
                aStudentCourse.EnrollDate = dateTextBox.Text;
                aStudentCourse.CourseId = Convert.ToInt16(enrollDropDownList.Text);
                aStudentCourse.Status = 0;
                StudentManager aStudentManager = new StudentManager();
                string msg = aStudentManager.SaveStudentCourse(aStudentCourse);
                if(msg=="Saved")
                {
                    msgLabel.ForeColor = Color.Green;
                    msgLabel.Text = msg;
                    ShowStudentAndCourseInfo();
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
            try
            {
                
                ShowStudentAndCourseInfo();
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

        private void ShowStudentAndCourseInfo()
        {
            try
            {
                StudentManager aStudentManager = new StudentManager();
                string regNo = registationNoTextBox.Text;
                ViewStudentInformation aViewStudentInformation = new ViewStudentInformation();
                aViewStudentInformation = aStudentManager.GetStudentInfo(regNo);
                if(aViewStudentInformation.Name==null)
                {
                    msgLabel.ForeColor = Color.Red;
                    msgLabel.Text = "Invalid registation Number";
                    return;
                }
                nameTextBox.Text = aViewStudentInformation.Name;
                emailTextBox.Text = aViewStudentInformation.Email;
                departmentTextBox.Text = aViewStudentInformation.DepartmentName;
                Course aCourse = new Course();
                List<Course> courses = new List<Course>();
                courses = aStudentManager.GetStudentCourses(regNo);
                enrollsubjectGridView.DataSource = courses;
                enrollsubjectGridView.DataBind();
                List<Course> courseList = new List<Course>();
                courseList = aStudentManager.GetAllcourses(aViewStudentInformation);
                enrollDropDownList.DataSource = courseList;
                enrollDropDownList.DataBind();

            }
            catch (Exception exception)
            {
                
                throw exception;
            }

            
        }



        protected void showAllCourseOfUniversityButton_Click(object sender, EventArgs e)
        {

            try
            {
                string departmentCode = departmentTextBox.Text;
                string regNo = registationNoTextBox.Text;
                StudentManager aStudentManager = new StudentManager();

                List<Course> courseList = new List<Course>();
                courseList = aStudentManager.GetStudentMinorCourses(departmentCode, regNo);
                enrollDropDownList.DataSource = courseList;
                enrollDropDownList.DataBind();
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