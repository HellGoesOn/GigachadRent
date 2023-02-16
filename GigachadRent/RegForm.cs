using GigachadRent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GigachadRent
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void cancelReg_btn(object sender, EventArgs e)
        {
            this.Close();
        }

        private void doReg_btn(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)) {
                MessageBox.Show("Нельзя использовать введённые данные", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cmd = $"select * from appusers";
            var reader = Globals.Read(cmd);
            bool explode = false;
            while (reader.Read()) {
                if(reader.GetString(1) == textBox1.Text) {
                    explode = true;
                    break;
                }
            }
            reader.Close();

            if (explode) {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cmd = @$"insert into appusers(login, password) values ('{textBox1.Text}', '{textBox2.Text}')";
            Globals.Execute(cmd);
            Globals.Log($"Зарегистрирован новый пользователь: {textBox1.Text}");
            this.Close();
            MessageBox.Show("Регистрация завершена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
