namespace GigachadRent
{
    partial class ContractsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contractsGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.penalty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workerDealGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayedName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipDealGrid = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.displayedModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.составитьОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.contractsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerDealGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipDealGrid)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contractsGrid
            // 
            this.contractsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contractsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.dateStart,
            this.dateEnd,
            this.price,
            this.penalty});
            this.contractsGrid.Location = new System.Drawing.Point(12, 79);
            this.contractsGrid.Name = "contractsGrid";
            this.contractsGrid.RowTemplate.Height = 25;
            this.contractsGrid.Size = new System.Drawing.Size(576, 430);
            this.contractsGrid.TabIndex = 0;
            this.contractsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.contractsGrid_CellClick);
            this.contractsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.contractsGrid_CellContentClick);
            this.contractsGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.contractsGrid_CellEndEdit);
            this.contractsGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.contractsGrid_CellValueChanged);
            this.contractsGrid.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.contractsGrid_RowLeave);
            this.contractsGrid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.contractsGrid_RowsAdded);
            this.contractsGrid.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.contractsGrid_RowValidated);
            this.contractsGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.contractsGrid_UserAddedRow);
            this.contractsGrid.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.contractsGrid_UserDeletedRow);
            this.contractsGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.contractsGrid_UserDeletingRow);
            this.contractsGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.contractsGrid_KeyDown);
            this.contractsGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contractsGrid_KeyPress);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // dateStart
            // 
            this.dateStart.FillWeight = 150F;
            this.dateStart.HeaderText = "Дата начала выполнения контракта";
            this.dateStart.Name = "dateStart";
            this.dateStart.Width = 150;
            // 
            // dateEnd
            // 
            this.dateEnd.FillWeight = 150F;
            this.dateEnd.HeaderText = "Длительность контракта (в днях)";
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Width = 150;
            // 
            // price
            // 
            this.price.HeaderText = "Стоимость";
            this.price.Name = "price";
            // 
            // penalty
            // 
            this.penalty.HeaderText = "Неустойка";
            this.penalty.Name = "penalty";
            // 
            // workerDealGrid
            // 
            this.workerDealGrid.AllowUserToAddRows = false;
            this.workerDealGrid.AllowUserToDeleteRows = false;
            this.workerDealGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.workerDealGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.workerDealGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.WorkerId,
            this.displayedName,
            this.specialty});
            this.workerDealGrid.Location = new System.Drawing.Point(594, 53);
            this.workerDealGrid.Name = "workerDealGrid";
            this.workerDealGrid.ReadOnly = true;
            this.workerDealGrid.RowTemplate.Height = 25;
            this.workerDealGrid.Size = new System.Drawing.Size(366, 117);
            this.workerDealGrid.TabIndex = 1;
            this.workerDealGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.workerDealGrid_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "ID Контракта";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // WorkerId
            // 
            this.WorkerId.HeaderText = "Рабочий";
            this.WorkerId.Name = "WorkerId";
            this.WorkerId.ReadOnly = true;
            this.WorkerId.Visible = false;
            // 
            // displayedName
            // 
            this.displayedName.HeaderText = "Рабочий";
            this.displayedName.Name = "displayedName";
            this.displayedName.ReadOnly = true;
            // 
            // specialty
            // 
            this.specialty.HeaderText = "Специальность";
            this.specialty.Name = "specialty";
            this.specialty.ReadOnly = true;
            // 
            // equipDealGrid
            // 
            this.equipDealGrid.AllowUserToAddRows = false;
            this.equipDealGrid.AllowUserToDeleteRows = false;
            this.equipDealGrid.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.equipDealGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipDealGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.ContractId,
            this.EquipID,
            this.dataGridViewTextBoxColumn4,
            this.displayedModel});
            this.equipDealGrid.Location = new System.Drawing.Point(594, 191);
            this.equipDealGrid.Name = "equipDealGrid";
            this.equipDealGrid.ReadOnly = true;
            this.equipDealGrid.RowTemplate.Height = 25;
            this.equipDealGrid.Size = new System.Drawing.Size(366, 142);
            this.equipDealGrid.TabIndex = 2;
            this.equipDealGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.equipDealGrid_CellClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // ContractId
            // 
            this.ContractId.HeaderText = "IdКонтракта";
            this.ContractId.Name = "ContractId";
            this.ContractId.ReadOnly = true;
            this.ContractId.Visible = false;
            // 
            // EquipID
            // 
            this.EquipID.HeaderText = "ID техники";
            this.EquipID.Name = "EquipID";
            this.EquipID.ReadOnly = true;
            this.EquipID.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Техника";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // displayedModel
            // 
            this.displayedModel.HeaderText = "Модель техники";
            this.displayedModel.Name = "displayedModel";
            this.displayedModel.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Контракты";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Работники контракта";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(594, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Техника контракта";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(594, 339);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(366, 184);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(358, 156);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Рабочий контракта";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(264, 23);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(276, 35);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(77, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "Изменить";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.updateWorkerDeal);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(276, 64);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(77, 23);
            this.button8.TabIndex = 10;
            this.button8.Text = "Удалить";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.deleteWorkerDeals);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(276, 6);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(76, 23);
            this.button9.TabIndex = 9;
            this.button9.Text = "Добавить";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.addWorkerDeal);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Controls.Add(this.button11);
            this.tabPage2.Controls.Add(this.button12);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(358, 156);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Техника контракта";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 7);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(264, 23);
            this.comboBox2.TabIndex = 15;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(276, 35);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(77, 23);
            this.button10.TabIndex = 14;
            this.button10.Text = "Изменить";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.updateEquipDeals);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(276, 64);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(77, 23);
            this.button11.TabIndex = 13;
            this.button11.Text = "Удалить";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.deleteEquipDeals);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(276, 6);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(76, 23);
            this.button12.TabIndex = 12;
            this.button12.Text = "Добавить";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.addEquipDeals);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(479, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(481, 32);
            this.button4.TabIndex = 26;
            this.button4.Text = "Назад";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(127, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "Фильтрация";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(207, 53);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(381, 23);
            this.textBox3.TabIndex = 28;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(963, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.составитьОтчётToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Файл";
            // 
            // составитьОтчётToolStripMenuItem
            // 
            this.составитьОтчётToolStripMenuItem.Name = "составитьОтчётToolStripMenuItem";
            this.составитьОтчётToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.составитьОтчётToolStripMenuItem.Text = "Составить отчёт";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(65, 20);
            this.toolStripMenuItem2.Text = "Справка";
            // 
            // ContractsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 521);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.equipDealGrid);
            this.Controls.Add(this.workerDealGrid);
            this.Controls.Add(this.contractsGrid);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ContractsForm";
            this.Text = "Договора";
            this.Load += new System.EventHandler(this.ContractsForm_Load);
            this.Resize += new System.EventHandler(this.ContractsForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.contractsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerDealGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipDealGrid)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView contractsGrid;
        private System.Windows.Forms.DataGridView workerDealGrid;
        private System.Windows.Forms.DataGridView equipDealGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayedModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayedName;
        private System.Windows.Forms.DataGridViewTextBoxColumn specialty;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem составитьОтчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn penalty;
    }
}