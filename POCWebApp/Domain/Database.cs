using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace POCWebApp.Domain
{
    public class Database
    {
        private string _ConnectionString;
        public Database()
        {
            string dbFile = HostingEnvironment.MapPath("/App_Data/DatabaseSystems_V11.mdb");
            _ConnectionString = @"Data Source = " + dbFile + ";Provider=Microsoft.Jet.OLEDB.4.0"; 
        }

        public DataSet ExecuteSQL(string sql)
        {
            var dataSet = new DataSet();

            using (OleDbConnection connection = new OleDbConnection(_ConnectionString))
            {
                // The insertSQL string contains a SQL statement that
                // inserts a new row in the source table.
                //OleDbCommand command = new OleDbCommand(sql);
                

                //// Set the Connection to the new OleDbConnection.
                //command.Connection = connection;

                // Open the connection and execute the insert command.
                try
                {
                    connection.Open();
                    //var reader = command.ExecuteReader();
                    var dataAdapter = new OleDbDataAdapter(sql,_ConnectionString);
                    dataAdapter.Fill(dataSet);

                    dataAdapter.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }

            return dataSet;
        }
    }
}