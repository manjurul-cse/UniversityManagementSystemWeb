using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class ViewResult
    {
        
        private double enrolledCredit;
        private double completedCredit;
        private double cgpa;
        private string gradeLetter;
        private int noOfEnrolledCourses;
        private int noOfCompletedCourses;
        private double subjectCgpa;
       
        
     


        public double EnrolledCredit
        {
            get { return enrolledCredit; }
            set { enrolledCredit = value; }
        }

        public double CompletedCredit
        {
            get { return completedCredit; }
            set { completedCredit = value; }
        }

        public double Cgpa
        {
            get { return cgpa; }
            set { cgpa = value; }
        }

        public string GradeLetter
        {
            get { return gradeLetter; }
            set { gradeLetter = value; }
        }

        public int NoOfEnrolledCourses
        {
            get { return noOfEnrolledCourses; }
            set { noOfEnrolledCourses = value; }
        }

        public int NoOfCompletedCourses
        {
            get { return noOfCompletedCourses; }
            set { noOfCompletedCourses = value; }
        }

        public double SubjectCgpa
        {
            get { return subjectCgpa; }
            set { subjectCgpa = value; }
        }
    }
}