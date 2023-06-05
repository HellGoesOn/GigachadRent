using GigachadRent.Models;
using System;
using System.Windows.Forms;

namespace GigachadRent
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormClosed += delegate
            {
                Application.Exit();
            };
            UpdateLists();

        }

        private static void UpdateLists()
        {
            var cmd1 = $@"select * from Workers where WorkId = '1'";
            var reader = Globals.Read(cmd1);
            Worker.List.Clear();
            while (reader.Read()) {

                int workerId = reader.GetInt32(0);
                string workerName = reader.GetString(1);
                string phone = reader.GetString(2);
                string workerSpecialty = reader.GetString(3);

                Worker.List.Add(new Worker() { Id = workerId, Name = workerName, Phone = phone, Specialty = workerSpecialty });
            }
            Globals.CloseConnection();

            var cmd2 = $@"select * from Equipment";
            var reader2 = Globals.Read(cmd2);
            Equipment.List.Clear();
            while (reader2.Read()) {

                int Id = reader2.GetInt32(0);
                string Name = reader2.GetString(1);
                string Model = reader2.GetString(2);
                string parameters = reader2.IsDBNull(3) ? "" : reader2.GetString(3);
                string status = reader2.IsDBNull(4) ? "" : reader2.GetString(4);

                Equipment.List.Add(new Equipment() { Id = Id, Name = Name, Model = Model, Paramaters = parameters, Status = status });
            }
            Globals.CloseConnection();

            Client.List.Clear();
            var cmd3 = $@"select * from Clients";
            var reader3 = Globals.Read(cmd3);
            while (reader3.Read()) {

                object[] res = Globals.GetReaderResults(reader3, 4);

                int Id = reader3.GetInt32(0);
                string Name = res[1].ToString();
                string Model = res[2].ToString();
                string Email = res[3].ToString();

                Client.List.Add(new Client() { Id = Id, Name = Name, Phone = Model , Email = Email});
            }
            Globals.CloseConnection();
        }

        private void showClientData(object sender, EventArgs e)
        {
            UpdateLists();
            var clients = new Clients();
            clients.LoadData();
            clients.Show();
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
        }

        private void closeApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showLogs(object sender, EventArgs e)
        {
            Globals.CloseConnection();
            new AuditLog().Show();
        }

        private void showContracts(object sender, EventArgs e)
        {
            UpdateLists();
            var contracts = new ContractsForm();
            contracts.LoadData();
            contracts.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            width = this.Width;
            height = this.Height;
        }

        private void showEquipment(object sender, EventArgs e)
        {
            new EquipmentForm().Show();
        }

        private void showWorkers(object sender, EventArgs e)
        {
            new WorkerForm().Show();
        }

        private void showSupply(object sender, EventArgs e)
        {
            new SupplyForm().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new HelpForm().Show();
        }

        float width, height;
        private void MainForm_Resize(object sender, EventArgs e)
        {
            /*
            float percentX = this.Width / width;
            float percentY = this.Height / height;

            foreach(Control c in this.Controls) {
                c.Width = (int)(c.Width * percentX);
                c.Height = (int)(c.Height * percentY);

                if (percentX > 1)
                    c.Left = (int)(c.Left * percentX);
                else
                    c.Left = (int)(c.Left * percentX);
                
                if (percentY > 1)
                    c.Top = c.Top - (int)(c.Height * (1 - percentY));
                else
                    c.Top = c.Top + (int)(c.Height * (1 - percentY));
            }

            width = this.Width;
            height = this.Height;*/
        }
    }
}
