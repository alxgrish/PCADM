using MySqlX.XDevAPI.Relational;
using PCAdministration_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCADM
{
    public partial class AddOrEditForm : Form
    {
        public AddOrEditForm(BDataForm.Tables table, int? id = null)
        {
            InitializeComponent();
            if (id is null)
                this.Text = "Добавление ";
            else
                this.Text = "Изменение ";
            switch (table)
            {
                case BDataForm.Tables.Cabinet:
                    labelTextBox1.Text = "*Название кабинета";
                    labelTextBox2.Text = "*Этаж";
                    textBox1.PlaceholderText = "Математика";
                    textBox1.Tag = "1";
                    textBox2.PlaceholderText = "3";
                    textBox2.Tag = "1";
                    this.Text += "Кабинета ";
                    break;
                case BDataForm.Tables.PC:
                    labelTextBox1.Text = "*Номер компьютера";
                    labelTextBox2.Text = "IP адрес";
                    textBox1.PlaceholderText = "11a";
                    textBox1.Tag = "1";
                    textBox2.PlaceholderText = "192.168.1.1";
                    labelComboBox1.Visible = true;
                    comboBox1.Visible = true;
                    labelComboBox1.Text = "Кабинет для ПК";
                    LoadToComboBox("id", "name", BDataForm.Tables.Cabinet, comboBox1);
                    this.Text += "Компьютера ";
                    break;
                case BDataForm.Tables.Problem:
                    labelTextBox1.Text = "*Тип проблемы";
                    labelTextBox2.Text = "*Код проблемы";
                    textBox1.PlaceholderText = "Нетъ сети";
                    textBox1.Tag = "1";
                    textBox2.PlaceholderText = "CS0168";
                    textBox2.Tag= "1";
                    labelNumeric.Visible = true;
                    numericUpDown.Visible = true;
                    labelNumeric.Text = "*Приоритет решения";
                    numericUpDown.Tag = "1";
                    this.Text += "Проблемы ";
                    break;
            }
            if (id != null)
            {
                var tb = Sql.Query($"select * from `{table}`", [new("@id", id)]);
                switch (table)
                {
                    case BDataForm.Tables.Cabinet:
                        textBox1.Text = tb?.Rows[0][1].ToString();
                        textBox2.Text = tb?.Rows[0][2].ToString();
                        break;
                    case BDataForm.Tables.PC:
                        textBox1.Text = tb?.Rows[0][2].ToString();
                        textBox2.Text = tb?.Rows[0][3].ToString();
                        try
                        {
                            comboBox1.SelectedValue = Convert.ToInt32(tb?.Rows[0][1].ToString());
                        }
                        catch
                        {
                            comboBox1.SelectedValue = -1;
                        }
                        break;
                    case BDataForm.Tables.Problem:
                        textBox1.Text = tb?.Rows[0][1].ToString();
                        textBox2.Text = tb?.Rows[0][2].ToString();
                        numericUpDown.Value = Convert.ToInt32(tb?.Rows[0][3].ToString());
                        break;
                }
            }
        }
        public static void LoadToComboBox(string value_id, string value_name, BDataForm.Tables table, ComboBox cmb, string? where = null)
        {
            var tb = Sql.Query($"select `{value_id}`, `{value_name}` from `{table}` {where}");
            if (tb is null)
                return;
            cmb.Items.Clear();
            cmb.DataSource = null;
            DataRowCollection? Row = tb.Rows;
            var items = new List<object>();
            foreach (DataRow row in Row)
                items.Add(new { Id = row[0], Name = row[1] });
            cmb.DataSource = items;
            cmb.DisplayMember = "Name";
            cmb.ValueMember = "Id";
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!DataCheck(labelTextBox1, textBox1) ||
                !DataCheck(labelTextBox2, textBox2) ||
                !DataCheck(labelNumeric, numericUpDown) ||
                !DataCheck(labelComboBox1, comboBox1) ||
                !DataCheck(labelComboBox2, comboBox2) ||
                !DataCheck(labelComboBox3, comboBox3))
                return;
            DialogResult = DialogResult.OK;
        }
        private static bool DataCheck(Control label, Control element)
        {
            if (element.Text.Trim().Length == 0 && element.Tag?.ToString() == "1")
            {
                MessageBox.Show($"Вы не заполнили обязательное поле \"{label.Text}\"\n" +
                    "Заполните его!", "Ошибка записи!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                element.Focus();
                element.BackColor = Color.Red;
                return false;
            }
            element.BackColor = Color.White;
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e) =>
            DialogResult = DialogResult.Cancel;
    }
}
