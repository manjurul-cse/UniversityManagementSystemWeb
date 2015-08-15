using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWeb.DAL.Gateway
{
    public class DBGateway
    {
       protected SqlConnection connection;
       protected SqlCommand command;




        public DBGateway()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["UMSDBConnection"].ConnectionString);
            command = new SqlCommand();
            command.Connection = connection;
        }

        //public SqlConnection Connection
        //{
        //    get
        //    {
        //        return connection;
        //    }
        //}

        //public SqlCommand Command
        //{
        //    get
        //    {
        //        command.Connection = connection;
        //        return command;
        //    }
        //}


    }
}