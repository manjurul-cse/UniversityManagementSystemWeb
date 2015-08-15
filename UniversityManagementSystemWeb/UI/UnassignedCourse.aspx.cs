using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.Manager;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace UniversityManagementSystemWeb.UI
{
    public partial class UnassignedCourse : System.Web.UI.Page
    {
        private DepartmentManager aDepartmentManager;
        private ScheduleManager aScheduleManager;
        protected void Page_Load(object sender, EventArgs e)
        {
            msgLabel.Text = "";
            try
            {

                departmentDropDownList.DataTextField = "DepartmentCode";
                departmentDropDownList.DataValueField = "departmentId";
                semesterDropDownList.DataTextField = "SemesterName";
                semesterDropDownList.DataValueField = "SemesterId";
                if (!IsPostBack)
                {
                    List<Department> departments = new List<Department>();
                    List<Semester> semester = new List<Semester>();
                    aDepartmentManager = new DepartmentManager();
                    departments = aDepartmentManager.GetAllDepartments();
                    SemesterManager aSemesterManager = new SemesterManager();
                    semester = aSemesterManager.GetAllSemesters();
                    departmentDropDownList.DataSource = departments;
                    departmentDropDownList.DataBind();
                    semesterDropDownList.DataSource = semester;
                    semesterDropDownList.DataBind();
                    GetAllUnassignedCourses();
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

        protected void pdfButton_Click(object sender, EventArgs e)
        {

            try
            {
                List<Course> courses = new List<Course>();
                Course course = new Course();
                CourseManager aCourseManager = new CourseManager();
                course.ADepartment = new Department();
                course.ASemester = new Semester();
                course.ADepartment.DepartmentId = Convert.ToInt16(departmentDropDownList.Text);
                course.ASemester.SemesterId = Convert.ToInt16(semesterDropDownList.Text);
                course.CourseStatus = 0;
                courses = aCourseManager.GetAllUnassignedCourses(course);
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                string pdfFilePath = Server.MapPath("CoursePdf.pdf");
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(pdfFilePath, FileMode.Create));
                doc.Open(); //Open Document to write
                iTextSharp.text.Font font8 = FontFactory.GetFont("ARIAL", 7);
                string heading = "      Unassigned Course Details for Department: " +
                                        departmentDropDownList.SelectedItem + " and Semester: " +
                                        semesterDropDownList.SelectedItem;
                Paragraph reportHeading = new Paragraph(heading);
                if (courses != null)
                {
                    PdfPTable PdfTable = new PdfPTable(4);
                    PdfPCell PdfPCell = null;
                    PdfPCell = new PdfPCell(new Phrase(new Chunk("Course Code", font8)));
                    PdfTable.AddCell(PdfPCell);
                    PdfPCell = new PdfPCell(new Phrase(new Chunk("Course Name", font8)));
                    PdfTable.AddCell(PdfPCell);
                    PdfPCell = new PdfPCell(new Phrase(new Chunk("Credit", font8)));
                    PdfTable.AddCell(PdfPCell);
                    PdfPCell = new PdfPCell(new Phrase(new Chunk("Course Description", font8)));
                    PdfTable.AddCell(PdfPCell);
                    foreach (Course aCourse in courses)
                    {
                        PdfPCell = new PdfPCell(new Phrase(new Chunk(aCourse.CourseCode, font8)));
                        PdfTable.AddCell(PdfPCell);
                        PdfPCell = new PdfPCell(new Phrase(new Chunk(aCourse.CourseName, font8)));
                        PdfTable.AddCell(PdfPCell);
                        PdfPCell = new PdfPCell(new Phrase(new Chunk(aCourse.Description, font8)));
                        PdfTable.AddCell(PdfPCell);
                        PdfPCell = new PdfPCell(new Phrase(new Chunk((aCourse.Credit).ToString(), font8)));
                        PdfTable.AddCell(PdfPCell);
                    }
                    PdfTable.SpacingBefore = 15f;
                    doc.Add(reportHeading);
                    doc.Add(PdfTable);
                    doc.Close();
                    WebClient client = new WebClient();
                    Byte[] buffer = client.DownloadData(pdfFilePath);
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.BinaryWrite(buffer);
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

        protected void semesterDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                GetAllUnassignedCourses();
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

        private void GetAllUnassignedCourses()
        {

            try
            {
                List<Course> courses = new List<Course>();
                Course aCourse = new Course();
                CourseManager aCourseManager = new CourseManager();
                aCourse.ADepartment = new Department();
                aCourse.ASemester = new Semester();
                aCourse.ADepartment.DepartmentId = Convert.ToInt16(departmentDropDownList.Text);
                aCourse.ASemester.SemesterId = Convert.ToInt16(semesterDropDownList.Text);
                aCourse.CourseStatus = 0;
                courses = aCourseManager.GetAllUnassignedCourses(aCourse);
                courseGridView.DataSource = courses;
                courseGridView.DataBind();
            }
            catch (Exception exception)
            {
                
                throw exception;
            }

           
        }
    }
}