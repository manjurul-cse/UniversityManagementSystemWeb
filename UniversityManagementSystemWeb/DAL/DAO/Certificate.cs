using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.DAO
{
      [Serializable]
    public class Certificate
    {
        private string examinationType;
        private string gradeLetter;
        private string cgpa;
        private string certificateLocation;
        private string status;
         

    
        public string GradeLetter
        {
            get { return gradeLetter; }
            set { gradeLetter = value; }
        }

        public string Cgpa
        {
            get { return cgpa; }
            set { cgpa = value; }
        }

        public string CertificateLocation
        {
            get { return certificateLocation; }
            set { certificateLocation = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

          public string ExaminationType
          {
              get { return examinationType; }
              set { examinationType = value; }
          }

    }
}