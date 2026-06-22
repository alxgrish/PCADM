namespace PCADM
{
    partial class Qr
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
            QrPB = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)QrPB).BeginInit();
            SuspendLayout();
            // 
            // QrPB
            // 
            QrPB.Location = new Point(0, 0);
            QrPB.Name = "QrPB";
            QrPB.Size = new Size(322, 297);
            QrPB.TabIndex = 0;
            QrPB.TabStop = false;
            // 
            // Qr
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 295);
            Controls.Add(QrPB);
            Name = "Qr";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)QrPB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox QrPB;
    }
}