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

        private void login_btn(object sender, EventArgs e)
        {
            try {
                if (Globals.Read($"select * from AppUsers where Login = '{textBox1.Text}' AND Password = '{textBox2.Text}'").Read()) {
                    this.Hide();
                    Globals.UserName = textBox1.Text;
                    MessageBox.Show("Вы успешно авторизовались!", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new MainForm().Show();
                } else {
                    Globals.CloseConnection();
                    MessageBox.Show("Пользователя не существует или введенны неверные данные авторизации!", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ee) {
                MessageBox.Show($"Ошибка подключения к базе данных {ee}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reg_btn(object sender, EventArgs e)
        {
            new RegForm().Show(this);
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }
    }
}