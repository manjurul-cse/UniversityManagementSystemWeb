using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    [Serializable]
    public class ViewStudentInformation
    {
        private string registationNo;
        private string name;
        private string email;
        private string departmentName;
        private int departmentId;

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

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        public int DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }
    }
}