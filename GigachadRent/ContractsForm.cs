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
    public partial class ContractsForm : Form
    {
        int selectedContractId;
        int selectedWorkerDealId;
        int selectedEquipDealId;

        public ContractsForm()
        {
            InitializeComponent();

            comboBox1.DataSource = Worker.List;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";

            comboBox2.DataSource = Equipment.List;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";

            comboBox3.DataSource = Client.List;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";
        }

        private void ContractsForm_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            var cmd1 = $@"select *, Clients.Name as client_name from Contracts inner join Clients on Contracts.ClientID = Clients.Id";

            contractsGrid.Rows.Clear();
            var reader = Globals.Read(cmd1);
            while (reader.Read()) {
                this.contractsGrid.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetDateTime(1),
                    reader.GetDateTime(2),
                    reader.GetDecimal(3),
                    reader.GetDecimal(4),
                    reader.GetInt32(5),
                    reader["client_name"]);
            }
            Globals.CloseConnection();
        }

        public void LoadContractData()
        {
            var cmd1 = $@"select *, Workers.Name as worker_name, Workers.Specialty as worker_specialty from WorkerDeals inner join Workers on WorkerDeals.WorkerId = Workers.Id where ContractId = '{selectedContractId}'";
            workerDealGrid.Rows.Clear();
            var reader = Globals.Read(cmd1);
            while (reader.Read()) {

                int workerId = reader.GetInt32(2);
                string workerName = reader["worker_name"].ToString();
                string workerSpecialty = reader["worker_specialty"].ToString();
                this.workerDealGrid.Rows.Add(
                    reader.GetInt32(0),
                    reader.GetInt32(1),
                    workerId,
                    workerName, workerSpecialty );
            }
            Globals.CloseConnection();

            var cmd2 = $@"select *, Equipment.Name as equip_name, Equipment.Model as equip_model from EquipDeals inner join Equipment on EquipDeals.EquipId = Equipment.Id where ContractId = '{selectedContractId}'";
            equipDealGrid.Rows.Clear();
            var reader2 = Globals.Read(cmd2);
            while (reader2.Read()) {
                this.equipDealGrid.Rows.Add(
                    reader2.GetInt32(0),
                    reader2.GetInt32(1),
                    reader2.GetInt32(2),
                    reader2["equip_name"],
                    reader2["equip_model"]);
            }
            Globals.CloseConnection();
        }

        private void contractsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = contractsGrid.SelectedCells[0].RowIndex;

            if (row < 0)
                return;

            selectedContractId = Convert.ToInt32(contractsGrid.Rows[row].Cells[0].Value);
            LoadContractData();
        }

        private void workerDealGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (workerDealGrid.Rows.Count <= 0)
                return;

            var row = workerDealGrid.SelectedCells[0].RowIndex;

            if (row < 0)
                return;

            selectedWorkerDealId = Convert.ToInt32(workerDealGrid.Rows[row].Cells[0].Value);

            tabControl1.SelectedIndex = 0;
        }

        private void equipDealGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (equipDealGrid.Rows.Count <= 0)
                return;

            var row = equipDealGrid.SelectedCells[0].RowIndex;

            if (row < 0)
                return;

            selectedEquipDealId = Convert.ToInt32(equipDealGrid.Rows[row].Cells[0].Value);

            tabControl1.SelectedIndex = 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            var cmd = @$"insert into workerdeals(contractid, workerid) values ('{selectedContractId}', '{(comboBox1.SelectedItem as Worker).Id}')";
            Globals.Execute(cmd);
            Globals.Log($"{Globals.UserName} добавил рабочего {(comboBox1.SelectedItem as Worker).Name} в договор {selectedContractId}");
            LoadContractData();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить эти данные?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                Globals.Execute($"DELETE FROM WorkerDeals WHERE Id = '{selectedWorkerDealId}'");
                Globals.Log($"{Globals.UserName} удалил рабочего {(comboBox1.SelectedItem as Worker).Name} из договора {selectedContractId}");
                LoadContractData();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var cmd = @$"insert into equipdeals(equipid, contractid) values ('{(comboBox2.SelectedItem as Equipment).Id}', '{selectedContractId}')";
            Globals.Execute(cmd);
            Globals.Log($"{Globals.UserName} добавил технику {(comboBox2.SelectedItem as Equipment).Name} в договор {selectedContractId}");
            LoadContractData();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить эти данные?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                Globals.Execute($"DELETE FROM EquipDeals WHERE Id = '{selectedEquipDealId}'");
                Globals.Log($"{Globals.UserName} удалил технику {(comboBox2.SelectedItem as Equipment).Name} из договора {selectedContractId}");
                LoadContractData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                var cmd = @$"insert into contracts(datestart, dateend, price, penalty, clientid) 
                           values ('{dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}', 
                            '{dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}', 
                            '{textBox1.Text}', 
                            '{textBox2.Text}',
                            '{(comboBox3.SelectedItem as Client).Id}')";
                Globals.Execute(cmd);
                Globals.Log($"{Globals.UserName} заключил новый договор с клиентом {(comboBox3.SelectedItem as Client).Name}");
                LoadData();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить эти данные?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                Globals.Execute($"DELETE FROM Contracts WHERE Id = '{selectedContractId}'");
                Globals.Log($"{Globals.UserName} расторг договор {selectedContractId}");
                LoadData();
            }
        }
    }
}
