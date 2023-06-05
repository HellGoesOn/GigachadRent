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
    public partial class EquipmentForm : Form
    {
        int selectedId;
        public EquipmentForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(richTextBox1.Text)) {
                MessageBox.Show("Заполните все поля!", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cmd = @$"insert into equipment(name, model, parameters, status) values ('{textBox1.Text}', '{textBox2.Text}', '{richTextBox1.Text.Replace("\v", Environment.NewLine)}', '{comboBox1.SelectedValue}')";
            Globals.Execute(cmd);
            int len = cmd.Length;
            Globals.Log($"{Globals.UserName} добавил технику {textBox1.Text} в базу данных ");
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить эти данные?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                Globals.Execute($"DELETE FROM Equipment WHERE Id = '{selectedId}'");
                Globals.Log($"{Globals.UserName} удалил технику {textBox1.Text} из базы данных");
                LoadData();
                selectedId = grid.Rows.Count > 0 ? int.Parse(grid.Rows[0].Cells[0].Value.ToString()) : 0;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = grid.SelectedCells[0].RowIndex;

            if (row < 0)
                return;

            selectedId = Convert.ToInt32(grid.Rows[row].Cells[0].Value);
            textBox1.Text = grid.Rows[row].Cells[1].Value.ToString();
            textBox2.Text = grid.Rows[row].Cells[2].Value.ToString();
            richTextBox1.Text = grid.Rows[row].Cells[3].Value.ToString();
            comboBox1.SelectedValue = grid.Rows[row].Cells[4].Value.ToString();
        }

        public void LoadData()
        {
            grid.Rows.Clear();
            var reader = Globals.Read($"Select * from equipment");
            while (reader.Read()) {
                object[] results = Globals.GetReaderResults(reader, 5);
                this.grid.Rows.Add(results);
                
            }
            Globals.CloseConnection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(richTextBox1.Text)) {
                MessageBox.Show("Заполните все поля!", "Ошибка ввода данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var cmd = @$"update Equipment set name = '{textBox1.Text}', model = '{textBox2.Text}', parameters = '{richTextBox1.Text}', status = '{comboBox1.SelectedItem.ToString()}' where Id = '{selectedId}'";
            Globals.Execute(cmd);
            Globals.Log($"{Globals.UserName} обновил данные техники {textBox1.Text}");
            LoadData();
            selectedId = grid.Rows.Count > 0 ? int.Parse(grid.Rows[0].Cells[0].Value.ToString()) : 0;

            MessageBox.Show($"Обновлены данные для техники {textBox1.Text}", "Данные добавлены", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void GetJuictyText(string name, string text)
        {
            textBox1.Text = name;
            textBox2.Text = "";
            richTextBox1.Text = text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new TemplateForm().Show(this);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try {
                for (int i = 0; i < grid.Rows.Count; i++) {
                    bool any = false;
                    bool textNotEmpty = string.IsNullOrWhiteSpace(textBox3.Text);

                    for (int j = 0; j < grid.Rows[i].Cells.Count; j++) {
                         if (grid.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox3.Text.ToLower())) {
                            any = true;
                            break;
                        }
                    }

                    grid.Rows[i].Visible = any || textNotEmpty;
                }
            }
            catch {

            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new HelpForm().Show();
        }
    }
}
