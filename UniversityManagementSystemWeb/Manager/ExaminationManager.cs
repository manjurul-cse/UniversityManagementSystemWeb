using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;
using UniversityManagementSystemWeb.DAL.Gateway;

namespace UniversityManagementSystemWeb.Manager
{
    public class ExaminationManager
    {
       public List<Examination> GetAllExaminations()
        {
           ExaminationGateway anExaminationGateway=new ExaminationGateway();
           return anExaminationGateway.GetAllExaminations();

        }
    }
}