using GigachadRent.Models;
using System;
using System.Windows.Forms;

namespace GigachadRent
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Globals.Read($"select * from AppUsers where Login = '{textBox1.Text}' AND Password = '{textBox2.Text}'").Read()) {
                this.Hide();
                Globals.UserName = textBox1.Text;
                new MainForm().Show();
            } else {
                Globals.CloseConnection();
                MessageBox.Show("Пользователя не существует или введенны неверные данные авторизации", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new RegForm().Show(this);
        }
    }
}