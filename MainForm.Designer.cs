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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            btn_taskSave = new Button();
            btn_toArchive = new Button();
            label2 = new Label();
            btn_taskComplite = new Button();
            btn_pingToPC = new Button();
            btn_remoteDesctop = new Button();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            btn_Administ = new Button();
            btn_BData = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 164);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(450, 274);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 146);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 1;
            label1.Text = "ПК и статусы";
            // 
            // btn_taskSave
            // 
            btn_taskSave.Location = new Point(12, 12);
            btn_taskSave.Name = "btn_taskSave";
            btn_taskSave.Size = new Size(143, 23);
            btn_taskSave.TabIndex = 2;
            btn_taskSave.Text = "Принять задание";
            btn_taskSave.UseVisualStyleBackColor = true;
            // 
            // btn_toArchive
            // 
            btn_toArchive.Location = new Point(172, 12);
            btn_toArchive.Name = "btn_toArchive";
            btn_toArchive.Size = new Size(143, 23);
            btn_toArchive.TabIndex = 2;
            btn_toArchive.Text = "В архив";
            btn_toArchive.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(754, 9);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 1;
            label2.Text = "Роль";
            label2.Click += label2_Click;
            // 
            // btn_taskComplite
            // 
            btn_taskComplite.Location = new Point(12, 41);
            btn_taskComplite.Name = "btn_taskComplite";
            btn_taskComplite.Size = new Size(143, 23);
            btn_taskComplite.TabIndex = 2;
            btn_taskComplite.Text = "Завершить задание";
            btn_taskComplite.UseVisualStyleBackColor = true;
            // 
            // btn_pingToPC
            // 
            btn_pingToPC.Location = new Point(172, 41);
            btn_pingToPC.Name = "btn_pingToPC";
            btn_pingToPC.Size = new Size(143, 23);
            btn_pingToPC.TabIndex = 2;
            btn_pingToPC.Text = "Пинг на пк";
            btn_pingToPC.UseVisualStyleBackColor = true;
            // 
            // btn_remoteDesctop
            // 
            btn_remoteDesctop.Location = new Point(12, 99);
            btn_remoteDesctop.Name = "btn_remoteDesctop";
            btn_remoteDesctop.Size = new Size(303, 41);
            btn_remoteDesctop.TabIndex = 2;
            btn_remoteDesctop.Text = "Удаленный рабочий стол";
            btn_remoteDesctop.UseVisualStyleBackColor = true;
            btn_remoteDesctop.Click += button5_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(491, 70);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(297, 368);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(491, 41);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 1;
            label3.Text = "QR код для входа";
            label3.Click += label2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.image_29_10_25_04_27;
            pictureBox2.Location = new Point(321, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(164, 152);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // btn_Administ
            // 
            btn_Administ.Location = new Point(12, 70);
            btn_Administ.Name = "btn_Administ";
            btn_Administ.Size = new Size(143, 23);
            btn_Administ.TabIndex = 2;
            btn_Administ.Text = "Администрирование";
            btn_Administ.UseVisualStyleBackColor = true;
            btn_Administ.Click += btn_Administ_Click;
            // 
            // btn_BData
            // 
            btn_BData.Location = new Point(172, 70);
            btn_BData.Name = "btn_BData";
            btn_BData.Size = new Size(143, 23);
            btn_BData.TabIndex = 2;
            btn_BData.Text = "Данные базы";
            btn_BData.UseVisualStyleBackColor = true;
            btn_BData.Click += Btn_BData_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btn_toArchive);
            Controls.Add(btn_remoteDesctop);
            Controls.Add(btn_BData);
            Controls.Add(btn_pingToPC);
            Controls.Add(btn_Administ);
            Controls.Add(btn_taskComplite);
            Controls.Add(btn_taskSave);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "MainForm";
            Text = "ФИО ПОЛЬЗОВАТЕЛЯ";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Button btn_taskSave;
        private Button btn_toArchive;
        private Label label2;
        private Button btn_taskComplite;
        private Button btn_pingToPC;
        private Button btn_remoteDesctop;
        private PictureBox pictureBox1;
        private Label label3;
        private PictureBox pictureBox2;
        private Button btn_Administ;
        private Button btn_BData;
    }
}
