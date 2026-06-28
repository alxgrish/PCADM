using Microsoft.VisualBasic.Logging;
using MSTSCLib;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using PCAdministration_;
using RoyalApps.Community.Rdp;
using System.Collections.Concurrent;
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
            this.Load += MainForm_Loaded;

            // Останавливаем сервер при закрытии окна
            this.Closing += MainForm_Closing;
            this.Text += (GetLocalIpAddresses() + "\n");
            setRole(Role.RoleType.None);
            menuUpdate_Click(null, null);
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
        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*foreach (DataGridViewRow row in grid.Rows)
            {
                int TaskNum = Convert.ToInt32(row.Cells[5].Value);
                if (TaskNum is 0)
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#61CD28");
                else if (TaskNum is 1 or 2)
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                else row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FF5333");
            }*/

            // Берем значение из 5-го столбца ТОЛЬКО для текущей перерисовываемой строки
            var cellValue = grid.Rows[e.RowIndex].Cells[5].Value;

            if (cellValue is not null && int.TryParse(cellValue.ToString(), out int taskNum))
            {
                // Получаем ссылку на стиль текущей строки
                DataGridViewCellStyle rowStyle = grid.Rows[e.RowIndex].DefaultCellStyle;

                if (taskNum == 0)
                    rowStyle.BackColor = ColorTranslator.FromHtml("#61CD28");
                else if (taskNum is 1 or 2)
                    rowStyle.BackColor = Color.Yellow;
                else
                    rowStyle.BackColor = ColorTranslator.FromHtml("#FF5333");
            }
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
        private void MenuItemReg_Click(object sender, EventArgs e)
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
            setRole(userRole);
        }
        private void setRole(Role.RoleType role)
        {
            btn_remoteDesctop.Enabled = false;
            btn_BData.Enabled = false;
            btn_Administ.Enabled = false;
            btn_taskComplete.Enabled = false;
            btn_taskSave.Enabled = false;

            switch (role)
            {
                case Role.RoleType.None:
                    break;
                case Role.RoleType.User:
                    break;
                case Role.RoleType.Manager:
                    break;
                case Role.RoleType.Admin:
                    break;
                case Role.RoleType.MainAdmin:
                    break;
            }
        }
        private const int Port = 65432;
        private TcpListener? _listener;
        private CancellationTokenSource? _serverCts;

        // Потокобезопасная коллекция для хранения подключенных клиентов
        // Ключ: IP-адрес (или IP:Порт), Значение: StreamWriter для отправки данных
        private readonly ConcurrentDictionary<string, StreamWriter> _connectedClients =
            new ConcurrentDictionary<string, StreamWriter>();
        private async void MainForm_Loaded(object? sender, EventArgs e)
        {
            _serverCts = new CancellationTokenSource();
            _listener = new TcpListener(IPAddress.Any, Port);

            try
            {
                _listener.Start();

                while (!_serverCts.Token.IsCancellationRequested)
                {
                    TcpClient client = await _listener.AcceptTcpClientAsync();
                    _ = HandleClientAsync(client, _serverCts.Token);
                }
            }
            catch (Exception ex)
            {
                UpdateUiLog($"Ошибка сервера: {ex.Message}");
            }
        }
        private async Task HandleClientAsync(TcpClient client, CancellationToken ct)
        {
            // Получаем IP и порт клиента
            var ipEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
            if (ipEndPoint == null) return;

            // В качестве идентификатора можно использовать чистый IP (ipEndPoint.Address.ToString())
            // Или связку IP:Порт (ipEndPoint.ToString()), если клиентов с одного IP несколько
            string clientIp = ipEndPoint.Address.ToString();

            UpdateUiLog($"[{clientIp}] Клиент подключился");

            using (client)
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream) { AutoFlush = true })
            {
                // Добавляем или обновляем клиента в нашей базе активных подключений
                _connectedClients.AddOrUpdate(clientIp, writer, (key, oldWriter) => writer);

                try
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        UpdateUiLog($"[{clientIp} Получено]: {line}");
                    }
                }
                catch (Exception ex)
                {
                    UpdateUiLog($"[{clientIp}] Ошибка: {ex.Message}");
                }
                finally
                {
                    // При отключении обязательно удаляем клиента из коллекции
                    _connectedClients.TryRemove(clientIp, out _);
                    UpdateUiLog($"[{clientIp}] Клиент отключился");
                }
            }
        }
        private void UpdateUiLog(string message)
        {
            /*textBoxPCStatus.Invoke(() =>
            {
                textBoxPCStatus.Text += message;
            });*/
            // Проверяем, создано ли вообще окно. Если нет — записывать в UI пока нельзя
            if (!textBoxPCStatus.IsHandleCreated)
            {
                // Опционально: можно временно вывести в отладочную консоль IDE
                System.Diagnostics.Debug.WriteLine(message);
                return;
            }

            if (textBoxPCStatus.InvokeRequired)
            {
                textBoxPCStatus.Invoke(new Action(() => UpdateUiLog(message)));
            }
            else
            {
                textBoxPCStatus.AppendText($"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
            }
        }
        private void MainForm_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            _serverCts?.Cancel();
            _listener?.Stop();
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
            QRCodeForm qr = new QRCodeForm(userId.ToString());
            qr.ShowDialog();
        }

        private async void btn_pingToPC_Click(object sender, EventArgs e)
        {
            // Получаем IP-адрес из текстового поля на форме
            string targetIp = "172.16.0.2";

            if (string.IsNullOrEmpty(targetIp))
            {
                UpdateUiLog("Введите IP-адрес клиента!");
                return;
            }

            // Ищем клиента в нашей коллекции по IP
            if (_connectedClients.TryGetValue(targetIp, out StreamWriter? writer))
            {
                try
                {
                    UpdateUiLog($"[Сервер -> {targetIp}] Отправка внештатного запроса...");
                    await writer.WriteLineAsync("NEED_MORE_INFO");
                }
                catch (Exception ex)
                {
                    UpdateUiLog($"Ошибка отправки клиенту {targetIp}: {ex.Message}");
                }
            }
            else
            {
                UpdateUiLog($"Клиент с IP {targetIp} не найден или отключен.");
            }
        }

        private void btn_taskSave_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTask.SelectedValue is null or -1 || grid.CurrentRow is null || userId is null)
                return;
            if (MessageBox.Show("Точно хотите принять задание?", "Тикеты", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;
            Sql.QueryNonReturns("UPDATE `Tickets` SET `user_id` = @user_id, `status` = 'In_progress' WHERE `id` = @id", [new ("@user_id", userId), new("@id", grid.CurrentRow?.Cells[0])]);
            menuUpdate_Click(null, null);
        }

        private void btn_taskComplete_Click(object sender, EventArgs e)
        {
            if (new ToArchiveForm(Convert.ToInt32(grid.CurrentRow?.Cells[0].Value), userId).ShowDialog() != DialogResult.OK)
                return;
            MessageBox.Show("Данные по заданию сохранены!", "Тикеты", MessageBoxButtons.OK, MessageBoxIcon.Information);
            menuUpdate_Click(null, null);
        }
    }
}
