using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace AlmanackAuctionsWebApp.DBLayer
{
    public class sFunctions
    {

        public static System.Data.DataTable RunQuery(string Str)
        {
            // Get connection string
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = Str;
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            cmd.Connection = conn;
            cmd.CommandTimeout = 600;
            try
            {
                conn.Open();
                da.Fill(dt);
                return dt;
            }
            catch (SqlException exSql)
            {
                // Deadlock 
                // cErrorLogger.LogThisError2(exSql, Str.ToString() + "_cFunctions.ExecuteStatementConn");
                conn.Close();

                conn.Open();
                da.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                // cErrorLogger.LogThisError(ex, "cFunctions.RunQuery");
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                da.Dispose();
            }
        }

    }
}