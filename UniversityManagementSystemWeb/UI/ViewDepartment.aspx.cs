using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.Manager;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html;

namespace UniversityManagementSystemWeb.UI
{
    public partial class ViewDepartment : System.Web.UI.Page
    {
        private List<Department> departments;
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLabel.Text = "";
            departments = new List<Department>();
           
            
            DepartmentManager aDepartmentManager = new DepartmentManager();

            if (!IsPostBack)
            {
                try
                {
                    departments = aDepartmentManager.GetAllDepartments();
                    departmentGridView.DataSource = departments;
                    departmentGridView.DataBind();
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
}