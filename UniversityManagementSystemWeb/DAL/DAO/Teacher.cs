using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class Teacher
    {
        private string teacherId;
        private string name;
        private string address;
        private string email;
        private string contactNo;
        private Designation aDesignation;
        private Department aDepartment;
       
        private double assignCredit;
        private double remaningCredit;
       

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }

     

        public double AssignCredit
        {
            get { return assignCredit; }
            set { assignCredit = value; }
        }

        public Designation ADesignation
        {
            get { return aDesignation; }
            set { aDesignation = value; }
        }

        public Department ADepartment
        {
            get { return aDepartment; }
            set { aDepartment = value; }
        }

        public string TeacherId
        {
            get { return teacherId; }
            set { teacherId = value; }
        }

        public double RemaningCredit
        {
            get { return remaningCredit; }
            set { remaningCredit = value; }
        }
    }
}