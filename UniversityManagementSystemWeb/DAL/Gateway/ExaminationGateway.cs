using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;

namespace UniversityManagementSystemWeb.DAL.Gateway
{
    public class ExaminationGateway:DBGateway
    {
       public List<Examination> GetAllExaminations()
        {
           try
           {
               List<Examination> examinations = new List<Examination>();
               connection.Open();
               string examinationTypeQuery = "select * from t_Examination";
               command.CommandText = examinationTypeQuery;
               SqlDataReader examinationReader = command.ExecuteReader();
               while (examinationReader.Read())
               {
                   Examination anExamination = new Examination();
                   anExamination.ExaminationId = examinationReader[0].ToString();
                   anExamination.ExaminationType = examinationReader[1].ToString();
                   examinations.Add(anExamination);
               }
               
               return examinations;
           }
          
           finally
           {
               connection.Close();
           }


        }
    }
}