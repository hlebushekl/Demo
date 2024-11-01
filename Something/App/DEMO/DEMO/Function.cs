using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows;

namespace DEMO
{
    public class DataReader
    {
        public static OleDbConnection connection
        {
            get { return new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=3Norml.accdb"); }
        }
    }
    public class DataChenger
    {
        static readonly string Type = "Тип";
        static readonly string Name = "";
        static readonly string Phone = "+7 909 442 27 27";
        public static DataTable Data()
        {
            string NameTable = "";
            OleDbConnection connection = DataReader.connection;

            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet data = new DataSet();
            adapter.Fill(data);
            connection.Close();

            return data.Tables[0];
        }
        public static UIElement Clone(string a, int i)
        {
            string replace = a.Replace(Type, TabelInsertion(i, 2));
            replace = replace.Replace(Name, TabelInsertion(i, 5));
            replace = replace.Replace(Phone, TabelInsertion(i, 4));

            byte[] byteArray = Encoding.UTF8.GetBytes(replace);
            MemoryStream ms = new MemoryStream(byteArray);
            StreamReader str = new StreamReader(ms);
            XmlReader xamel = XmlReader.Create(str);
            StackPanel reder = (StackPanel)XamlReader.Load(xamel);

            return reder;
        }
        public static string TabelInsertion(int i, int j)
        {
            string result;
            DataTable table = Data();
            result = table.Rows[i][j].ToString();
            return result;
        }
        public static int Lenght()
        {
            int result;
            DataTable table = Data();
            result = table.Rows.Count;
            return result;
        }
    }
    public class Registrations
    {
        public static bool RegistrResult(string log, string pas, string number, string mail, string FIO)
        {
            bool result = true;
            string password = Hash.HashResult(pas);
            string phone = Conver(number);

            OleDbConnection connection = DataReader.connection;
            OleDbDataAdapter ad;
            DataSet set = new DataSet();

            connection.Open();
            ad = new OleDbDataAdapter("SELECT * FROM Пользователи", connection);
            ad.Fill(set);
            DataRow dr = set.Tables[0].NewRow();
            dr["Логин"] = log;
            dr["Пароль"] = password;
            dr["Доступ"] = "Базовый";
            dr["ФИО"] = FIO;
            dr["Номер_телефона"] = phone;
            dr["Почта"] = mail;
            set.Tables[0].Rows.Add(dr);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(ad);
            ad.Update(set);
            connection.Close();

            return result;
        }
        private static string Conver(string a)
        {
            string result = null;
            result = a.Remove(0,2);
            result = result.Replace(" ", "");
            return result;
        }
    }
    public class Authorization
    {
        public static bool Log(string log, string pas)
        {
            pas = Hash.HashResult(pas);
            OleDbConnection connection = DataReader.connection;
            OleDbDataReader reader;
            OleDbCommand command;
            string src = $@"SELECT * FROM Пользователи WHERE Логин = '{log}' AND Пароль = '{pas}'";

            connection.Open();
            command = new OleDbCommand(src, connection);
            reader = command.ExecuteReader();
            bool result = reader.Read();
            connection.Close();

            return result;
        }
        public static string Name(string log)
        {
            OleDbConnection connection = DataReader.connection;
            OleDbDataReader reader;
            OleDbCommand command;
            string FinderName = $@"SELECT ФИО FROM Пользователи WHERE Логин = '{log}'";

            connection.Open();
            command = new OleDbCommand(FinderName, connection);
            reader = command.ExecuteReader();
            reader.Read();
            string result = reader[0].ToString();
            connection.Close();

            return result;
        }
        public static string role(string log)
        {
            OleDbConnection connection = DataReader.connection;
            OleDbDataReader reader;
            OleDbCommand command;
            string FinderAccess = $@"SELECT Доступ FROM Пользователи WHERE Логин = '{log}'";

            connection.Open();
            command = new OleDbCommand(FinderAccess, connection);
            reader = command.ExecuteReader();
            reader.Read();
            string result = reader[0].ToString();
            connection.Close();

            return result;
        }
    }
    public class Hash
    {
        public static string HashResult(string a)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(a));
            string result = Convert.ToBase64String(hash);
            return result;
        }
    }
}
