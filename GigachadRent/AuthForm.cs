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
        }

        private void reg_btn(object sender, EventArgs e)
        {
            new RegForm().Show(this);
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try {
                if (Globals.Read($"select * from AppUsers where Login = '{textBox3.Text}' AND Password = '{textBox4.Text}'").Read()) {
                    this.Hide();
                    Globals.UserName = textBox3.Text;
                    MessageBox.Show("�� ������� ��������������!", "�����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new MainForm().Show();
                } else {
                    Globals.CloseConnection();
                    MessageBox.Show("������������ �� ���������� ��� �������� �������� ������ �����������!", "������ ����� ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ee) {
                MessageBox.Show($"������ ����������� � ���� ������ {ee}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}