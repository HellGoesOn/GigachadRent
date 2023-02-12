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
            var cmd1 = $@"select * from Workers";
            var reader = Globals.Read(cmd1);
            Worker.List.Clear();
            while (reader.Read()) {

                int workerId = reader.GetInt32(0);
                string workerName = reader.GetString(1);
                string workerSpecialty = reader.GetString(2);

                Worker.List.Add(new Worker() { Id = workerId, Name = workerName, Specialty = workerSpecialty });
            }
            Globals.CloseConnection();

            var cmd2 = $@"select * from Equipment";
            var reader2 = Globals.Read(cmd2);
            Equipment.List.Clear();
            while (reader2.Read()) {

                int Id = reader2.GetInt32(0);
                string Name = reader2.GetString(1);
                string Model = reader2.GetString(2);

                Equipment.List.Add(new Equipment() { Id = Id, Name = Name, Model = Model });
            }
            Globals.CloseConnection();

            Client.List.Clear();
            var cmd3 = $@"select * from Clients";
            var reader3 = Globals.Read(cmd3);
            while (reader3.Read()) {

                int Id = reader3.GetInt32(0);
                string Name = reader3.GetString(1);
                string Model = reader3.GetString(2);

                Client.List.Add(new Client() { Id = Id, Name = Name, Phone = Model });
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
            new AuditLog().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateLists();
            var contracts = new ContractsForm();
            contracts.LoadData();
            contracts.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new EquipmentForm().Show();
        }
    }
}
