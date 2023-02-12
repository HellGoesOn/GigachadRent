using System;
using System.Data.SqlClient;
using System.IO;

namespace GigachadRent.Models
{
    public static class Globals
    {
        public static string ConnectionString { get; set; } =
            @"Data Source=DESKTOP-JB2KS99\SQLEXPRESS;Initial Catalog=GigachadRent;Integrated Security=True";
        public static string UserName { get; set; }
        public static string Password { get; set; }

        public static SqlConnection Connection { get; set; }

        public static SqlConnection OpenConnection()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            return Connection;
        }

        public static void CloseConnection()
        {
            Connection.Close();
        }
        public static void Execute(string commandText, bool quiet = true)
        {
            var connection = OpenConnection();
            SqlCommand command = new SqlCommand(commandText) {
                Connection = connection
            };
            command.ExecuteNonQuery();
            connection.Close();

            if(!quiet)
            Log($"{UserName} выполнил команду {commandText}");
        }

        public static SqlDataReader Read(string commandText, bool quiet = true)
        {
            var connection = OpenConnection();
            var command = new SqlCommand(commandText) { 
            Connection = connection};
            var reader = command.ExecuteReader();

            if (!quiet)
                Log($"{UserName} выполнил команду {commandText}");
            return reader;
        }

        public static void Log(string text)
        {
            if (!File.Exists("log.txt")) {
                File.WriteAllText("log.txt", $"[Дата {DateTime.Now}] [Действие]:  {text} {Environment.NewLine}");
            } else {
                File.AppendAllText("log.txt", $"[Дата {DateTime.Now}] [Действие]: {text} {Environment.NewLine}");
            }
        }
    }
}
