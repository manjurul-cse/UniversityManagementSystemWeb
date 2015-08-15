using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{[Serializable]
    public class Student
    {
        private string registationNo;
        private string name;
        private string email;
        private string contactNO;
        private string address;
        private string departmentId;
        private string registationDate;
        private List<Certificate> certificates; 

        public string RegistationNo
        {
            get { return registationNo; }
            set { registationNo = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ContactNo
        {
            get { return contactNO; }
            set { contactNO = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }

        public string RegistationDate
        {
            get { return registationDate; }
            set { registationDate = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public List<Certificate> Certificates
        {
            get { return certificates; }
            set { certificates = value; }
        }
    }
}