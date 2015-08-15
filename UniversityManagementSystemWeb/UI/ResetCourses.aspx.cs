using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystemWeb.Manager;

namespace UniversityManagementSystemWeb.UI
{
    public partial class ResetCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLabel.Text = "";
        }

        protected void resetButton_Click(object sender, EventArgs e)
        {
            try
            {
                CourseManager aCourseManager = new CourseManager();
                string msg = aCourseManager.ResetCourseScheduleAndUnassignedAllCourse();
                msgLabel.ForeColor = Color.Green;
                msgLabel.Text = msg;
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