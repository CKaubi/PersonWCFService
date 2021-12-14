using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataBaseProvaider
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class DataBaseProvaider : IDataBaseProvaider
    {

        [OperationBehavior]
        public DataSet FindNameByChar(char simbol, int request)
        {

            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks2019"].ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("FindNamesByChar", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramChar = new SqlParameter
                {
                    ParameterName = "@char",
                    Value = simbol
                };

                SqlParameter paramReqyest = new SqlParameter
                {
                    ParameterName = "@request",
                    Value = request
                };

                command.Parameters.Add(paramChar);
                command.Parameters.Add(paramReqyest);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(ds);
            }
            return ds;
        }
    }
}
