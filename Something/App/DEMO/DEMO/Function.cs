using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace DEMO
{
    public class DataReader
    {
        public static OleDbConnection connection
        {
            get { return new OleDbConnection(""); }
        }
    }

    public class DataChenger
    {
        public static DataTable Data()
        {
            string NameTable = null;
            OleDbConnection connection = DataReader.connection;

            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet data = new DataSet();
            adapter.Fill(data);
            connection.Close();

            return data.Tables[0];
        }
    }

    public class Registration
    {

    }
}
