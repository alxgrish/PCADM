using PCAdministration_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCADM
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
            pictureBox_Click(null, null);
        }
        private bool is_open = true;
        private void button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Не введен логин!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxLogin.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Не введен пароль!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxPassword.Focus();
                return;
            }
            var tb = Sql.Query("select * from user where login = @login", [new("@login", textBoxLogin.Text.Trim())]);
            if (tb is null)
                return;
            if (tb.Rows.Count is not 1)
            {
                MessageBox.Show("Данный логин не найден!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tb.Rows[0]["password"].ToString() != Sql.QueryOneReturn("select sha2(@pass, 512)", [new("@pass", textBoxPassword.Text.Trim()?.ToString())])?.ToString())
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UserId = Convert.ToInt32(tb.Rows[0][0]);
            UserLogin = tb.Rows[0][3]?.ToString() ?? string.Empty;
            UserRole = Role.Parse(tb.Rows[0][1]?.ToString() ?? string.Empty);
            DialogResult = DialogResult.OK;
        }
        public int UserId;
        public string UserLogin;
        public Role.RoleType UserRole;
        private void pictureBox_Click(object? sender, EventArgs? e)
        {
            is_open = !is_open;
            if (is_open)
            {
                textBoxPassword.UseSystemPasswordChar = false;
                pictureBox.Image = Properties.Resources.openEye;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
                pictureBox.Image = Properties.Resources.closeEye;
            }
        }
        private void Authorization_Load(object sender, EventArgs e)
        {
            using LinearGradientBrush skyBrush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, button.Height),
                ColorTranslator.FromHtml("#D0FEFD"),
                ColorTranslator.FromHtml("#011227"));
            Bitmap bitmap = new(button.Width, button.Height);
            using Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(skyBrush, 0, 0, button.Width, button.Height);
            button.BackgroundImage = bitmap;
        }
    }
}
