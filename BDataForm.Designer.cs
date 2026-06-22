namespace PCADM
{
    partial class BDataForm
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
            if (disposing && (components != null))
            {
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
            components = new System.ComponentModel.Container();
            topPanel = new Panel();
            btnArchive = new Button();
            btnProblems = new Button();
            btnComputers = new Button();
            btnCabinets = new Button();
            mainMenu = new MenuStrip();
            MenuItemCabinets = new ToolStripMenuItem();
            MenuItemPCs = new ToolStripMenuItem();
            MenuItemProblems = new ToolStripMenuItem();
            MenuItemArchiveRecorders = new ToolStripMenuItem();
            rightPanel = new Panel();
            btnDelete = new Button();
            btnEdit = new Button();
            btnPrint = new Button();
            btnAdd = new Button();
            mainContentPanel = new Panel();
            grid = new DataGridView();
            contextMenu = new ContextMenuStrip(components);
            menuAdd = new ToolStripMenuItem();
            menuEdit = new ToolStripMenuItem();
            searchTextBox = new TextBox();
            menuPrint = new ToolStripMenuItem();
            menuDel = new ToolStripMenuItem();
            menuUpdate = new ToolStripMenuItem();
            topPanel.SuspendLayout();
            mainMenu.SuspendLayout();
            rightPanel.SuspendLayout();
            mainContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // topPanel
            // 
            topPanel.Controls.Add(btnArchive);
            topPanel.Controls.Add(btnProblems);
            topPanel.Controls.Add(btnComputers);
            topPanel.Controls.Add(btnCabinets);
            topPanel.Controls.Add(mainMenu);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Margin = new Padding(4, 3, 4, 3);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(915, 92);
            topPanel.TabIndex = 0;
            // 
            // btnArchive
            // 
            btnArchive.BackColor = Color.FromArgb(150, 140, 255);
            btnArchive.Cursor = Cursors.Hand;
            btnArchive.FlatAppearance.BorderSize = 0;
            btnArchive.FlatStyle = FlatStyle.Flat;
            btnArchive.Font = new Font("Segoe UI", 10F);
            btnArchive.Location = new Point(720, 34);
            btnArchive.Margin = new Padding(4, 3, 4, 3);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(158, 52);
            btnArchive.TabIndex = 0;
            btnArchive.Tag = "Archive";
            btnArchive.Text = "архивные\nзаписи";
            btnArchive.UseVisualStyleBackColor = false;
            btnArchive.Click += ShowTables_Click;
            // 
            // btnProblems
            // 
            btnProblems.BackColor = Color.FromArgb(150, 140, 255);
            btnProblems.Cursor = Cursors.Hand;
            btnProblems.FlatAppearance.BorderSize = 0;
            btnProblems.FlatStyle = FlatStyle.Flat;
            btnProblems.Font = new Font("Segoe UI", 10F);
            btnProblems.Location = new Point(491, 34);
            btnProblems.Margin = new Padding(4, 3, 4, 3);
            btnProblems.Name = "btnProblems";
            btnProblems.Size = new Size(158, 52);
            btnProblems.TabIndex = 1;
            btnProblems.Tag = "Problem";
            btnProblems.Text = "проблемы";
            btnProblems.UseVisualStyleBackColor = false;
            btnProblems.Click += ShowTables_Click;
            // 
            // btnComputers
            // 
            btnComputers.BackColor = Color.FromArgb(150, 140, 255);
            btnComputers.Cursor = Cursors.Hand;
            btnComputers.FlatAppearance.BorderSize = 0;
            btnComputers.FlatStyle = FlatStyle.Flat;
            btnComputers.Font = new Font("Segoe UI", 10F);
            btnComputers.Location = new Point(262, 34);
            btnComputers.Margin = new Padding(4, 3, 4, 3);
            btnComputers.Name = "btnComputers";
            btnComputers.Size = new Size(158, 52);
            btnComputers.TabIndex = 2;
            btnComputers.Tag = "PC";
            btnComputers.Text = "компьютеры";
            btnComputers.UseVisualStyleBackColor = false;
            btnComputers.Click += ShowTables_Click;
            // 
            // btnCabinets
            // 
            btnCabinets.BackColor = Color.FromArgb(150, 140, 255);
            btnCabinets.Cursor = Cursors.Hand;
            btnCabinets.FlatAppearance.BorderSize = 0;
            btnCabinets.FlatStyle = FlatStyle.Flat;
            btnCabinets.Font = new Font("Segoe UI", 10F);
            btnCabinets.Location = new Point(35, 34);
            btnCabinets.Margin = new Padding(4, 3, 4, 3);
            btnCabinets.Name = "btnCabinets";
            btnCabinets.Size = new Size(158, 52);
            btnCabinets.TabIndex = 3;
            btnCabinets.Tag = "Cabinet";
            btnCabinets.Text = "кабинеты";
            btnCabinets.UseVisualStyleBackColor = false;
            btnCabinets.Click += ShowTables_Click;
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new ToolStripItem[] { MenuItemCabinets, MenuItemPCs, MenuItemProblems, MenuItemArchiveRecorders });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(915, 24);
            mainMenu.TabIndex = 4;
            mainMenu.Text = "menuStrip1";
            // 
            // MenuItemCabinets
            // 
            MenuItemCabinets.Name = "MenuItemCabinets";
            MenuItemCabinets.Size = new Size(73, 20);
            MenuItemCabinets.Tag = "Cabinet";
            MenuItemCabinets.Text = "Кабинеты";
            MenuItemCabinets.Click += ShowTables_Click;
            // 
            // MenuItemPCs
            // 
            MenuItemPCs.Name = "MenuItemPCs";
            MenuItemPCs.Size = new Size(92, 20);
            MenuItemPCs.Tag = "PC";
            MenuItemPCs.Text = "Компьютеры";
            MenuItemPCs.Click += ShowTables_Click;
            // 
            // MenuItemProblems
            // 
            MenuItemProblems.Name = "MenuItemProblems";
            MenuItemProblems.Size = new Size(80, 20);
            MenuItemProblems.Tag = "Problem";
            MenuItemProblems.Text = "Проблемы";
            MenuItemProblems.Click += ShowTables_Click;
            // 
            // MenuItemArchiveRecorders
            // 
            MenuItemArchiveRecorders.Name = "MenuItemArchiveRecorders";
            MenuItemArchiveRecorders.Size = new Size(115, 20);
            MenuItemArchiveRecorders.Tag = "Archive";
            MenuItemArchiveRecorders.Text = "Архивные записи";
            MenuItemArchiveRecorders.Click += ShowTables_Click;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(btnDelete);
            rightPanel.Controls.Add(btnEdit);
            rightPanel.Controls.Add(btnPrint);
            rightPanel.Controls.Add(btnAdd);
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Location = new Point(705, 92);
            rightPanel.Margin = new Padding(4, 3, 4, 3);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(210, 440);
            rightPanel.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(150, 140, 255);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F);
            btnDelete.Location = new Point(29, 294);
            btnDelete.Margin = new Padding(4, 3, 4, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(158, 52);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(150, 140, 255);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F);
            btnEdit.Location = new Point(29, 219);
            btnEdit.Margin = new Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(158, 52);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "изменить";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(150, 140, 255);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 10F);
            btnPrint.Location = new Point(29, 144);
            btnPrint.Margin = new Padding(4, 3, 4, 3);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(158, 52);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "печать";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(150, 140, 255);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F);
            btnAdd.Location = new Point(29, 69);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(158, 52);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // mainContentPanel
            // 
            mainContentPanel.Controls.Add(grid);
            mainContentPanel.Controls.Add(searchTextBox);
            mainContentPanel.Dock = DockStyle.Fill;
            mainContentPanel.Location = new Point(0, 92);
            mainContentPanel.Margin = new Padding(4, 3, 4, 3);
            mainContentPanel.Name = "mainContentPanel";
            mainContentPanel.Padding = new Padding(35, 12, 18, 35);
            mainContentPanel.Size = new Size(705, 440);
            mainContentPanel.TabIndex = 2;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.BackgroundColor = Color.FromArgb(220, 220, 220);
            grid.BorderStyle = BorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.ContextMenuStrip = contextMenu;
            grid.Dock = DockStyle.Fill;
            grid.Location = new Point(35, 37);
            grid.Margin = new Padding(4, 3, 4, 3);
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(652, 368);
            grid.TabIndex = 1;
            grid.SelectionChanged += grid_SelectionChanged;
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { menuAdd, menuPrint, menuEdit, menuDel, menuUpdate });
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(181, 136);
            // 
            // menuAdd
            // 
            menuAdd.Name = "menuAdd";
            menuAdd.Size = new Size(180, 22);
            menuAdd.Text = "Добавить";
            menuAdd.Click += btnAdd_Click;
            // 
            // menuEdit
            // 
            menuEdit.Name = "menuEdit";
            menuEdit.Size = new Size(180, 22);
            menuEdit.Text = "Редактировать";
            menuEdit.Click += btnEdit_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Dock = DockStyle.Top;
            searchTextBox.Font = new Font("Segoe UI", 10F);
            searchTextBox.ForeColor = Color.Gray;
            searchTextBox.Location = new Point(35, 12);
            searchTextBox.Margin = new Padding(4, 3, 4, 3);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Введите символы для поиска";
            searchTextBox.Size = new Size(652, 25);
            searchTextBox.TabIndex = 0;
            // 
            // menuPrint
            // 
            menuPrint.Name = "menuPrint";
            menuPrint.Size = new Size(180, 22);
            menuPrint.Text = "Печать";
            menuPrint.Click += btnPrint_Click;
            // 
            // menuDel
            // 
            menuDel.Name = "menuDel";
            menuDel.Size = new Size(180, 22);
            menuDel.Text = "Удалить";
            menuDel.Click += btnDelete_Click;
            // 
            // menuUpdate
            // 
            menuUpdate.Name = "menuUpdate";
            menuUpdate.Size = new Size(180, 22);
            menuUpdate.Text = "Обновить";
            menuUpdate.Click += menuUpdate_Click;
            // 
            // BDataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(915, 532);
            Controls.Add(mainContentPanel);
            Controls.Add(rightPanel);
            Controls.Add(topPanel);
            MainMenuStrip = mainMenu;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(931, 571);
            Name = "BDataForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Настройка данной базы";
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            rightPanel.ResumeLayout(false);
            mainContentPanel.ResumeLayout(false);
            mainContentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btnCabinets;
        private System.Windows.Forms.Button btnComputers;
        private System.Windows.Forms.Button btnProblems;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel mainContentPanel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        #endregion

        private MenuStrip mainMenu;
        private ToolStripMenuItem MenuItemCabinets;
        private ToolStripMenuItem MenuItemPCs;
        private ToolStripMenuItem MenuItemProblems;
        private ToolStripMenuItem MenuItemArchiveRecorders;
        private ToolStripMenuItem menuPrint;
        private ToolStripMenuItem menuDel;
        private ToolStripMenuItem menuUpdate;
    }
}