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
        public static DataTable Data(string a)
        {
            string NameTable = a;
            OleDbConnection connection = DataReader.connection;

            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet data = new DataSet();
            adapter.Fill(data);
            connection.Close();

            return data.Tables[0];
        }
    }

    public class Registrations
    {
        public static bool RegistrResult(string log, string pas, string number, string mail, string FIO)
        {
            bool result = true;



            return result;
        }
    }

    public class Authorization
    {
        public static bool Log(string log, string pas)
        {
            bool result = false;

            pas = Hash.HashResult(pas);

            OleDbConnection connection = DataReader.connection;
            OleDbDataReader reader;
            OleDbCommand command;
            string src = $@"SELECT * FROM Авторизация WHERE Логин = '{log}' AND Пароль = '{pas}'";

            connection.Open();
            command = new OleDbCommand(src, connection);
            reader = command.ExecuteReader();
            result = reader.Read();
            connection.Close();

            return result;
        }

        public static string Name(string log)
        {
            string result = null;

            OleDbConnection connection = DataReader.connection;
            OleDbDataReader reader;
            OleDbCommand command;
            string FinderName = $@"SELECT Имя FROM Авторизация WHERE Логин = '{log}'";

            connection.Open();
            command = new OleDbCommand(FinderName, connection);
            reader = command.ExecuteReader();
            result = reader[0].ToString();
            connection.Close();

            return result;
        }

        public static string role(string log)
        {
            string result = null;

            OleDbConnection connection = DataReader.connection;
            OleDbDataReader reader;
            OleDbCommand command;
            string FinderName = $@"SELECT Доступ FROM Авторизация WHERE Логин = '{log}'";

            connection.Open();
            command = new OleDbCommand(FinderName, connection);
            reader = command.ExecuteReader();
            result = reader[0].ToString();
            connection.Close();

            return result;
        }
    }

    public class Hash
    {
        public static string HashResult(string a)
        {
            string result = null;

            MD5 MD5Hash = MD5.Create();
            byte[] passwordBytes = Encoding.ASCII.GetBytes(a);
            byte[] hash = MD5Hash.ComputeHash(passwordBytes);
            result = Convert.ToString(hash);

            return result;
        }
    }
}
