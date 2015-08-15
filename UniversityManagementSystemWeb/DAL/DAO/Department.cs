using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class Department
    {
        public Department()
        {

        }
        private int departmentId;
        private string departmentCode;
        private string departmentName;


        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        public string DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }

        public int DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }
    }
}