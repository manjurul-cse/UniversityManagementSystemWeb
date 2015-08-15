using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.Manager;

namespace UniversityManagementSystemWeb.UI
{
    public partial class StudentEntry : System.Web.UI.Page
    {
        List<Certificate> certificates = new List<Certificate>();
        private Student aStudent;
        private StudentManager aStudentManager;
        private List<Department> departments = new List<Department>();
        private List<Examination> examinations = new List<Examination>();
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLabel.Text = "";
            try
            {
                departmentDropDownList.DataTextField = "DepartmentCode";
                departmentDropDownList.DataValueField = "departmentId";
                examSelectDropDownList.DataTextField = "ExaminationType";
                examSelectDropDownList.DataValueField = "ExaminationId";

                if (!IsPostBack)
                {
                    aStudent = new Student();
                    ViewState["RegistationNo"] = "";
                    ViewState["Certificates"] = certificates;
                    Session["aStudent"] = aStudent;
                    DepartmentManager aDepartmentManager = new DepartmentManager();
                    departments = aDepartmentManager.GetAllDepartments();
                    ExaminationManager anExaminationManager = new ExaminationManager();
                    examinations = anExaminationManager.GetAllExaminations();
                    examSelectDropDownList.DataSource = examinations;
                    examSelectDropDownList.DataBind();
                    departmentDropDownList.DataSource = departments;
                    departmentDropDownList.DataBind();


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

        protected void registerButton_Click(object sender, EventArgs e)
        {

            if(!IsValid)
            {
                return;
            }
            try
            {
                aStudentManager = new StudentManager();
                Student aStudent = (Student)Session["aStudent"];
                certificates = (List<Certificate>)ViewState["Certificates"];
                aStudent.Certificates = certificates;
                string msg = aStudentManager.SaveStudent(aStudent);
                if (msg == "Saved")
                {
                    msgLabel.ForeColor = Color.Green;
                    Response.Redirect("~/UI/ShowStudentRegistationNoUI.aspx");
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

        private Student GetStudentInfo()
        {
            try
            {
                aStudentManager = new StudentManager();
                aStudent = new Student();
                aStudent.Name = nameText.Value;
                aStudent.Email = emailText.Value;
                aStudent.ContactNo = contactNoText.Value;
                aStudent.DepartmentId = departmentDropDownList.Text;
                aStudent.RegistationDate = dateText.Value;
                string year = aStudentManager.GetYear(dateText.Value);
                aStudent.Address = addressText.Value;
                string id = aStudentManager.GetStudentRegistationNO(aStudent);
                aStudent.RegistationNo = year + departmentDropDownList.SelectedItem.Text + id;
                return aStudent;
            }

            catch (Exception exception)
            {

                throw exception;
            }

        }

        private void MakeDirectoryIfNotExists(string NewDirectory)
        {
            try
            {
                if (!Directory.Exists(NewDirectory))
                {

                    Directory.CreateDirectory(NewDirectory);
                }
            }
            catch (IOException _ex)
            {
                Response.Write(_ex.Message);
            }
        }

        protected void addIntoListButton_Click(object sender, EventArgs e)
        {

            try
            {
                certificateGridView.DataSource = "";
                if (ViewState["RegistationNo"].ToString() == "")
                {
                    aStudent = GetStudentInfo();
                    Session["aStudent"] = aStudent;
                    ViewState["RegistationNo"] = aStudent.RegistationNo;
                }
                certificates = (List<Certificate>)ViewState["Certificates"];
                Certificate aCertificate = new Certificate();
                aCertificate.ExaminationType = examSelectDropDownList.SelectedItem.Text;
                aCertificate.GradeLetter = gradeLetterTextBox.Value;
                aCertificate.Cgpa = cgpaTextBox.Value;
                if (certificateUpload.HasFile)
                {
                    statusLabel.Text = "";
                    if (!certificateUpload.PostedFile.ContentType.ToLower().StartsWith("image") && certificateUpload.PostedFile.ContentType != "application/pdf")
                    {
                        msgLabel.ForeColor = Color.Red;
                        statusLabel.Text = "Incorrect file type.";
                    }

                    if (certificateUpload.PostedFile.ContentLength > 5120000)
                    {
                        msgLabel.ForeColor = Color.Red;
                        statusLabel.Text = "Image  size is large.";
                    }

                    string newDir = Server.MapPath("~/Certificate/" + ViewState["RegistationNo"].ToString() + "/" + examSelectDropDownList.SelectedItem.Text + "/");
                    MakeDirectoryIfNotExists(newDir);
                    if (ViewState["RegistationNo"].ToString() == "")
                    {
                        msgLabel.ForeColor = Color.Red;
                        statusLabel.Text = "Please Enter correct regNo";
                    }
                    else
                    {
                        string fileName = ViewState["RegistationNo"].ToString() + ".jpg";
                        string savePath = newDir + "/" + fileName;
                        certificateUpload.SaveAs(savePath);
                        aCertificate.CertificateLocation = savePath.ToString();
                        aCertificate.Status = "yes";
                        certificates.Add(aCertificate);
                        ViewState["Certificates"] = certificates;
                        statusLabel.ForeColor = Color.Green;
                        statusLabel.Text = "File Uploaded" + certificates.Count.ToString();
                        certificateGridView.DataSource = certificates;
                        certificateGridView.DataBind();
                    }
                }
                else
                {
                    msgLabel.ForeColor = Color.Red;
                    statusLabel.Text = "File not selected.";
                }
            }
            finally
            {

            }
        }
    }
}