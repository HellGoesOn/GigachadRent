using GigachadRent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        bool loaded;

        DateTimePicker dtpStart = new DateTimePicker();
        DateTimePicker dtpEnd = new DateTimePicker();
        public ContractsForm()
        {
            InitializeComponent();

            comboBox1.DataSource = Worker.List;
            comboBox1.DisplayMember = "Composite";
            comboBox1.ValueMember = "Id";

            comboBox2.DataSource = Equipment.List;
            comboBox2.DisplayMember = "Composite";
            comboBox2.ValueMember = "Id";

            DataGridViewComboBoxColumn dgvCMB = new DataGridViewComboBoxColumn();
            dgvCMB.DataSource = Client.List;
            dgvCMB.DisplayMember = "Name";
            dgvCMB.ValueMember = "Id";
            dgvCMB.HeaderText = "Клиент";
            dgvCMB.ToolTipText = "Выберите клиента";
            dgvCMB.Name = "Клиент";
            dgvCMB.ReadOnly = false;

            dtpStart.Visible = false;
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.TextChanged += DtpStart_TextChanged;

            contractsGrid.Controls.Add(dtpStart);

            contractsGrid.Columns.Add(dgvCMB);

        }

        private void DtpEnd_TextChanged(object sender, EventArgs e)
        {
            contractsGrid.CurrentCell.Value = dtpStart.Value.ToString();
        }

        private void DtpStart_TextChanged(object sender, EventArgs e)
        {
            if(contractsGrid.CurrentCell.ColumnIndex == 1)
            contractsGrid.CurrentCell.Value = dtpStart.Value.ToString();

            dtpStart.Visible = false;
            dtpStart.Location = new Point(0, 0);
            dtpStart.Size = new Size(0, 0);
            dtpStart.TextChanged -= DtpStart_TextChanged;
        }

        private void ContractsForm_Load(object sender, EventArgs e)
        {
            loaded = true;
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
                    reader.GetInt32(2),
                    reader.GetDecimal(3),
                    reader.GetInt32(4));
            }
            Globals.CloseConnection();
            loaded = false;
            for(int i = 0; i < contractsGrid.Rows.Count-1; i++) {
                contractsGrid.Rows[i].Cells[3].Value = contractsGrid.Rows[i].Cells[3].Value.ToString().Replace(".", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            }
            loaded = true;
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
        Rectangle _Rectangle;
        private void contractsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == contractsGrid.Rows.Count-1)
                return;

            selectedContractId = (int)contractsGrid.Rows[e.RowIndex].Cells[0].Value;

            LoadContractData();

            _Rectangle = contractsGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

            if (e.ColumnIndex < 0)
                return;

            dtpStart.Visible = false;
            dtpStart.Location = new Point(0, 0);
            dtpStart.Size = new Size(0, 0);
            dtpStart.Value = DateTime.Parse(contractsGrid.Rows[e.RowIndex].Cells["dateStart"].Value.ToString());
            dtpStart.TextChanged -= DtpStart_TextChanged;

            switch (contractsGrid.Columns[e.ColumnIndex].Name) {
                case "dateStart":
                    dtpStart.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtpStart.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtpStart.Visible = true;
                    dtpStart.TextChanged += DtpStart_TextChanged;
                    break;
            }
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

        private void updateWorkerDeal(object sender, EventArgs e)
        {
            try {
                var cmd = @$"update workerdeals set workerid = '{comboBox1.SelectedValue}' where WorkerDeals.Id = {selectedWorkerDealId} ";
                Globals.Execute(cmd);
                Globals.Log($"{Globals.UserName} обновил договор {selectedContractId}");
                LoadContractData();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void addWorkerDeal(object sender, EventArgs e)
        {
            var cmd = @$"insert into workerdeals(contractid, workerid) values ('{selectedContractId}', '{(comboBox1.SelectedItem as Worker).Id}')";
            Globals.Execute(cmd);
            Globals.Log($"{Globals.UserName} добавил рабочего {(comboBox1.SelectedItem as Worker).Name} в договор {selectedContractId}");
            LoadContractData();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void deleteWorkerDeals(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить эти данные?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                Globals.Execute($"DELETE FROM WorkerDeals WHERE Id = '{selectedWorkerDealId}'");
                Globals.Log($"{Globals.UserName} удалил рабочего {(comboBox1.SelectedItem as Worker).Name} из договора {selectedContractId}");
                LoadContractData();
            }
        }

        private void addEquipDeals(object sender, EventArgs e)
        {
            var cmd = @$"insert into equipdeals(equipid, contractid) values ('{(comboBox2.SelectedItem as Equipment).Id}', '{selectedContractId}')";
            Globals.Execute(cmd);
            var cmd2 = $@"update equipment set status = 'Арендовано' where id = {(comboBox2.SelectedItem as Equipment).Id}";
            Globals.Execute(cmd2);
            Globals.Log($"{Globals.UserName} добавил технику {(comboBox2.SelectedItem as Equipment).Name} в договор {selectedContractId}");
            LoadContractData();
            comboBox2.DataSource = Equipment.List;
        }

        private void deleteEquipDeals(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить эти данные?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                Globals.Execute($"DELETE FROM EquipDeals WHERE Id = '{selectedEquipDealId}'");
                Globals.Log($"{Globals.UserName} удалил технику {(comboBox2.SelectedItem as Equipment).Name} из договора {selectedContractId}");
                var cmd2 = $@"update equipment set status = 'Свободно' where id = {(comboBox2.SelectedItem as Equipment).Id}";
                Globals.Execute(cmd2);
                LoadContractData();
                comboBox2.DataSource = Equipment.List;
            }
        }

        private void updateContract(object sender, EventArgs e)
        {
            try {
                var cmd = @$"update contracts set datestart = '{dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss.fff")}',
                            dateend = '{contractsGrid.Rows}',
                            price = '{textBox1.Text}', penalty = '{textBox2.Text}', clientid = '{(comboBox3.SelectedItem as Client).Id}' where Contracts.Id = {selectedContractId} ";
                Globals.Execute(cmd);
                Globals.Log($"{Globals.UserName} обновил договор {selectedContractId} с клиентом {(comboBox3.SelectedItem as Client).Name}");
                LoadData();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteContract(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить эти данные?", "Подтверждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK) {
                Globals.Execute($"DELETE FROM Contracts WHERE Id = '{selectedContractId}'");
                Globals.Log($"{Globals.UserName} расторг договор {selectedContractId}");
                LoadData();
            }
        }

        private void updateEquipDeals(object sender, EventArgs e)
        {
            try {
                var cmd = @$"update equipdeals set equipid = '{comboBox2.SelectedValue}' where equipdeals.Id = {selectedEquipDealId} ";
                Globals.Execute(cmd);
                Globals.Log($"{Globals.UserName} обновил договор {selectedContractId}");
                LoadContractData();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void ContractsForm_Resize(object sender, EventArgs e)
        {
            contractsGrid.Width = this.Width - equipDealGrid.Width - 60;
            button4.Width = this.Width - 510;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try {
                for(int i = 0; i < contractsGrid.Rows.Count - 1; i++) {
                    bool any = false;
                    bool textNotEmpty = string.IsNullOrWhiteSpace(textBox3.Text);

                    for(int j = 0; j < contractsGrid.Rows[i].Cells.Count; j++) {
                        if(j == contractsGrid.Rows[i].Cells.Count-1) {
                            if((contractsGrid.Rows[i].Cells[j] as DataGridViewComboBoxCell).FormattedValue.ToString().ToLower().Contains(textBox3.Text.ToLower())) {
                                any = true;
                                break;
                            }
                        }
                        else if (contractsGrid.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox3.Text.ToLower())) {
                            any = true;
                            break;
                        }
                    }

                    contractsGrid.Rows[i].Visible = any || textNotEmpty;
                }
            }
            catch {

            }
        }

        private void contractsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            selectedContractId = (int)contractsGrid.Rows[e.RowIndex].Cells[0].Value;

            LoadContractData();
        }

        private void contractsGrid_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void contractsGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void contractsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void contractsGrid_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void contractsGrid_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try {
                var rowInd = e.Row.Index-1;
                contractsGrid.Rows[rowInd].Cells[1].Value = DateTime.Today;
                contractsGrid.Rows[rowInd].Cells[2].Value = 4;
                contractsGrid.Rows[rowInd].Cells[3].Value = "0.00";
                contractsGrid.Rows[rowInd].Cells[4].Value = Client.List[0].Id;
                string dateStart = Convert.ToDateTime(contractsGrid.Rows[rowInd].Cells[1].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss.fff");
                string dateEnd = contractsGrid.Rows[rowInd].Cells[2].Value.ToString();
                string price = contractsGrid.Rows[rowInd].Cells[3].Value.ToString();
                int client = (int)contractsGrid.Rows[rowInd].Cells[4].Value;
                var cmd = @$"insert into contracts(datestart, dateend, price, clientid) 
                           values ('{dateStart}', 
                            '{dateEnd}', 
                            '{price}', 
                            '{client}')";
                Globals.Execute(cmd);
                Globals.Log($"{Globals.UserName} заключил новый договор с клиентом {Client.List.Find(x => x.Id == client).Name}");
                loaded = false;
                LoadData();
            }
            catch (Exception ex) {
                if (ex is not NullReferenceException)
                    MessageBox.Show(ex.Message);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void contractsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!loaded || contractsGrid.Rows[e.RowIndex].Cells[0].Value == null)
                return;

            if(e.ColumnIndex == 2) {
                if (int.TryParse(contractsGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), out var yes)) {
                    if (yes < 4) {
                        MessageBox.Show("Длительность аренды должна быть не менее 4 дней", "Слишком низкое значение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        contractsGrid.CellValueChanged -= contractsGrid_CellValueChanged;
                        contractsGrid.Rows[e.RowIndex].Cells[2].Value = 4;
                        contractsGrid.CellValueChanged += contractsGrid_CellValueChanged;
                        return;
                    } 
                } else {
                    MessageBox.Show("Длительность должна быть задана числом", "Неверный тип данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    contractsGrid.CellValueChanged -= contractsGrid_CellValueChanged;
                    contractsGrid.Rows[e.RowIndex].Cells[2].Value = 4;
                    contractsGrid.CellValueChanged += contractsGrid_CellValueChanged;
                    return;
                }
            }

            bool c3 = decimal.TryParse(contractsGrid.Rows[e.RowIndex].Cells[3].Value.ToString(), out var _);
            if (e.ColumnIndex == 3 && !c3) {
                MessageBox.Show("Введите число!", "Неверный тип данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                loaded = false;
                contractsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0.0;
                loaded = true;
                return;
            }

            try {
                foreach (DataGridViewCell cell in contractsGrid.Rows[e.RowIndex].Cells) {
                    if (cell.ColumnIndex > 0 && cell.Value == null)
                        return;
                }

                var rowInd = e.RowIndex;
                selectedContractId = (int)contractsGrid.Rows[e.RowIndex].Cells[0].Value;
                string dateStart = Convert.ToDateTime(contractsGrid.Rows[rowInd].Cells[1].Value.ToString()).ToString("yyyy-MM-dd HH:mm:ss.fff");
                string dateEnd = contractsGrid.Rows[rowInd].Cells[2].Value.ToString();
                string price = contractsGrid.Rows[rowInd].Cells[3].Value.ToString().Replace(".", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
                int client = (int)contractsGrid.Rows[rowInd].Cells[4].Value;

                var cmd = @$"update contracts set datestart = '{dateStart}',
                            dateend = '{dateEnd}',
                            price = '{price}', clientid = '{client}' where Contracts.Id = {selectedContractId} ";
                Globals.Execute(cmd);
                Globals.Log($"{Globals.UserName} обновил договор {selectedContractId} с клиентом {Client.List.Find(x => x.Id == client).Name}");
                LoadData();
            }
            catch (Exception ex) {
                if (ex is not NullReferenceException)
                    MessageBox.Show(ex.Message);
            }
        }

        private void contractsGrid_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
        }

        private void contractsGrid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Globals.Execute($"DELETE FROM Contracts WHERE Id = '{contractsGrid.Rows[e.Row.Index].Cells[0].Value.ToString()}'");
        }

        private void contractsGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void contractsGrid_KeyDown(object sender, KeyEventArgs e)
        {
            int index = contractsGrid.SelectedCells.Count > 0 ? contractsGrid.SelectedCells[0].RowIndex : -1;

            if (contractsGrid.Rows[index].Cells[0].Value == null || (int)contractsGrid.Rows[index].Cells[0].Value == 0)
                return;

            if (index >= 0) {
                if (e.KeyCode == Keys.Delete) {
                    if(MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
                        
                        Globals.Execute($"DELETE FROM Contracts WHERE Id = '{contractsGrid.Rows[index].Cells[0].Value}'");
                        contractsGrid.Rows.RemoveAt(index);
                    }
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
