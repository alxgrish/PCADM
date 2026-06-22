using Microsoft.VisualBasic.Logging;
using MSTSCLib;
using MySqlX.XDevAPI.Relational;
using PCAdministration_;
using RoyalApps.Community.Rdp;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using ZXing;
using ZXing.QrCode;
using static PCADM.BDataForm;

namespace PCADM
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
            ContextFilter = new ContextFilter(grid, menuItemFilter);
            // Запускаем сервер при открытии окна
            this.Load += MainWindow_Loaded;

            // Останавливаем сервер при закрытии окна
            this.Closing += MainWindow_Closing;
            this.Text += (GetLocalIpAddresses() + "\n");
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
            foreach (DataGridViewRow row in grid.Rows)
            {
                int TaskNum = Convert.ToInt32(row.Cells[5].Value);
                if (TaskNum is 0)
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#61CD28");
                else if (TaskNum is 1 or 2)
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                else row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FF5333");
            }
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
        private const int Port = 65432;
        private TcpListener? _server;
        private bool _isRunning = false;
        private void MainWindow_Loaded(object? sender, EventArgs e)
        {
            _isRunning = true;
            // Запуск сервера в фоновом потоке, чтобы UI не зависал
            Task.Run(() => StartServerAsync());

        }
        private async Task StartServerAsync()
        {
            try
            {
                _server = new TcpListener(IPAddress.Any, Port);
                _server.Start();

                while (_isRunning)
                {
                    TcpClient client = await _server.AcceptTcpClientAsync();
                    _ = Task.Run(() => HandleClientAsync(client));
                }
            }
            catch (Exception ex)
            {
                UpdateUiLog($"Ошибка сервера: {ex.Message}\n");
            }
        }
        private async Task HandleClientAsync(TcpClient client)
        {
            string? ip = ((IPEndPoint?)client.Client.RemoteEndPoint)?.Address.ToString();

            try
            {
                using (client)
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead > 0)
                    {
                        string jsonString = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        using (JsonDocument doc = JsonDocument.Parse(jsonString))
                        {
                            JsonElement root = doc.RootElement;

                            string? hostname = root.GetProperty("hostname").GetString();
                            double cpu = root.GetProperty("cpu_usage").GetDouble();
                            double ram = root.GetProperty("ram_usage").GetDouble();
                            double disk = root.GetProperty("disk_usage").GetDouble();

                            // Формируем красивую строку для вывода
                            string report = $"[{DateTime.Now:HH:mm:ss}] ПК: {hostname} ({ip})\n" +
                                            $" -- CPU: {cpu}% | RAM: {ram}% | С: {disk}%\n" +
                                            $"{new string('-', 45)}\n";

                            // Отправляем текст в UI поток
                            UpdateUiLog(report);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UpdateUiLog($"Ошибка чтения от {ip}: {ex.Message}\n");
            }
        }
        private void UpdateUiLog(string message)
        {
            textBoxPCStatus.Invoke(() =>
            {
                textBoxPCStatus.Text += message;
            });
        }


        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            _isRunning = false;
            _server?.Stop();
        }
        private string GetLocalIpAddresses()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ipList = new System.Collections.Generic.List<string>();

            foreach (var ip in host.AddressList)
            {
                // Отбираем только IPv4 адреса и исключаем локальную петлю 127.0.0.1
                if (ip.AddressFamily == AddressFamily.InterNetwork && ip.ToString() != "127.0.0.1")
                {
                    ipList.Add(ip.ToString());
                }
            }

            // Если сетевых интерфейсов несколько (Wi-Fi и провод), вернет их через запятую
            return ipList.Count > 0 ? string.Join(", ", ipList) : "127.0.0.1";
        }

        private void btn_qrCode_Click(object sender, EventArgs e)
        {
            Qr qr = new Qr(userId.ToString());
            qr.ShowDialog();
        }
    }
}
