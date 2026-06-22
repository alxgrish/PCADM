using MySql.Data.MySqlClient;
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
    public partial class BDataForm : Form
    {
        public BDataForm()
        {
            InitializeComponent();
            grid_SelectionChanged(null, null);
        }
        private void ShowTable()
        {
            //contextFilterItem.Enabled = true;
            grid.DataSource = null;
            grid.Columns.Clear();
            if (table is Tables.None)
            {
                grid.Rows.Clear();
                grid.Visible = false;
                //contextFilterItem.Enabled = false;
                return;
            }
            var selects = GetSelect(table);
            string? like = null;
            /*if (!string.IsNullOrEmpty(searchEngine.Text))
                like = $"Concat({getSelectsNotAs(selects)})" + " like ";*/
            //var joins = getJoins();
            var tb = Sql.Query($"select {(selects is not null ? selects : "*")} " +
                $"from `{table}` " +
                $"{(like is not null ? "where" : string.Empty)} " +
                $"{(like is not null ? like + " @like" : string.Empty)} ",
                [new("@like", string.Concat("%", /*searchEngine.Text, */"%"))]);
            grid.DataSource = tb;
            if (grid.ColumnCount > 0)
                grid.Columns[0].Visible = false;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            grid.Visible = true;
            //ContextFilter.ResetFilter(grid, contextFilterItem);
        }
        private static string? GetSelect(Tables table)
        {
            return (table) switch
            {
                Tables.Cabinet => "`Cabinet`.`id`, `Cabinet`.`name` as \"Название кабинета\", " +
                "`Cabinet`.`floor` as \"Этаж\"",
                _ => null
            };
        }
        private void ShowTables_Click(object sender, EventArgs e)
        {
            table = TableParse(((Control)sender).Tag?.ToString()) ?? Tables.None;
            ShowTable();
        }
        public Tables? TableParse(string? table)
        {
            return (table?.ToLower()) switch
            {
                "cabinet" => Tables.Cabinet,
                "pc" => Tables.PC,
                "problem" => Tables.Problem,
                "archive" => Tables.Archive,
                _ => null
            };
        }
        private Tables table = Tables.None;
        public enum Tables
        {
            None,
            Cabinet,
            PC,
            Problem,
            Archive
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddOrEditForm form;
            switch (table)
            {
                case Tables.Cabinet:
                    form = new(table);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns($"insert into `{table}`(name, floor) " +
                        "values (@name, @floor)", [
                            new ("@name", form.textBox1.Text),
                            new ("@floor", form.textBox2.Text)
                        ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Tables.PC:
                    form = new(table);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns($"insert into `{table}`(cabinet_id, pc_number, ip) " +
                        "values (@cabinet_id, @pc_number, @ip)", [
                            new ("@cabinet_id", Convert.ToInt32(form.comboBox1.SelectedValue) != -1 ? form.comboBox1.SelectedValue : DBNull.Value),
                            new ("@pc_number", form.textBox1.Text),
                            new ("@ip", form.textBox2.Text.Trim().Length > 0 ? form.textBox2.Text : DBNull.Value)
                        ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Tables.Problem:
                    form = new(table);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns($"insert into `{table}`(type, code, priority) " +
                        "values (@type, @code, @priority)", [
                            new ("@type", form.textBox1.Text),
                            new ("@code", form.textBox2.Text),
                            new ("@priority", form.numericUpDown.Value)
                        ]))
                        MessageBoxForErrorsToShow();
                    break;
                default: return;
            }
            ShowTable();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AddOrEditForm form;
            var id = Convert.ToInt32(grid.SelectedRows[0].Cells[0].Value);
            switch (table)
            {
                case Tables.Cabinet:
                    form = new(table, id);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns($"update `{table}` " +
                        $"set name = @name, floor = @floor where `{table}`.`id` = @id", [
                            new ("@id", id),
                            new ("@name", form.textBox1.Text),
                            new ("@floor", form.textBox2.Text)
                        ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Tables.PC:
                    form = new(table, id);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns($"update `{table}` " +
                        $"set cabinet_id = @cabinet_id, pc_number = @pc_number, ip = @ip where `{table}`.`id` = @id", [
                            new ("@id", id),
                            new ("@cabinet_id", Convert.ToInt32(form.comboBox1.SelectedValue) != -1 ? form.comboBox1.SelectedValue : DBNull.Value),
                            new ("@pc_number", form.textBox1.Text),
                            new ("@ip", form.textBox2.Text.Trim().Length > 0 ? form.textBox2.Text : DBNull.Value)
                        ]))
                        MessageBoxForErrorsToShow();
                    break;
                case Tables.Problem:
                    form = new(table, id);
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    if (!Sql.QueryNonReturns($"update `{table}` " +
                        $"set type = @type, code = @code, priority = @priority where `{table}`.`id` = @id", [
                            new ("@id", id),
                            new ("@type", form.textBox1.Text),
                            new ("@code", form.textBox2.Text),
                            new ("@priority", form.numericUpDown.Value)
                        ]))
                        MessageBoxForErrorsToShow();
                    break;
                default: return;
            }
            ShowTable();
        }
        private static void MessageBoxForErrorsToShow()
            => MessageBox.Show("Ошибка записи данных!\nВозможные причины смотреть в руководстве " +
                "пользователя", "Ошибка Sql", MessageBoxButtons.OK, MessageBoxIcon.Error);
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (table is Tables.None)
                return;
            else if (MessageBox.Show("Точно хотите удалить выбранную(ые) запись(и)?", "Удаление",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                is not DialogResult.OK)
                return;
            foreach (DataGridViewRow row in grid.SelectedRows)
                Sql.QueryNonReturns($"delete from `{table}` " +
                    $"where id = @id",
                    [new("@id", row.Cells[0].Value)]);
            ShowTable();
        }

        private void grid_SelectionChanged(object? sender, EventArgs? e)
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnPrint.Enabled = false;
            if (table == Tables.None)
                return;
            btnAdd.Enabled = true;
            if (grid.SelectedRows.Count is 1)
            {
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnPrint.Enabled = true;
            }
            else if (grid.SelectedRows.Count > 1)
            {
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }
            if (table == Tables.Archive)
            {
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
            }
            else if (table == Tables.Problem)
            {
                btnDelete.Enabled = false;
            }
        }

        private void menuUpdate_Click(object sender, EventArgs e)
            => ShowTable();
    }
}
