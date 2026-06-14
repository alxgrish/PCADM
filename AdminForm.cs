using MySql.Data.MySqlClient;
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
    public partial class AdminForm : Form
    {
        private DataTable? usersTable;
        private Role currentUserRole;
        public AdminForm(Role currentRole)
        {
            InitializeComponent();
            this.currentUserRole = currentRole;
            LoadUsers();
            LoadCabinets();
            ApplyRolePermissions();
        }
        private void LoadUsers()
        {

            string query = "SELECT `User`.`id`, `full_name` AS 'ФИО', `login`, `role`, '********' AS 'Пароль' " +
                "CONCAT(`Cabinet`.`name`, '-', `Cabinet`.`floor`) AS 'Закреплённый кабинет' " +
                "FROM `User` LEFT JOIN `Cabinet` ON `User`.`linked_cabinet_id` = `Cabinet`.`id` " +
                "ORDER BY `User`.`id`;";
            usersTable = Sql.Query(query);
            if (usersTable != null)
            {
                dgvUsers.DataSource = usersTable;

                // Настройка отображения колонок
                /*if (dgvUsers.Columns.Contains("id"))
                    dgvUsers.Columns["id"].HeaderText = "ID";
                if (dgvUsers.Columns.Contains("full_name"))
                    dgvUsers.Columns["full_name"].HeaderText = "Полное имя";
                if (dgvUsers.Columns.Contains("login"))
                    dgvUsers.Columns["login"].HeaderText = "Логин";
                if (dgvUsers.Columns.Contains("role"))
                    dgvUsers.Columns["role"].HeaderText = "Роль";
                if (dgvUsers.Columns.Contains("cabinet_name"))
                    dgvUsers.Columns["cabinet_name"].HeaderText = "Кабинет";
                if (dgvUsers.Columns.Contains("floor"))
                    dgvUsers.Columns["floor"].HeaderText = "Этаж";

                // Скрыть технические колонки
                if (dgvUsers.Columns.Contains("cabinet_id"))
                    dgvUsers.Columns["cabinet_id"].Visible = false;*/
            }
        }

        private void LoadCabinets()
        {
            string query = "SELECT id, CONCAT(floor, ' - ', name) as display_name FROM Cabinet ORDER BY floor, name";
            DataTable? cabinets = Sql.Query(query);

            if (cabinets != null && cabinets.Rows.Count > 0)
            {
                // Добавляем пустую строку для выбора "Не привязан"
                DataRow emptyRow = cabinets.NewRow();
                emptyRow["id"] = DBNull.Value;
                emptyRow["display_name"] = "Не привязан";
                cabinets.Rows.InsertAt(emptyRow, 0);

                cmbCabinet.DisplayMember = "display_name";
                cmbCabinet.ValueMember = "id";
                cmbCabinet.DataSource = cabinets;
                cmbCabinet.SelectedIndex = 0;
            }
        }

        private void ApplyRolePermissions()
        {
            Role.RoleType roleType = currentUserRole.GetRole();

            // MainAdmin имеет полный доступ
            if (roleType == Role.RoleType.MainAdmin)
            {
                cmbRole.Enabled = true;
                cmbRole.Items.Clear();
                cmbRole.Items.AddRange(new object[] { "User", "Manager", "Admin", "Main_Admin" });
                return;
            }

            // Admin не может создавать MainAdmin
            if (roleType == Role.RoleType.Admin)
            {
                cmbRole.Enabled = true;
                cmbRole.Items.Clear();
                cmbRole.Items.AddRange(new object[] { "User", "Manager", "Admin" });
            }
            // Manager видит только User
            else if (roleType == Role.RoleType.Manager)
            {
                cmbRole.Enabled = false;
                cmbRole.Items.Clear();
                cmbRole.Items.Add("User");
                cmbRole.SelectedIndex = 0;
            }
            // User не должен видеть эту форму
            else
            {
                MessageBox.Show("У вас нет прав доступа к этой форме!", "Ошибка доступа",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        private void CreateBackup(string filePath)
        {
            using (MySqlConnection connection = new MySqlConnection(GetConnectionStringWithoutDatabase()))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;

                    // Получаем все таблицы
                    cmd.CommandText = "SHOW TABLES FROM Answer_Book_problem";
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<string> tables = new List<string>();
                        while (reader.Read())
                        {
                            tables.Add(reader[0]?.ToString() ?? string.Empty);
                        }
                        reader.Close();

                        using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                        {
                            // Записываем заголовок
                            writer.WriteLine($"-- Backup created: {DateTime.Now}");
                            writer.WriteLine($"-- Database: Answer_Book_problem");
                            writer.WriteLine();
                            writer.WriteLine("CREATE DATABASE IF NOT EXISTS `Answer_Book_problem` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci */;");
                            writer.WriteLine("USE `Answer_Book_problem`;");
                            writer.WriteLine();

                            // Для каждой таблицы получаем структуру и данные
                            foreach (string table in tables)
                            {
                                // Структура таблицы
                                cmd.CommandText = $"SHOW CREATE TABLE `{table}`";
                                using (var createReader = cmd.ExecuteReader())
                                {
                                    if (createReader.Read())
                                    {
                                        writer.WriteLine($"-- Table structure for table `{table}`");
                                        writer.WriteLine("--");
                                        writer.WriteLine(createReader[1].ToString() + ";");
                                        writer.WriteLine();
                                    }
                                    createReader.Close();
                                }

                                // Данные таблицы
                                cmd.CommandText = $"SELECT * FROM `{table}`";
                                using (var dataReader = cmd.ExecuteReader())
                                {
                                    if (dataReader.HasRows)
                                    {
                                        writer.WriteLine($"-- Dumping data for table `{table}`");
                                        writer.WriteLine("--");

                                        while (dataReader.Read())
                                        {
                                            List<string> values = new List<string>();
                                            for (int i = 0; i < dataReader.FieldCount; i++)
                                            {
                                                object value = dataReader[i];
                                                if (value == DBNull.Value)
                                                    values.Add("NULL");
                                                else if (value is string || value is DateTime || value is char)
                                                    values.Add($"'{EscapeString(value.ToString() ?? string.Empty)}'");
                                                else
                                                    values.Add(value?.ToString() ?? string.Empty);
                                            }
                                            writer.WriteLine($"INSERT INTO `{table}` VALUES ({string.Join(",", values)});");
                                        }
                                        writer.WriteLine();
                                    }
                                    dataReader.Close();
                                }
                            }

                            writer.WriteLine("-- Backup completed successfully");
                        }
                    }
                }
            }
        }
        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsers.SelectedRows[0];
                txtFullName.Text = row.Cells["full_name"].Value?.ToString() ?? "";
                txtLogin.Text = row.Cells["login"].Value?.ToString() ?? "";
                txtPassword.Clear();

                string role = row.Cells["role"].Value?.ToString() ?? "User";
                if (cmbRole.Items.Contains(role))
                    cmbRole.SelectedItem = role;

                if (row.Cells["cabinet_id"].Value != DBNull.Value && row.Cells["cabinet_id"].Value != null)
                {
                    int cabinetId = Convert.ToInt32(row.Cells["cabinet_id"].Value);
                    cmbCabinet.SelectedValue = cabinetId;
                }
                else
                {
                    cmbCabinet.SelectedIndex = 0;
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Логин обязателен для заполнения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Пароль обязателен для заполнения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка существования логина
            string checkQuery = "SELECT COUNT(*) FROM User WHERE login = @login";
            MySqlParameter[] checkParams = { new MySqlParameter("@login", txtLogin.Text.Trim()) };
            object? result = Sql.QueryOneReturn(checkQuery, checkParams);

            if (result != null && Convert.ToInt64(result) > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO User (full_name, login, password, role, linked_cabinet_id) 
                             VALUES (@full_name, @login, @password, @role, @cabinet_id)";

            object cabinetValue = DBNull.Value;
            if (cmbCabinet.SelectedValue != null && cmbCabinet.SelectedValue != DBNull.Value)
            {
                try
                {
                    int cabinetId = Convert.ToInt32(cmbCabinet.SelectedValue);
                    if (cabinetId > 0)
                        cabinetValue = cabinetId;
                }
                catch { }
            }

            MySqlParameter[] parameters = {
                new MySqlParameter("@full_name", txtFullName.Text.Trim()),
                new MySqlParameter("@login", txtLogin.Text.Trim()),
                new MySqlParameter("@password", txtPassword.Text),
                new MySqlParameter("@role", cmbRole.SelectedItem?.ToString() ?? "User"),
                new MySqlParameter("@cabinet_id", cabinetValue)
            };

            if (Sql.QueryNonReturns(query, parameters))
            {
                MessageBox.Show("Пользователь успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
                BtnClear_Click(null, null);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя для изменения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["id"].Value);

            object cabinetValue = DBNull.Value;
            if (cmbCabinet.SelectedValue != null && cmbCabinet.SelectedValue != DBNull.Value)
            {
                try
                {
                    int cabinetId = Convert.ToInt32(cmbCabinet.SelectedValue);
                    if (cabinetId > 0)
                        cabinetValue = cabinetId;
                }
                catch { }
            }

            bool success;

            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                string query = @"UPDATE User SET full_name = @full_name, login = @login, password = @password, 
                                  role = @role, linked_cabinet_id = @cabinet_id WHERE id = @id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@full_name", txtFullName.Text.Trim()),
                    new MySqlParameter("@login", txtLogin.Text.Trim()),
                    new MySqlParameter("@password", txtPassword.Text),
                    new MySqlParameter("@role", cmbRole.SelectedItem?.ToString() ?? "User"),
                    new MySqlParameter("@cabinet_id", cabinetValue),
                    new MySqlParameter("@id", userId)
                };
                success = Sql.QueryNonReturns(query, parameters);
            }
            else
            {
                string query = @"UPDATE User SET full_name = @full_name, login = @login, 
                                  role = @role, linked_cabinet_id = @cabinet_id WHERE id = @id";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@full_name", txtFullName.Text.Trim()),
                    new MySqlParameter("@login", txtLogin.Text.Trim()),
                    new MySqlParameter("@role", cmbRole.SelectedItem?.ToString() ?? "User"),
                    new MySqlParameter("@cabinet_id", cabinetValue),
                    new MySqlParameter("@id", userId)
                };
                success = Sql.QueryNonReturns(query, parameters);
            }

            if (success)
            {
                MessageBox.Show("Пользователь успешно обновлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пользователя для удаления!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["id"].Value);
            string? login = dgvUsers.SelectedRows[0].Cells["login"].Value?.ToString();

            DialogResult result = MessageBox.Show($"Удалить пользователя '{login}'?\nЭто действие необратимо!",
                "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Сначала обновляем связанные записи (устанавливаем NULL)
                string updateTicketsQuery = "UPDATE Tickets SET user_id = NULL, master_user_id = NULL WHERE user_id = @id OR master_user_id = @id";
                MySqlParameter[] updateParams = { new MySqlParameter("@id", userId) };
                Sql.QueryNonReturns(updateTicketsQuery, updateParams);

                // Затем удаляем пользователя
                string deleteQuery = "DELETE FROM User WHERE id = @id";
                if (Sql.QueryNonReturns(deleteQuery, updateParams))
                {
                    MessageBox.Show("Пользователь успешно удален!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                    BtnClear_Click(null, null);
                }
            }
        }

        private void BtnClear_Click(object? sender, EventArgs? e)
        {
            txtFullName.Clear();
            txtLogin.Clear();
            txtPassword.Clear();
            if (cmbRole.Items.Count > 0)
                cmbRole.SelectedIndex = 0;
            if (cmbCabinet.Items.Count > 0)
                cmbCabinet.SelectedIndex = 0;
            dgvUsers.ClearSelection();
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                sfd.FileName = $"backup_Answer_Book_problem_{DateTime.Now:yyyyMMdd_HHmmss}.sql";
                sfd.Title = "Сохранить резервную копию базы данных";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        CreateBackup(sfd.FileName);
                        MessageBox.Show($"Резервная копия успешно создана!\n{sfd.FileName}",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при создании резервной копии:\n{ex.Message}",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
                ofd.Title = "Выберите файл резервной копии";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DialogResult confirm = MessageBox.Show(
                        "Восстановление базы данных удалит все текущие данные!\n" +
                        "Продолжить?", "Предупреждение",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            RestoreBackup(ofd.FileName);
                            MessageBox.Show("База данных успешно восстановлена!",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUsers();
                            LoadCabinets();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при восстановлении:\n{ex.Message}",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void RestoreBackup(string filePath)
        {
            string content = File.ReadAllText(filePath, Encoding.UTF8);

            // Разделяем SQL на команды
            string[] commands = content.Split(new[] { ";\n", ";\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            using (MySqlConnection connection = new MySqlConnection(GetConnectionStringWithoutDatabase()))
            {
                connection.Open();

                foreach (string command in commands)
                {
                    string cleanCommand = command.Trim();
                    if (string.IsNullOrWhiteSpace(cleanCommand))
                        continue;

                    // Пропускаем USE команду если БД уже существует
                    if (cleanCommand.StartsWith("USE", StringComparison.OrdinalIgnoreCase))
                        continue;

                    using (MySqlCommand cmd = new MySqlCommand(cleanCommand, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private string GetConnectionStringWithoutDatabase()
        {
            return "Server=localhost;Port=3306;UserID=root;Password=;ConnectionTimeout=5;CharacterSet=utf8mb4";
        }

        private string EscapeString(string value)
        {
            if (value == null) return "";
            return value.Replace("\\", "\\\\").Replace("'", "\\'");
        }
    }
}
