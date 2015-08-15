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
    public partial class DepartmentEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLabel.Text = "";
        }

        private Department aDepartment;
        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (!IsValid)
            {
                return;
            }

            if (codeTextBox.Value.Length < 3)
            {
                msgLabel.ForeColor = Color.Red;
                msgLabel.Text = "Department Code Must be Three Character";
                return;
            }
            DepartmentManager aDepartmentManager = new DepartmentManager();
            try
            {
                aDepartment = new Department();
                aDepartment.DepartmentCode = codeTextBox.Value;
                aDepartment.DepartmentName = nameTextBox.Value;
                string msg = aDepartmentManager.SaveDepartment(aDepartment);
                if (msg == "Saved")
                {
                    msgLabel.ForeColor = Color.Green;
                    msgLabel.Text = msg;
                    ClearAllTextBoxses();
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

        private void ClearAllTextBoxses()
        {
            codeTextBox.Value = "";
            nameTextBox.Value = "";
        }


    }
}