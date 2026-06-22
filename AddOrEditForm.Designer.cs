namespace PCADM
{
    partial class AddOrEditForm
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
            btnClose = new Button();
            btnOk = new Button();
            labelTextBox1 = new Label();
            NumericAndTextBoxGroupBox = new GroupBox();
            numericUpDown = new NumericUpDown();
            labelNumeric = new Label();
            textBox2 = new TextBox();
            labelTextBox2 = new Label();
            textBox1 = new TextBox();
            ComboBoxGroupBox = new GroupBox();
            comboBox3 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            labelComboBox1 = new Label();
            labelComboBox3 = new Label();
            labelComboBox2 = new Label();
            NumericAndTextBoxGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).BeginInit();
            ComboBoxGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(150, 140, 255);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.Location = new Point(16, 341);
            btnClose.Margin = new Padding(7, 6, 7, 6);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 50);
            btnClose.TabIndex = 1;
            btnClose.Text = "Отменить";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(150, 140, 255);
            btnOk.Cursor = Cursors.Hand;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Segoe UI", 10F);
            btnOk.Location = new Point(403, 341);
            btnOk.Margin = new Padding(7, 6, 7, 6);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(150, 50);
            btnOk.TabIndex = 2;
            btnOk.Text = "Применить";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Click += btnOk_Click;
            // 
            // labelTextBox1
            // 
            labelTextBox1.AutoSize = true;
            labelTextBox1.Location = new Point(6, 46);
            labelTextBox1.Name = "labelTextBox1";
            labelTextBox1.Size = new Size(68, 30);
            labelTextBox1.TabIndex = 0;
            labelTextBox1.Text = "label1";
            // 
            // NumericAndTextBoxGroupBox
            // 
            NumericAndTextBoxGroupBox.Controls.Add(numericUpDown);
            NumericAndTextBoxGroupBox.Controls.Add(labelNumeric);
            NumericAndTextBoxGroupBox.Controls.Add(textBox2);
            NumericAndTextBoxGroupBox.Controls.Add(labelTextBox2);
            NumericAndTextBoxGroupBox.Controls.Add(textBox1);
            NumericAndTextBoxGroupBox.Controls.Add(labelTextBox1);
            NumericAndTextBoxGroupBox.Location = new Point(16, 24);
            NumericAndTextBoxGroupBox.Name = "NumericAndTextBoxGroupBox";
            NumericAndTextBoxGroupBox.Size = new Size(264, 308);
            NumericAndTextBoxGroupBox.TabIndex = 5;
            NumericAndTextBoxGroupBox.TabStop = false;
            NumericAndTextBoxGroupBox.Text = "Вещественные данные";
            // 
            // numericUpDown
            // 
            numericUpDown.Location = new Point(12, 250);
            numericUpDown.Margin = new Padding(9, 12, 9, 12);
            numericUpDown.Name = "numericUpDown";
            numericUpDown.Size = new Size(246, 35);
            numericUpDown.TabIndex = 5;
            numericUpDown.Tag = "0";
            numericUpDown.Visible = false;
            // 
            // labelNumeric
            // 
            labelNumeric.AutoSize = true;
            labelNumeric.Location = new Point(6, 218);
            labelNumeric.Name = "labelNumeric";
            labelNumeric.Size = new Size(68, 30);
            labelNumeric.TabIndex = 4;
            labelNumeric.Text = "label3";
            labelNumeric.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 161);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(252, 35);
            textBox2.TabIndex = 3;
            textBox2.Tag = "0";
            // 
            // labelTextBox2
            // 
            labelTextBox2.AutoSize = true;
            labelTextBox2.Location = new Point(6, 128);
            labelTextBox2.Name = "labelTextBox2";
            labelTextBox2.Size = new Size(68, 30);
            labelTextBox2.TabIndex = 2;
            labelTextBox2.Text = "label2";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 79);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(252, 35);
            textBox1.TabIndex = 1;
            textBox1.Tag = "0";
            // 
            // ComboBoxGroupBox
            // 
            ComboBoxGroupBox.Controls.Add(comboBox3);
            ComboBoxGroupBox.Controls.Add(comboBox2);
            ComboBoxGroupBox.Controls.Add(comboBox1);
            ComboBoxGroupBox.Controls.Add(labelComboBox1);
            ComboBoxGroupBox.Controls.Add(labelComboBox3);
            ComboBoxGroupBox.Controls.Add(labelComboBox2);
            ComboBoxGroupBox.Location = new Point(286, 24);
            ComboBoxGroupBox.Name = "ComboBoxGroupBox";
            ComboBoxGroupBox.Size = new Size(264, 308);
            ComboBoxGroupBox.TabIndex = 6;
            ComboBoxGroupBox.TabStop = false;
            ComboBoxGroupBox.Text = "Выборочные данные";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(6, 250);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(252, 38);
            comboBox3.TabIndex = 13;
            comboBox3.Tag = "0";
            comboBox3.Visible = false;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(6, 161);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(252, 38);
            comboBox2.TabIndex = 12;
            comboBox2.Tag = "0";
            comboBox2.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 79);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(252, 38);
            comboBox1.TabIndex = 11;
            comboBox1.Tag = "0";
            comboBox1.Visible = false;
            // 
            // labelComboBox1
            // 
            labelComboBox1.AutoSize = true;
            labelComboBox1.Location = new Point(6, 46);
            labelComboBox1.Name = "labelComboBox1";
            labelComboBox1.Size = new Size(68, 30);
            labelComboBox1.TabIndex = 6;
            labelComboBox1.Text = "label4";
            labelComboBox1.Visible = false;
            // 
            // labelComboBox3
            // 
            labelComboBox3.AutoSize = true;
            labelComboBox3.Location = new Point(6, 218);
            labelComboBox3.Name = "labelComboBox3";
            labelComboBox3.Size = new Size(68, 30);
            labelComboBox3.TabIndex = 10;
            labelComboBox3.Text = "label6";
            labelComboBox3.Visible = false;
            // 
            // labelComboBox2
            // 
            labelComboBox2.AutoSize = true;
            labelComboBox2.Location = new Point(6, 128);
            labelComboBox2.Name = "labelComboBox2";
            labelComboBox2.Size = new Size(68, 30);
            labelComboBox2.TabIndex = 8;
            labelComboBox2.Text = "label5";
            labelComboBox2.Visible = false;
            // 
            // AddOrEditForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 406);
            Controls.Add(ComboBoxGroupBox);
            Controls.Add(NumericAndTextBoxGroupBox);
            Controls.Add(btnOk);
            Controls.Add(btnClose);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 6, 5, 6);
            Name = "AddOrEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AddOrEditForm";
            NumericAndTextBoxGroupBox.ResumeLayout(false);
            NumericAndTextBoxGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown).EndInit();
            ComboBoxGroupBox.ResumeLayout(false);
            ComboBoxGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnClose;
        private Button btnOk;
        private Label labelTextBox1;
        private GroupBox NumericAndTextBoxGroupBox;
        private Label labelNumeric;
        private Label labelTextBox2;
        private GroupBox ComboBoxGroupBox;
        private Label labelComboBox1;
        private Label labelComboBox3;
        private Label labelComboBox2;
        public NumericUpDown numericUpDown;
        public TextBox textBox2;
        public TextBox textBox1;
        public ComboBox comboBox3;
        public ComboBox comboBox2;
        public ComboBox comboBox1;
    }
}