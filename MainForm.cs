using MSTSCLib;
using MySqlX.XDevAPI.Relational;
using PCAdministration_;
using RoyalApps.Community.Rdp;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using static PCADM.BDataForm;

namespace PCADM
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
            ContextFilter = new ContextFilter(grid, menuItemFilter);
        }
        ContextFilter ContextFilter;
        private void button5_Click(object sender, EventArgs e)
        {
            RDPPForm rdp = new RDPPForm();
            rdp.ShowDialog();
        }

        private void btn_Administ_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm(new Role(Role.RoleType.Admin));
            admin.ShowDialog();
        }
        private void Btn_BData_Click(object sender, EventArgs e)
        {
            BDataForm form = new();
            form.ShowDialog();
        }

        private void menuUpdate_Click(object? sender, EventArgs? e)
        {

            menuItemFilter.Enabled = true;
            grid.DataSource = null;
            grid.Columns.Clear();
            var tb = Sql.Query("SELECT `PC`.`id`, `pc_number` AS 'Номер ПК', " +
                "`ip` AS 'IP-адрес', concat(`c`.`name`, '&Этаж->', `c`.`floor`) " +
                "AS 'Кабинет', IFNULL((SELECT CONCAT(`u`.`full_name`, '&', `u`.`login`) " +
                "FROM `User` u JOIN `PC` p ON p.id = u.linked_cabinet_id WHERE " +
                "u.linked_cabinet_id = `PC`.id LIMIT 1), 'Нет Заведующего') AS 'Заведующий кабинетом', " +
                "(SELECT COUNT(*) FROM `Tickets` t where `t`.`pc_id` = `PC`.`id`) " +
                "AS 'Кол-во не решенных задач', IFNULL((select `status` from `Tickets` " +
                "where `Tickets`.`pc_id` = `PC`.`id` order by `id` DESC LIMIT 1), 'No problem') " +
                "AS 'Последний статус' FROM `PC` LEFT JOIN `Cabinet` c ON `c`.`id` = `PC`.`cabinet_id`");
            tb?.Columns.Add("Пинг пк");
            // add pings

            grid.DataSource = tb;
            if (grid.ColumnCount > 0)
                grid.Columns[0].Visible = false;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            grid.Visible = true;
            ContextFilter.ResetFilter(grid, menuItemFilter);
        }
        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            RichTextBox tb = textBoxPCStatus;
            tb.Text = string.Empty;
            comboBoxSelectTask.DataSource = null;
            DataGridViewRow row;
            if (grid.CurrentRow is null)
                return;
            else row = grid.CurrentRow;
            // first and second lines
            tb.SelectionFont = new Font(tb.Font, FontStyle.Italic);
            tb.AppendText("ПК: ");
            tb.SelectionFont = new Font(tb.Font, FontStyle.Bold);
            tb.AppendText(row.Cells[1].Value?.ToString());
            tb.SelectionFont = new Font(tb.Font, FontStyle.Italic);
            tb.AppendText(", IP-адрес: ");
            tb.SelectionFont = new Font(tb.Font, FontStyle.Bold);
            tb.AppendText(row.Cells[2].Value?.ToString());
            tb.SelectionFont = tb.Font;
            tb.AppendText(Environment.NewLine);
            tb.SelectionFont = new Font(tb.Font, FontStyle.Italic);
            tb.AppendText("Кабинет: ");
            tb.SelectionFont = new Font(tb.Font, FontStyle.Bold);
            tb.AppendText(row.Cells[3].Value?.ToString()?.Replace("&", "  "));
            tb.SelectionFont = tb.Font;
            tb.AppendText(Environment.NewLine);

            // ping
            bool ping = true; // method on ping
            tb.SelectionFont = new Font(tb.Font, FontStyle.Italic);
            tb.AppendText("Статус связи (Пинг): ");
            tb.SelectionFont = new Font(tb.Font, FontStyle.Bold);
            if (ping)
            {
                tb.SelectionColor = Color.Green;
                tb.AppendText("Пингуется");
            }
            else
            {
                tb.SelectionColor = Color.Red;
                tb.AppendText("Связи нет");
            }
            tb.SelectionFont = tb.Font;
            tb.SelectionColor = tb.ForeColor;
            tb.AppendText(Environment.NewLine);

            // task numbers
            tb.SelectionFont = new Font(tb.Font, FontStyle.Italic);
            tb.AppendText("Количество незакрытых тасков: ");
            tb.SelectionFont = new Font(tb.Font, FontStyle.Bold);
            int TaskNum = Convert.ToInt32(row.Cells[5].Value);
            if (TaskNum is 0)
                tb.SelectionColor = Color.Green;
            else if (TaskNum is 1 or 2)
                tb.SelectionColor = Color.Yellow;
            else tb.SelectionColor = Color.Red;
            tb.AppendText(TaskNum.ToString());
            tb.SelectionFont = tb.Font;
            tb.SelectionColor = tb.ForeColor;
            tb.AppendText(Environment.NewLine);

            //tasks
            var tsk = Sql.Query("SELECT `t`.`id`, `u`.`full_name`, " +
                "`u`.`login`, `u_m`.`full_name`, `u_m`.`login`, `p`.`code`, " +
                "`p`.`type`, `p`.`priority`, `t`.`status` FROM `Tickets` t " +
                "LEFT JOIN `User` u ON `t`.`user_id` = `u`.`id` LEFT JOIN `User` u_m " +
                "ON `t`.`master_user_id` = `u_m`.`id` LEFT JOIN `Problem` p " +
                "ON `t`.`problem_id` = `p`.id WHERE `t`.`pc_id` = @id", [new("@id", row.Cells[0].Value)]);
            var items = new List<object>();
            for (int i = 0; i < TaskNum; i++)
            {
                DataRow tRow;
                if (tsk?.Rows[i] is not null)
                    tRow = tsk.Rows[i];
                else continue;
                // opening
                tb.SelectionFont = new Font(tb.Font, FontStyle.Bold);
                tb.AppendText($"Задача {i + 1}:");
                items.Add(new { Id = tRow[0], Name = $"Задача {i + 1}" });
                tb.SelectionFont = tb.Font;
                tb.AppendText(Environment.NewLine);

                // user:
                tb.SelectionFont = new Font(tb.Font, FontStyle.Italic);
                tb.AppendText("Уполномоченный на исправление: ");
                tb.SelectionFont = new Font(tb.Font, FontStyle.Bold);
                tb.AppendText($"{tRow[1] ?? "(пусто)"} ({tRow[2] ?? "(пусто)"})");
                tb.AppendText(Environment.NewLine);

                // master:
                tb.SelectionFont = new Font(tb.Font, FontStyle.Italic);
                tb.AppendText("Отвечающий за исправление: ");
                tb.SelectionFont = new Font(tb.Font, FontStyle.Bold);
                tb.AppendText($"{tRow[3] ?? "(пусто)"} ({tRow[4] ?? "(пусто)"})");
                tb.AppendText(Environment.NewLine);

                // code, type and priority
                tb.SelectionFont = new Font(tb.Font, FontStyle.Italic);
                tb.AppendText("Код и приоритет: ");
                tb.SelectionFont = new Font(tb.Font, FontStyle.Bold);
                tb.AppendText($"{tRow[5] ?? "(пусто)"} ({tRow[6] ?? "(пусто)"}) = {tRow[7] ?? "(пусто)"}");
                tb.AppendText(Environment.NewLine);

                // state
                tb.SelectionFont = new Font(tb.Font, FontStyle.Italic);
                tb.AppendText("Статус: ");
                tb.SelectionFont = new Font(tb.Font, FontStyle.Bold);
                tb.AppendText((string?)tRow[8] ?? "(пусто)");
                tb.AppendText(Environment.NewLine);

                tb.AppendText(Environment.NewLine);
            }
            comboBoxSelectTask.DataSource = items;
            comboBoxSelectTask.DisplayMember = "Name";
            comboBoxSelectTask.ValueMember = "Id";
        }
        int? userId;
        private void MenuItemRegist_Click(object sender, EventArgs e)
        {
            var form = new RegForm();
            if (form.ShowDialog() != DialogResult.OK)
            {
                userId = null;
                TextBoxLogin.Text = "Login";
                TextBoxRole.Text = "Role";
                return;
            }
            userId = form.UserId;
            TextBoxLogin.Text = form.UserLogin;
            Role.RoleType userRole = form.UserRole;
            TextBoxRole.Text = userRole.ToString();
            //
        }
    }
}
