namespace PCADM
{
    partial class AdminForm
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
            dgvUsers = new DataGridView();
            panelControls = new Panel();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblLogin = new Label();
            txtLogin = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            lblCabinet = new Label();
            cmbCabinet = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnBackup = new Button();
            btnRestore = new Button();
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panelControls.SuspendLayout();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.Location = new Point(20, 60);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(600, 488);
            dgvUsers.TabIndex = 1;
            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
            // 
            // panelControls
            // 
            panelControls.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelControls.BorderStyle = BorderStyle.FixedSingle;
            panelControls.Controls.Add(lblFullName);
            panelControls.Controls.Add(txtFullName);
            panelControls.Controls.Add(lblLogin);
            panelControls.Controls.Add(txtLogin);
            panelControls.Controls.Add(lblPassword);
            panelControls.Controls.Add(txtPassword);
            panelControls.Controls.Add(lblRole);
            panelControls.Controls.Add(cmbRole);
            panelControls.Controls.Add(lblCabinet);
            panelControls.Controls.Add(cmbCabinet);
            panelControls.Controls.Add(btnAdd);
            panelControls.Controls.Add(btnUpdate);
            panelControls.Controls.Add(btnDelete);
            panelControls.Controls.Add(btnClear);
            panelControls.Controls.Add(btnBackup);
            panelControls.Controls.Add(btnRestore);
            panelControls.Location = new Point(640, 60);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(300, 488);
            panelControls.TabIndex = 2;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(15, 20);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(78, 15);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Полное имя:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(15, 45);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(260, 23);
            txtFullName.TabIndex = 0;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(15, 85);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(44, 15);
            lblLogin.TabIndex = 2;
            lblLogin.Text = "Логин:";
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(15, 110);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(260, 23);
            txtLogin.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(15, 150);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(52, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(15, 175);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(260, 23);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(15, 215);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(37, 15);
            lblRole.TabIndex = 6;
            lblRole.Text = "Роль:";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Location = new Point(15, 240);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(260, 23);
            cmbRole.TabIndex = 3;
            // 
            // lblCabinet
            // 
            lblCabinet.AutoSize = true;
            lblCabinet.Location = new Point(15, 280);
            lblCabinet.Name = "lblCabinet";
            lblCabinet.Size = new Size(55, 15);
            lblCabinet.TabIndex = 8;
            lblCabinet.Text = "Кабинет:";
            // 
            // cmbCabinet
            // 
            cmbCabinet.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCabinet.Location = new Point(15, 305);
            cmbCabinet.Name = "cmbCabinet";
            cmbCabinet.Size = new Size(260, 23);
            cmbCabinet.TabIndex = 4;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.Location = new Point(15, 350);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 35);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.LightBlue;
            btnUpdate.Location = new Point(155, 350);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(120, 35);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Изменить";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += BtnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.LightCoral;
            btnDelete.Location = new Point(15, 395);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 35);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(155, 395);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(120, 35);
            btnClear.TabIndex = 8;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.LightYellow;
            btnBackup.Location = new Point(15, 440);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(120, 35);
            btnBackup.TabIndex = 9;
            btnBackup.Text = "Резервная копия";
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += BtnBackup_Click;
            // 
            // btnRestore
            // 
            btnRestore.BackColor = Color.LightYellow;
            btnRestore.Location = new Point(155, 440);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(120, 35);
            btnRestore.TabIndex = 10;
            btnRestore.Text = "Восстановить";
            btnRestore.UseVisualStyleBackColor = false;
            btnRestore.Click += BtnRestore_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(408, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Администрирование пользователей";
            // 
            // AdminForm
            // 
            ClientSize = new Size(960, 560);
            Controls.Add(lblTitle);
            Controls.Add(dgvUsers);
            Controls.Add(panelControls);
            MinimumSize = new Size(800, 500);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Панель администратора";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblCabinet;
        private System.Windows.Forms.ComboBox cmbCabinet;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label lblTitle;
        #endregion
    }
}