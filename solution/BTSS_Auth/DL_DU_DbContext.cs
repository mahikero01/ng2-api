using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BTSS_Auth
{
    public class DL_DU_DbContext
    {
        #region "Private/Public Attribute"

        private SqlConnection _dbConnection;
        private string _serverInfo;

        #endregion "Private/Public Attribute"

        #region "Public Attribute"

        public string _errorMessage = "";

        #endregion "Public Attribute"

        #region "Private Method"

        private void GetDBConnection()
        {
            this._serverInfo = ConfigurationManager.ConnectionStrings["ng2Context"].ToString();
            this._dbConnection = new SqlConnection(this._serverInfo);
        }

        private void CloseConnection()
        {
            this._dbConnection.Close();
            this._serverInfo = "";
        }

        #endregion "Private Method"

        #region "Public Method"

        public DataTable GetData(string queryStatement, SqlParameterCollection queryParameter)
        {
            DataTable resultSet = null;

            try
            {
                this.GetDBConnection();
                SqlCommand query = new SqlCommand(queryStatement, this._dbConnection);
                query.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter parameter in queryParameter)
                {
                    query.Parameters.Add(parameter.ParameterName, parameter.SqlDbType).Value = parameter.Value;
                }

                this._dbConnection.Open();

                SqlDataAdapter dbAdapter = new SqlDataAdapter(query);
                resultSet = new DataTable();
                dbAdapter.Fill(resultSet);

                dbAdapter.Dispose();
                dbAdapter = null;
                query.Dispose();
                query = null;
            }
            catch (SqlException sqlException)
            {
                _errorMessage = "SQL Error: Number - " + sqlException.Number + ", " + sqlException.Message;
                resultSet = null;
            }
            catch (Exception exception)
            {
                _errorMessage = "Runtime Error - " + exception.Message;
                resultSet = null;
            }
            finally
            {
                this.CloseConnection();
            }

            return resultSet;
        }

        #endregion "Public Method"
    }
}