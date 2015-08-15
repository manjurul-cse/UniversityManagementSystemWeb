using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWeb.DAL.DAO;

namespace UniversityManagementSystemWeb.DAL.Gateway
{
    public class DesignationGateway:DBGateway
    {

        public List<Designation> GetAllDesignations()
        {
            try
            {

                List<Designation> designation = new List<Designation>();
                connection.Open();
                string designationQuery = "select * from t_Designation";
                command.CommandText = designationQuery;
                SqlDataReader designationReader = command.ExecuteReader();
                while (designationReader.Read())
                {
                    Designation aDesignation = new Designation();
                    aDesignation.Id = Convert.ToInt16(designationReader[0].ToString());
                    aDesignation.DesignationName = designationReader[1].ToString();
                    designation.Add(aDesignation);
                    //designation.Add(designationReader[0].ToString());

                }

                return designation;
            }
            finally
            {
                connection.Close();  
            }

            
        }
    }
}