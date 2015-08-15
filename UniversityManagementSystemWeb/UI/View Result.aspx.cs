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
    public partial class View_Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToString();
            msgLabel.Text = "";
            resultLabel.Text = "";
        }

        protected void regNoSearchButton_Click(object sender, EventArgs e)
        {
            if(!IsValid)
            {
                return;
            }

            try
            {
                string regNo = regNoTextBox.Value;

                GetResult(regNo);
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

        private void GetResult(string regNo)
        {
            try
            {
                StudentManager aStudentManager = new StudentManager();
                ResultManager aResultManager = new ResultManager();
                ViewStudentInformation aViewStudentInformation = new ViewStudentInformation();
                aViewStudentInformation = aStudentManager.GetStudentInformation(regNo);

                if (aViewStudentInformation.Name ==null)
                {
                    msgLabel.ForeColor = Color.Red;
                    msgLabel.Text = "Invalid Registation Number";
                    return;
                }
                  
                nameTextBox.Value = aViewStudentInformation.Name;
                emailTextBox.Value = aViewStudentInformation.Email;
                departmentTextBox.Value = aViewStudentInformation.DepartmentName;
                ViewResult aViewResult = new ViewResult();
                List<ViewCourseGradeAndCredit> viewCourseGradeAndCreditList = new List<ViewCourseGradeAndCredit>();
                viewCourseGradeAndCreditList = aResultManager.GetCourseResult(regNo);
                detailsResultGridView.DataSource = viewCourseGradeAndCreditList;
                detailsResultGridView.DataBind();
                aViewResult = aResultManager.GetSubjectCGPA(regNo);
                noOfEnrolledCoursesTextBox.Value = aViewResult.NoOfEnrolledCourses.ToString();
                noOfRemainingCoursesTextBox.Value =
                    (aViewResult.NoOfEnrolledCourses - aViewResult.NoOfCompletedCourses).ToString();
                noOfCompletedCoursesTextBox.Value = aViewResult.NoOfCompletedCourses.ToString();
                totalCreditEnrolledCoursesTextBox.Value = aViewResult.EnrolledCredit.ToString();
                completedCreditTextBox.Value = aViewResult.CompletedCredit.ToString();
                remainingCreditTextBox.Value = (aViewResult.EnrolledCredit - aViewResult.CompletedCredit).ToString();
                gradeLetterTextBox.Value = aViewResult.GradeLetter;
                cgpaTextBox.Value = aViewResult.Cgpa.ToString();
                if (aViewResult.NoOfEnrolledCourses != aViewResult.NoOfCompletedCourses||aViewResult.NoOfCompletedCourses==0)

                {
                    resultLabel.ForeColor = Color.Red;
                    resultLabel.Text = "You are not eligible to get the certificate";
                }
                   
                else
                {
                    resultLabel.ForeColor = Color.Green;
                    resultLabel.Text = "You are  eligible to get the certificate";    
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
    }
}