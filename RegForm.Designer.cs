namespace PCADM
{
    partial class RegForm
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
            label2 = new Label();
            textBoxLogin = new TextBox();
            button = new Button();
            pictureBox = new PictureBox();
            textBoxPassword = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 9);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 30);
            label1.TabIndex = 0;
            label1.Text = "Логин:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 56);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 30);
            label2.TabIndex = 1;
            label2.Text = "Пароль:";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(114, 6);
            textBoxLogin.Margin = new Padding(5, 6, 5, 6);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(236, 35);
            textBoxLogin.TabIndex = 1;
            // 
            // button
            // 
            button.Location = new Point(114, 107);
            button.Margin = new Padding(5, 6, 5, 6);
            button.Name = "button";
            button.Size = new Size(129, 46);
            button.TabIndex = 3;
            button.Text = "Вход";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // pictureBox
            // 
            pictureBox.Image = Properties.Resources.openEye;
            pictureBox.Location = new Point(314, 53);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(36, 35);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 4;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(114, 53);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(199, 35);
            textBoxPassword.TabIndex = 2;
            // 
            // RegForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 168);
            Controls.Add(textBoxPassword);
            Controls.Add(pictureBox);
            Controls.Add(button);
            Controls.Add(textBoxLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 6, 5, 6);
            Name = "RegForm";
            Text = "RegForm";
            Load += Authorization_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxLogin;
        private Button button;
        private PictureBox pictureBox;
        private MaskedTextBox textBoxPassword;
    }
}