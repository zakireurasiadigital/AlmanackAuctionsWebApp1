using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace AlmanackAuctionsWebApp.App_Start.Clasess
{

    public class SQLManager
    {
        // Declare Enumerators

        public enum DataTypes
        {
            ByteType = 1,
            ShortType = 2,
            IntegerType = 3,
            LongType = 4,
            DecimalType = 5,
            CharType = 6,
            StringType = 7,
            DateType = 8
        }

        public enum StatusTypes
        {
            InActive = 0,
            Active = 1,
            All = 2
        }

        //#1/1/1900 12:01:00 AM#
        public DateTime DatabaseDefaultDate = DateTime.Now;


        //Decalare member varables
        protected string m_strPrimaryFieldName;
        protected string m_strTableName;

        protected DataTypes m_enPrimaryFieldDataType;

        // The function returns the table name of current class
        private string GetTableName()
        {
            //Just return the value of member variable which is filled from child class
            return m_strTableName;
        }

        // The function returns the Primary Field Name of the table
        private string GetPrimaryFieldName()
        {
            //Just return the value of member variable which is filled from child class
            return m_strPrimaryFieldName;
        }

        // The function returns the PrimaryId of table of the current class
        private long GetId()
        {
            //Get the collection of all properties in the Property Descriptor Collection
            PropertyDescriptorCollection colProperties = GetProperties();

            //Get the value of Primary field of the Current record
            return Convert.ToInt32(colProperties[m_strPrimaryFieldName].GetValue(this));

        }

        // The function returns the Collection of the properties of the current class
        private PropertyDescriptorCollection GetProperties()
        {
            return TypeDescriptor.GetProperties(this);
        }

        // Procedure that Opens a connection for particular database

        private void OpenConnection(ref SqlConnection objSqlConnection)
        {
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            //Dim strConnection As String = System.Configuration.ConfigurationSettings.AppSettings("dbConnection")

            objSqlConnection.ConnectionString = strConnection;
            objSqlConnection.Open();

        }

        private void ClosedConnection(ref SqlConnection objSqlConnection)
        {
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;


            objSqlConnection.ConnectionString = strConnection;
            objSqlConnection.Close();

        }
        // Function thar returns the Data Table after executing a particular query
        protected DataTable GetDataTable(string strSql)
        {

            // Declare Objects locally
            SqlConnection objSqlConnection = new SqlConnection();
            SqlCommand objSqlCommand = default(SqlCommand);
            DataTable objDataTable = new DataTable();
            SqlDataAdapter objSqlDataAdapter = default(SqlDataAdapter);

            try
            {
                this.OpenConnection(ref objSqlConnection);
                objSqlCommand = new SqlCommand(strSql, objSqlConnection);
                objSqlCommand.CommandTimeout = 5000;
                objSqlDataAdapter = new SqlDataAdapter(objSqlCommand);
                objSqlDataAdapter.Fill(objDataTable);
                return objDataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

                objSqlConnection.Close();
            }

        }

        // Function thar returns the Data Reader after executing a particular query
        protected SqlDataReader GetDataReader(string strSql)
        {

            // Declare Objects locally
            SqlConnection objSqlConnection = new SqlConnection();
            SqlCommand objSqlCommand = default(SqlCommand);
            SqlDataReader objSqlDataReader = default(SqlDataReader);

            try
            {
                this.OpenConnection(ref objSqlConnection);
                objSqlCommand = new SqlCommand(strSql, objSqlConnection);
                objSqlDataReader = objSqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                objSqlCommand.Dispose();
            }

            return objSqlDataReader;
        }

        protected string GetScaler(string strSql)
        {

            // Declare Objects locally
            SqlConnection objSqlConnection = new SqlConnection();
            SqlCommand objSqlCommand = default(SqlCommand);
            string strReturned = null;
            try
            {
                this.OpenConnection(ref objSqlConnection);
                objSqlCommand = new SqlCommand(strSql, objSqlConnection);
                strReturned = objSqlCommand.ExecuteScalar().ToString();
                objSqlConnection.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
            }

            return strReturned;
        }

        // Function thar returns the Data Reader after executing a particular query
        protected bool IsRecordExists(string strFieldName, DataTypes enDataType, string strValueToCompare)
        {

            // Declare Objects locally
            string strSql = null;
            _ = new DataTable();
            try
            {
                strSql = "Select * from " + this.GetTableName() + " where " + strFieldName + " = ";

                if (enDataType == DataTypes.StringType | enDataType == DataTypes.DateType)
                {
                    strSql = strSql + "'" + strValueToCompare + "'";
                }
                else
                {
                    strSql = strSql + strValueToCompare;
                }

                DataTable objDataTable = GetDataTable(strSql);
                if (objDataTable.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        // Function thar returns the Data Reader after executing a particular query
        protected bool IsRecordExists(string strSql)
        {

            // Declare Objects locally
            _ = new DataTable();
            try
            {
                DataTable objDataTable = GetDataTable(strSql);
                if (objDataTable.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        // Function thar returns the Data Reader after executing a particular query
        protected long GetCurrentId(string strTableName = "")
        {

            // Declare Objects locally
            _ = new DataTable();
            string strSql = null;
            try
            {
                if (string.IsNullOrEmpty(strTableName))
                {
                    strTableName = GetTableName();
                }
                // Define the query for getting newly added Id
                strSql = "Select IDENT_CURRENT('" + strTableName + "') ";
                DataTable objDataTable = GetDataTable(strSql);
                if (objDataTable.Rows.Count > 0)
                {
                    return Convert.ToInt32(objDataTable.Rows[0][0]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }

        // Procedure that executes particular query without returning any value

        protected void ExecuteNonQuery(string strSql)
        {
            // Declare Objects locally
            SqlConnection objSqlConnection = new SqlConnection();
            SqlCommand objSqlCommand = default(SqlCommand);
            try
            {
                this.OpenConnection(ref objSqlConnection);
                objSqlCommand = new SqlCommand(strSql, objSqlConnection);
                objSqlCommand.CommandTimeout = 5000;
                objSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                objSqlCommand.Dispose();
                objSqlConnection.Close();
            }

        }

        // The function that Add / Edit the single Object contents to the database
        public void Save()
        {

            //Declaring local Objects & Variables
            DataTable objDataTable = new DataTable();
            DataRow objDataRow;
            SqlConnection objSqlConnection = new SqlConnection();
            string strSql = null;

            try
            {
                // Define a Select Query
                strSql = "Select * from " + this.GetTableName() + " where " + this.GetPrimaryFieldName().ToString() + "= " + this.GetId().ToString();

                // Declare and Instantiate the SqlDataAdapter
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(strSql, objSqlConnection);
                // Automatically generating single-table commands using SqlCommandBuilder
                SqlCommandBuilder objSqlCommandBuilder = new SqlCommandBuilder(objSqlDataAdapter);

                // Open Databse Connection
                this.OpenConnection(ref objSqlConnection);
                //Fill up the Datatable with passed query
                objSqlDataAdapter.Fill(objDataTable);

                // Check if either the Id is 0 or no rows was fetched from query
                if (this.GetId() == 0 | objDataTable.Rows.Count == 0)
                {
                    //Create a new row to the DataTable and assigned to objDataRow
                    objDataRow = objDataTable.NewRow();
                }
                else
                {
                    // Extracting the DataRow from the
                    objDataRow = objDataTable.Rows[0];
                }

                //Get the values from the properties and set to the Data Row
                GetValues(ref objDataTable, ref objDataRow);

                // Add DataRow to the DataTable
                if (this.GetId() == 0 | objDataTable.Rows.Count == 0)
                {
                    objDataTable.Rows.Add(objDataRow);
                }

                // Update the dataset through Command            
                objSqlDataAdapter.Update(objDataTable);

            }
            catch (Exception ex)
            {
            }
            finally
            {
                objSqlConnection.Close();
            }

        }

        protected virtual void SaveCustomerRole()
        {

            //Declaring local Objects & Variables
            DataTable objDataTable = new DataTable();
            DataRow objDataRow = default(DataRow);
            SqlConnection objSqlConnection = new SqlConnection();
            string strSql = null;

            try
            {
                // Define a Select Query
                strSql = "Select * from " + this.GetTableName() + " where " + this.GetPrimaryFieldName() + "= " + this.GetId().ToString();

                // Declare and Instantiate the SqlDataAdapter
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(strSql, objSqlConnection);
                // Automatically generating single-table commands using SqlCommandBuilder
                SqlCommandBuilder objSqlCommandBuilder = new SqlCommandBuilder(objSqlDataAdapter);

                // Open Databse Connection
                this.OpenConnection(ref objSqlConnection);
                //Fill up the Datatable with passed query
                objSqlDataAdapter.Fill(objDataTable);

                // Check if either the Id is 0 or no rows was fetched from query
                if (this.GetId() == 0 | objDataTable.Rows.Count == 0)
                {
                    //Create a new row to the DataTable and assigned to objDataRow
                    objDataRow = objDataTable.NewRow();
                }
                else
                {
                    // Extracting the DataRow from the DataTable
                    objDataRow = objDataTable.Rows[0];
                }

                //Get the values from the properties and set to the Data Row
                GetValues(ref objDataTable, ref objDataRow);

                // Add DataRow to the DataTable
                if (this.GetId() == 0 | objDataTable.Rows.Count == 0)
                {
                    objDataTable.Rows.Add(objDataRow);
                }

                // Update the dataset through Command            
                objSqlDataAdapter.Update(objDataTable);

            }
            catch (Exception ex)
            {
            }
            finally
            {
                objSqlConnection.Close();
            }

        }

        protected virtual void SaveStyleRole()
        {

            //Declaring local Objects & Variables
            DataTable objDataTable = new DataTable();
            DataRow objDataRow = default(DataRow);
            SqlConnection objSqlConnection = new SqlConnection();
            string strSql = null;

            try
            {
                // Define a Select Query
                strSql = "Select * from " + this.GetTableName() + " where " + this.GetPrimaryFieldName() + "= " + this.GetId().ToString();

                // Declare and Instantiate the SqlDataAdapter
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(strSql, objSqlConnection);
                // Automatically generating single-table commands using SqlCommandBuilder
                SqlCommandBuilder objSqlCommandBuilder = new SqlCommandBuilder(objSqlDataAdapter);

                // Open Databse Connection
                this.OpenConnection(ref objSqlConnection);
                //Fill up the Datatable with passed query
                objSqlDataAdapter.Fill(objDataTable);

                // Check if either the Id is 0 or no rows was fetched from query
                if (this.GetId() == 0 | objDataTable.Rows.Count == 0)
                {
                    //Create a new row to the DataTable and assigned to objDataRow
                    objDataRow = objDataTable.NewRow();
                }
                else
                {
                    // Extracting the DataRow from the DataTable
                    objDataRow = objDataTable.Rows[0];
                }

                //Get the values from the properties and set to the Data Row
                GetValues(ref objDataTable, ref objDataRow);

                // Add DataRow to the DataTable
                if (this.GetId() == 0 | objDataTable.Rows.Count == 0)
                {
                    objDataTable.Rows.Add(objDataRow);
                }

                // Update the dataset through Command            
                objSqlDataAdapter.Update(objDataTable);

            }
            catch (Exception ex)
            {
            }
            finally
            {
                objSqlConnection.Close();
            }

        }


        // The function gets any object by providing the particular Id
        protected void GetById(long lIdToGet)
        {

            //Declaring local Objects & Variables
            SqlDataReader objDataReader = default(SqlDataReader);
            string strSql = null;
            try
            {
                // Defining Select Query
                strSql = "Select * from " + GetTableName() + " where " + GetPrimaryFieldName() + " = ";

                if (m_enPrimaryFieldDataType == DataTypes.StringType | m_enPrimaryFieldDataType == DataTypes.DateType)
                {
                    strSql = strSql + "'" + lIdToGet + "'";
                }
                else
                {
                    strSql = strSql + lIdToGet;
                }

                // Get the datareader filled by above query
                objDataReader = this.GetDataReader(strSql);

                while ((objDataReader.Read()))
                {
                    //Set the values to the properties getting from Datareader
                    SetValues(ref objDataReader);
                }


                // Catch any error
            }
            catch (Exception)
            {
            }
        }

        // The function gets any object by providing the particular FieldName and FieldDataType
        protected void GetById(string strSql)
        {

            //Declaring local Objects & Variables
            SqlDataReader objDataReader = default(SqlDataReader);
            try
            {
                // Get the datareader filled by above query
                objDataReader = this.GetDataReader(strSql);

                while ((objDataReader.Read()))
                {
                    //Set the values to the properties getting from Datareader
                    SetValues(ref objDataReader);
                }


                // Catch any error
            }
            catch (Exception)
            {
            }
        }

        // Procedure that Get the values from the properties and set to the Data Row

        private void GetValues(ref DataTable objDataTable, ref DataRow objDataRow)
        {
            // Declare Variables locally
            int nIndex = 0;
            string strPropertyName = null;
            try
            {
                // Declare and Get the Collecetion Properties
                PropertyDescriptorCollection colProperties = this.GetProperties();

                //Traverse between Properties
                for (nIndex = 0; nIndex <= colProperties.Count - 1; nIndex++)
                {
                    // Getting property name
                    strPropertyName = colProperties[nIndex].Name;
                    // Check for ReadOnly property
                    if (!objDataTable.Columns[strPropertyName].ReadOnly)
                    {
                        //Assign property's value to DataRow
                        // objDataRow[strPropertyName] = colProperties[strPropertyName].GetValue(this);
                        objDataRow[strPropertyName] = colProperties[strPropertyName].GetValue(this) == null ? DBNull.Value : colProperties[strPropertyName].GetValue(this);
                        //objDataRow(strPropertyName) = If(colProperties.Item(strPropertyName).GetValue(Me) Is Nothing, DBNull.Value, colProperties.Item(strPropertyName).GetValue(Me))//VB.net

                    }
                }
            }
            catch (Exception)
            {
            }
        }

        // Procedure that Set the values to the properties getting from Datareader

        private void SetValues(ref SqlDataReader objDataReader)
        {
            // Declare Variables locally
            int nIndex = 0;
            string strPropertyName = null;
            try
            {
                // Declare and Get the Collecetion Properties
                PropertyDescriptorCollection colProperties = GetProperties();

                //Traverse between Properties
                for (nIndex = 0; nIndex <= colProperties.Count - 1; nIndex++)
                {
                    // Getting property name
                    strPropertyName = colProperties[nIndex].Name;

                    if (!System.Convert.IsDBNull(objDataReader[strPropertyName]))
                    {
                        //Sets the value to the item of the Prperty Collection
                        colProperties[nIndex].SetValue(this, objDataReader[strPropertyName]);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        public DateTime GetDate(string YourDate)
        {
            try
            {
                DateTime MyDate;
                int Year = Convert.ToInt32(YourDate.Substring(6, 4));
                int Day = Convert.ToInt32(YourDate.Substring(0, 2));
                int Month = Convert.ToInt32(YourDate.Substring(3, 2));
                MyDate = new DateTime(Year, Month, Day);
                return MyDate;
                //    MyDate = New Date(Year, Month, Day)
                //    Return MyDate
            }
            catch (Exception) { }
            return DateTime.Now.Date;
        }

        //public void GetDateFormat(string YourDate)
        //{
        //    try
        //    {
        //        string MyDate;
        //        string Year = YourDate.Substring(6, 4);
        //        string Day = YourDate.Substring(0, 2);
        //        string Month = YourDate.Substring(3, 2);
        //      //MyDate = new DateTime(Year, Month, Day);
        //        return MyDate;
        //        //    MyDate = New Date(Year, Month, Day)
        //        //    Return MyDate
        //    }
        //    catch (Exception ex) { }
        //    return DateTime.Now.Date;
        //}

    }
}