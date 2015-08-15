using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
    public class Examination
    {
        private string examinationId;
        private string examinationType;

        public string ExaminationId
        {
            get { return examinationId; }
            set { examinationId = value; }
        }

        public string ExaminationType
        {
            get { return examinationType; }
            set { examinationType = value; }
        }
    }
}