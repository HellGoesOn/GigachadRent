using GigachadRent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GigachadRent
{
    public partial class AuditLog : Form
    {
        public AuditLog()
        {
            InitializeComponent();
        }

        private void AuditLog_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = File.ReadAllText("log.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            string escaped = Regex.Escape(".bak]");
            string pattern = $"(?<=\\[)(.*?)(?=\\.bak\\])";
            string match = Regex.Match(richTextBox1.SelectedText, pattern, RegexOptions.Singleline).Value;
            var backUpCommnad = $@"RESTORE DATABASE GigachadRent FROM DISK='{Globals.BackupPath}{match}.bak'";
            if (!string.IsNullOrEmpty(match)) {
                var diagResult =
                MessageBox.Show("Вы хотите восстановить резервную копию?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (diagResult == DialogResult.OK) {

                    using (SqlConnection conn = new SqlConnection(Globals.ConnectionString)) {
                        var useMaster = "USE Master";
                        conn.Open();
                        SqlCommand umc = new SqlCommand(useMaster, conn);
                        umc.ExecuteNonQuery();

                        var alter1 = @"ALTER DATABASE GigachadRent Set Single_User with rollback immediate";
                        new SqlCommand(alter1, conn).ExecuteNonQuery();
                        
                        new SqlCommand(backUpCommnad, conn).ExecuteNonQuery();

                        var alter2 = @"ALTER DATABASE GigachadRent Set Multi_User";
                        new SqlCommand(alter2, conn).ExecuteNonQuery();

                        MessageBox.Show("Восстановление завершено");
                        conn.Close();
                    }
                }
            }
        }
    }
}
