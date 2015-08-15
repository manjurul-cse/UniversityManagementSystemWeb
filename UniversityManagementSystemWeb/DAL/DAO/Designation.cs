using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class Designation
    {
        private int id=0;
        private string designationName;

        public string DesignationName
        {
            get { return designationName; }
            set { designationName = value; }

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}