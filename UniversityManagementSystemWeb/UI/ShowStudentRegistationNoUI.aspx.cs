using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystemWeb.DAL.DAO;

namespace UniversityManagementSystemWeb.UI
{
    public partial class ShowStudentRegistationNoUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLabel.Text = "";

            Student aStudent = (Student) Session["aStudent"];
            
            if(aStudent!=null)
            {
                msgLabel.ForeColor = Color.Green;
                msgLabel.Text = aStudent.Name + " with " + aStudent.Email + " email is registation no :" + aStudent.RegistationNo;
              
            }

            else
            {
                msgLabel.ForeColor = Color.Red;
                msgLabel.Text = "Not registered";


            }

        }
    }
}