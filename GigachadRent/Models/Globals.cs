using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace GigachadRent.Models
{
    public static class Globals
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string BackupPath { get; set; } = "";
        public static string Server { get; set; }

        public static void SetServer(string servName)
        {
            try {
                CloseConnection();
                ConnectionString = $"Data Source={servName};Initial Catalog=GigachadRent;Integrated Security=True";
                Server = servName;
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
            if (Connection != null)
                Connection.Close();
        }
        public static void Execute(string commandText, bool quiet = true)
        {
            try {
                var connection = OpenConnection();
                SqlCommand command = new SqlCommand(commandText) {
                    Connection = connection
                };

                var normalized = command.CommandText.ToLower();

                var backupName = "";
                if (normalized.Contains("insert") || normalized.Contains("update")) {

                    if(!Directory.Exists(BackupPath)) {
                        Directory.CreateDirectory(BackupPath);
                    }

                    backupName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                    var backup = $"backup database GigachadRent to DISK = '{BackupPath}\\{backupName}.bak'";
                    var cmd = new SqlCommand(backup) {
                        Connection = connection
                    };
                    cmd.ExecuteNonQuery();

                    Log($"{UserName} выполнил команду {commandText}", backupName);
                }
                command.ExecuteNonQuery();
                connection.Close();

                if (!quiet)
                    Log($"{UserName} выполнил команду {commandText}");
            }
            catch(Exception ee) {
                Console.WriteLine(ee.Message);
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

        public static void Log(string text, string backup = "")
        {
            if (!File.Exists("log.txt")) {
                File.WriteAllText("log.txt", $"[Дата {DateTime.Now}] [Действие]:  {text} {(backup != "" ? $"[{backup}.bak]" : "")}{Environment.NewLine}");
            } else {
                File.AppendAllText("log.txt", $"[Дата {DateTime.Now}] [Действие]: {text} {(backup != "" ? $"[{backup}.bak]" : "" )}{Environment.NewLine}");
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
