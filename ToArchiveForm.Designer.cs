namespace PCADM
{
    partial class ToArchiveForm
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
            label1 = new Label();
            textBoxMaster = new TextBox();
            label2 = new Label();
            textBoxProblem = new TextBox();
            label3 = new Label();
            textBoxPC = new TextBox();
            comboBoxState = new ComboBox();
            label4 = new Label();
            textBoxComment = new TextBox();
            label5 = new Label();
            buttonCancel = new Button();
            buttonOk = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 12);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 0;
            label1.Text = "Мастер";
            // 
            // textBoxMaster
            // 
            textBoxMaster.Location = new Point(84, 12);
            textBoxMaster.Name = "textBoxMaster";
            textBoxMaster.ReadOnly = true;
            textBoxMaster.Size = new Size(344, 23);
            textBoxMaster.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 55);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 0;
            label2.Text = "Проблема";
            // 
            // textBoxProblem
            // 
            textBoxProblem.Location = new Point(84, 55);
            textBoxProblem.Name = "textBoxProblem";
            textBoxProblem.ReadOnly = true;
            textBoxProblem.Size = new Size(344, 23);
            textBoxProblem.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 99);
            label3.Name = "label3";
            label3.Size = new Size(23, 15);
            label3.TabIndex = 0;
            label3.Text = "ПК";
            // 
            // textBoxPC
            // 
            textBoxPC.Location = new Point(84, 96);
            textBoxPC.Name = "textBoxPC";
            textBoxPC.ReadOnly = true;
            textBoxPC.Size = new Size(152, 23);
            textBoxPC.TabIndex = 3;
            // 
            // comboBoxState
            // 
            comboBoxState.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxState.FormattingEnabled = true;
            comboBoxState.Location = new Point(327, 96);
            comboBoxState.Name = "comboBoxState";
            comboBoxState.Size = new Size(101, 23);
            comboBoxState.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(258, 99);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 0;
            label4.Text = "Статус";
            // 
            // textBoxComment
            // 
            textBoxComment.Location = new Point(11, 153);
            textBoxComment.Multiline = true;
            textBoxComment.Name = "textBoxComment";
            textBoxComment.Size = new Size(441, 91);
            textBoxComment.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 135);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 0;
            label5.Text = "Комментарий";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(11, 265);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(377, 265);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 6;
            buttonOk.Text = "Принять";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // ToArchiveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(465, 300);
            Controls.Add(buttonOk);
            Controls.Add(buttonCancel);
            Controls.Add(comboBoxState);
            Controls.Add(textBoxPC);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(textBoxComment);
            Controls.Add(textBoxProblem);
            Controls.Add(label2);
            Controls.Add(textBoxMaster);
            Controls.Add(label1);
            Name = "ToArchiveForm";
            Text = "ToArchiveForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxMaster;
        private Label label2;
        private TextBox textBoxProblem;
        private Label label3;
        private TextBox textBoxPC;
        private ComboBox comboBoxState;
        private Label label4;
        private TextBox textBoxComment;
        private Label label5;
        private Button buttonCancel;
        private Button buttonOk;
    }
}