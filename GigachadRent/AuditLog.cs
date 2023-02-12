using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
    }
}
