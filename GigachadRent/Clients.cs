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
    public partial class Clients : Form
    {
        int selectedId;

        public Clients()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void LoadData()
        {
            clientsGrid.Rows.Clear();
            var reader = Globals.Read($"Select * from clients");
            while(reader.Read()) {
                this.clientsGrid.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2));
            }
            Globals.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(maskedTextBox1.Text)) {
                MessageBox.Show("Введенные данные нельзя добавить в таблицу", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cmd = @$"insert into clients(name, phone) values ('{textBox1.Text}', '{maskedTextBox1.Text}')";
            Globals.Execute(cmd);
            Globals.Log($"{Globals.UserName} добавил клиента {textBox1.Text} в базу данных ");
            LoadData();
            selectedId = 0;

            MessageBox.Show($"Добавлен клиент {textBox1.Text}", "Данные добавлены", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите удалить эти данные?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                Globals.Execute($"DELETE FROM Clients WHERE Id = '{selectedId}'");
                Globals.Log($"{Globals.UserName} удалил клиента {textBox1.Text} из базы данных");
                if (selectedId == 0) {
                    MessageBox.Show("Не выбран ни один клиент для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
                selectedId = 0;
            }
        }

        private void clientsGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void clientsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = clientsGrid.SelectedCells[0].RowIndex;

            if (row < 0)
                return;

            selectedId = Convert.ToInt32(clientsGrid.Rows[row].Cells[0].Value);
            textBox1.Text = clientsGrid.Rows[row].Cells[1].Value.ToString();
            maskedTextBox1.Text = clientsGrid.Rows[row].Cells[2].Value.ToString();
        }

        private void Clients_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var cmd = @$"update Clients set name = '{textBox1.Text}', phone = '{maskedTextBox1.Text}' where Id = '{selectedId}'";
            Globals.Execute(cmd);
            Globals.Log($"{Globals.UserName} обновил данные клиента {textBox1.Text}");
            LoadData();
            selectedId = 0;

            MessageBox.Show($"Обновлены данные для клиента {textBox1.Text}", "Данные добавлены", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
