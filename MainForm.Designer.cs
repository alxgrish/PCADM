namespace PCADM
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grid = new DataGridView();
            contextMenu = new ContextMenuStrip(components);
            menuAdd = new ToolStripMenuItem();
            menuPrint = new ToolStripMenuItem();
            menuEdit = new ToolStripMenuItem();
            menuDel = new ToolStripMenuItem();
            menuUpdate = new ToolStripMenuItem();
            menuItemFilter = new ToolStripMenuItem();
            label1 = new Label();
            btn_taskSave = new Button();
            btn_qrCode = new Button();
            btn_taskComplite = new Button();
            btn_pingToPC = new Button();
            btn_remoteDesctop = new Button();
            pictureBox2 = new PictureBox();
            btn_Administ = new Button();
            btn_BData = new Button();
            menuStrip = new MenuStrip();
            toolStripTextBox1 = new ToolStripTextBox();
            MainMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            textBoxPCStatus = new RichTextBox();
            comboBoxSelectTask = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.ContextMenuStrip = contextMenu;
            grid.Location = new Point(12, 199);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(450, 274);
            grid.TabIndex = 0;
            grid.SelectionChanged += Grid_SelectionChanged;
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { menuAdd, menuPrint, menuEdit, menuDel, menuUpdate, menuItemFilter });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(166, 136);
            // 
            // menuAdd
            // 
            menuAdd.Name = "menuAdd";
            menuAdd.Size = new Size(165, 22);
            menuAdd.Text = "Добавить";
            menuAdd.Visible = false;
            // 
            // menuPrint
            // 
            menuPrint.Name = "menuPrint";
            menuPrint.Size = new Size(165, 22);
            menuPrint.Text = "Печать историю";
            // 
            // menuEdit
            // 
            menuEdit.Name = "menuEdit";
            menuEdit.Size = new Size(165, 22);
            menuEdit.Text = "Редактировать";
            menuEdit.Visible = false;
            // 
            // menuDel
            // 
            menuDel.Name = "menuDel";
            menuDel.Size = new Size(165, 22);
            menuDel.Text = "Удалить";
            menuDel.Visible = false;
            // 
            // menuUpdate
            // 
            menuUpdate.Name = "menuUpdate";
            menuUpdate.Size = new Size(165, 22);
            menuUpdate.Text = "Обновить";
            menuUpdate.Click += menuUpdate_Click;
            // 
            // menuItemFilter
            // 
            menuItemFilter.Name = "menuItemFilter";
            menuItemFilter.Size = new Size(165, 22);
            menuItemFilter.Text = "Фильтр";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 181);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 1;
            label1.Text = "ПК и статусы";
            // 
            // btn_taskSave
            // 
            btn_taskSave.Location = new Point(12, 47);
            btn_taskSave.Name = "btn_taskSave";
            btn_taskSave.Size = new Size(143, 23);
            btn_taskSave.TabIndex = 2;
            btn_taskSave.Text = "Принять задание";
            btn_taskSave.UseVisualStyleBackColor = true;
            // 
            // btn_qrCode
            // 
            btn_qrCode.Location = new Point(172, 47);
            btn_qrCode.Name = "btn_qrCode";
            btn_qrCode.Size = new Size(143, 23);
            btn_qrCode.TabIndex = 2;
            btn_qrCode.Text = "QR-код";
            btn_qrCode.UseVisualStyleBackColor = true;
            // 
            // btn_taskComplite
            // 
            btn_taskComplite.Location = new Point(12, 76);
            btn_taskComplite.Name = "btn_taskComplite";
            btn_taskComplite.Size = new Size(143, 23);
            btn_taskComplite.TabIndex = 2;
            btn_taskComplite.Text = "Завершить задание";
            btn_taskComplite.UseVisualStyleBackColor = true;
            // 
            // btn_pingToPC
            // 
            btn_pingToPC.Location = new Point(172, 76);
            btn_pingToPC.Name = "btn_pingToPC";
            btn_pingToPC.Size = new Size(143, 23);
            btn_pingToPC.TabIndex = 2;
            btn_pingToPC.Text = "Пинг на пк";
            btn_pingToPC.UseVisualStyleBackColor = true;
            // 
            // btn_remoteDesctop
            // 
            btn_remoteDesctop.Location = new Point(12, 134);
            btn_remoteDesctop.Name = "btn_remoteDesctop";
            btn_remoteDesctop.Size = new Size(303, 41);
            btn_remoteDesctop.TabIndex = 2;
            btn_remoteDesctop.Text = "Удаленный рабочий стол";
            btn_remoteDesctop.UseVisualStyleBackColor = true;
            btn_remoteDesctop.Click += button5_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.image_29_10_25_04_27;
            pictureBox2.Location = new Point(321, 44);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(141, 152);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // btn_Administ
            // 
            btn_Administ.Location = new Point(12, 105);
            btn_Administ.Name = "btn_Administ";
            btn_Administ.Size = new Size(143, 23);
            btn_Administ.TabIndex = 2;
            btn_Administ.Text = "Администрирование";
            btn_Administ.UseVisualStyleBackColor = true;
            btn_Administ.Click += btn_Administ_Click;
            // 
            // btn_BData
            // 
            btn_BData.Location = new Point(172, 105);
            btn_BData.Name = "btn_BData";
            btn_BData.Size = new Size(143, 23);
            btn_BData.TabIndex = 2;
            btn_BData.Text = "Данные базы";
            btn_BData.UseVisualStyleBackColor = true;
            btn_BData.Click += Btn_BData_Click;
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { toolStripTextBox1, MainMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(800, 27);
            menuStrip.TabIndex = 5;
            menuStrip.Text = "menuStrip1";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Alignment = ToolStripItemAlignment.Right;
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 23);
            toolStripTextBox1.Text = "Роль";
            // 
            // MainMenuItem
            // 
            MainMenuItem.Name = "MainMenuItem";
            MainMenuItem.Size = new Size(48, 23);
            MainMenuItem.Text = "Файл";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(468, 181);
            label2.Name = "label2";
            label2.Size = new Size(159, 15);
            label2.TabIndex = 1;
            label2.Text = "Описание статуса (задание)";
            // 
            // textBoxPCStatus
            // 
            textBoxPCStatus.Location = new Point(468, 207);
            textBoxPCStatus.Multiline = true;
            textBoxPCStatus.Name = "textBoxPCStatus";
            textBoxPCStatus.Size = new Size(320, 266);
            textBoxPCStatus.TabIndex = 7;
            textBoxPCStatus.BackColor = Color.LightGray;
            // 
            // comboBoxSelectTask
            // 
            comboBoxSelectTask.FormattingEnabled = true;
            comboBoxSelectTask.Location = new Point(655, 178);
            comboBoxSelectTask.Name = "comboBoxSelectTask";
            comboBoxSelectTask.Size = new Size(121, 23);
            comboBoxSelectTask.TabIndex = 8;
            comboBoxSelectTask.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(655, 160);
            label3.Name = "label3";
            label3.Size = new Size(116, 15);
            label3.TabIndex = 1;
            label3.Text = "Выбранное задание";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 485);
            Controls.Add(comboBoxSelectTask);
            Controls.Add(textBoxPCStatus);
            Controls.Add(pictureBox2);
            Controls.Add(btn_qrCode);
            Controls.Add(btn_remoteDesctop);
            Controls.Add(btn_BData);
            Controls.Add(btn_pingToPC);
            Controls.Add(btn_Administ);
            Controls.Add(btn_taskComplite);
            Controls.Add(btn_taskSave);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(grid);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "MainForm";
            Text = "ФИО ПОЛЬЗОВАТЕЛЯ";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private DataGridView grid;
        private Label label1;
        private Button btn_taskSave;
        private Button btn_qrCode;
        private Button btn_taskComplite;
        private Button btn_pingToPC;
        private Button btn_remoteDesctop;
        private PictureBox pictureBox2;
        private Button btn_Administ;
        private Button btn_BData;
        private MenuStrip menuStrip;
        private ToolStripTextBox toolStripTextBox1;
        private Label label2;
        private RichTextBox textBoxPCStatus;
        private ToolStripMenuItem MainMenuItem;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem menuAdd;
        private ToolStripMenuItem menuPrint;
        private ToolStripMenuItem menuEdit;
        private ToolStripMenuItem menuDel;
        private ToolStripMenuItem menuUpdate;
        private ToolStripMenuItem menuItemFilter;
        private ComboBox comboBoxSelectTask;
        private Label label3;
    }
}
