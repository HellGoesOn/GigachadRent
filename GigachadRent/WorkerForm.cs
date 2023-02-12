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
    public partial class WorkerForm : Form
    {
        int selectedId;
        public WorkerForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)) {
                MessageBox.Show("Введенные данные нельзя добавить в таблицу", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cmd = @$"insert into workers(name, phone, specialty, workid) values ('{textBox1.Text}', '{maskedTextBox1.Text}','{textBox2.Text}', '1')";
            Globals.Execute(cmd);
            Globals.Log($"{Globals.UserName} добавил рабочего {textBox1.Text} в базу данных ");
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить эти данные?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                Globals.Execute($"DELETE FROM workers WHERE Id = '{selectedId}'");
                Globals.Log($"{Globals.UserName} удалил рабочего {textBox1.Text} из базы данных");
                LoadData();
                selectedId = 0;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = grid.SelectedCells[0].RowIndex;

            if (row < 0)
                return;

            selectedId = Convert.ToInt32(grid.Rows[row].Cells[0].Value);
            textBox1.Text = grid.Rows[row].Cells[1].Value.ToString();
            maskedTextBox1.Text = grid.Rows[row].Cells[2].Value.ToString();
            textBox2.Text = grid.Rows[row].Cells[3].Value.ToString();
        }

        public void LoadData()
        {
            grid.Rows.Clear();
            var reader = Globals.Read($"Select * from workers where workid = '1'");
            while (reader.Read()) {
                this.grid.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3));
            }
            Globals.CloseConnection();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
