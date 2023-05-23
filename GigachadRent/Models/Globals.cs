using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace GigachadRent.Models
{
    public static class Globals
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }

        public static void SetServer(string servName)
        {
            try {
                CloseConnection();
                ConnectionString = $"Data Source={servName};Initial Catalog=GigachadRent;Integrated Security=True";
                OpenConnection();
            }
            catch {
                throw new Exception("Не удалось соединится с сервером. Проверьте название указанного сервера на наличие ошибки или подключитесь к сети Интернет");
            }
        }

        public static SqlConnection Connection { get; set; }

        public static string ConnectionString { get; set; } =
            @"Data Source=DESKTOP-JB2KS99\SQLEXPRESS;Initial Catalog=GigachadRent;Integrated Security=True";
        public static SqlConnection OpenConnection()
        {
            try {
                Connection = new SqlConnection(ConnectionString);
                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();
                return Connection;
            }
            catch {
                throw new Exception("Не удалось соединится с сервером. Проверьте название указанного сервера на наличие ошибки или подключитесь к сети Интернет");
            }
        }

        public static void CloseConnection()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }
        public static void Execute(string commandText, bool quiet = true)
        {
            try {
                var connection = OpenConnection();
                SqlCommand command = new SqlCommand(commandText) {
                    Connection = connection
                };
                command.ExecuteNonQuery();
                connection.Close();

                if (!quiet)
                    Log($"{UserName} выполнил команду {commandText}");
            }
            catch {

            }
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

        public static object[] GetReaderResults(SqlDataReader reader, int columnCount)
        {
            object[] results = new object[columnCount];

            for(int i = 0; i < columnCount; i++) {
                results[i] = reader.IsDBNull(i) ? "" : reader.GetValue(i);
            }

            return results;
        }
    }
}
