using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Report_Service.Models
{
    public class Databaseconnection
    {
        string db;
        string connstr = "";
        #region connection
        SqlConnection cnn;
        public Databaseconnection()
        {
            setconnstr();
        }
        private void setconnstr()
        {
            string server = ConfigurationManager.AppSettings.Get("Server");
            db = ConfigurationManager.AppSettings.Get("DataBase");
            string user = ConfigurationManager.AppSettings.Get("User");
            string pass = ConfigurationManager.AppSettings.Get("Password");
            connstr = "Data Source=" + server + ";Initial Catalog=" + db + ";User ID=" + user + ";Password=" + pass;
            cnn = new SqlConnection(connstr);
        }
        public SqlConnection get_connection() { return cnn; }
        private void closeconnection()
        {
            cnn.Close();
        }

        public void executeNonQuery(string sql)
        {

            if (sql != "" && sql != null)
            {
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                cnn.Open();
                command = new SqlCommand(sql, cnn);
                adapter.InsertCommand = new SqlCommand(sql, cnn);
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();
                closeconnection();
            }
        }
        #endregion
    }
}