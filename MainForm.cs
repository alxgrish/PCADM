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
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using static PCADM.BDataForm;
using static PCAdministration_.Role;

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
            _ = PingGridAsync(grid);
        }
        /*private static async Task PingGridAsync(DataGridView grid)
        {
            await Task.Run(() => Parallel.ForEach(grid.Rows.Cast<DataGridViewRow>(), async row =>
            {
                if (row.IsNewRow) return;

                // Читаем IP из cells[3] и сразу запускаем асинхронный пинг
                string? ip = null;
                grid.Invoke(() => ip = row.Cells[2].Value?.ToString()?.Trim());
                if (string.IsNullOrEmpty(ip)) return;

                string res = string.Empty;
                int ires = 0;
                try
                {
                    using var ping = new Ping();
                    var reply = await ping.SendPingAsync(ip, 1000);
                    res = reply.Status == IPStatus.Success ? $"Пингуется {reply.RoundtripTime}мс" : reply.Status.ToString();
                    ires = reply.Status == IPStatus.Success ? 2 : 1;
                }
                catch { res = "Сбой"; }

                // Записываем результат в последнюю ячейку
                grid.Invoke(() => row.Cells[row.Cells.Count - 1].Value = res);
                grid.Invoke(() => row.Cells[row.Cells.Count - 1].Style.BackColor = ires == 0 ? Color.Red : ires == 1 ? Color.Yellow : Color.Green);
            }));
        }*/
        /// <summary>
        /// 1. Метод для пинга ОДНОЙ конкретной строки (универсальный)
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private async Task PingRowAsync(DataGridViewRow row)
        {
            if (row.IsNewRow) return;

            // Читаем IP из cells[2] 
            string? ip = null;
            row.DataGridView?.Invoke(() => ip = row.Cells[2].Value?.ToString()?.Trim());
            if (string.IsNullOrEmpty(ip))
                return;

            string res;
            Color backColor = Color.Red; // По умолчанию Сбой/Ошибка

            try
            {
                using var ping = new Ping();
                var reply = await ping.SendPingAsync(ip, 1000);

                if (reply.Status == IPStatus.Success)
                {
                    if (_connectedClients.TryGetValue(ip, out StreamWriter? writer))
                    {
                        try
                        {
                            await writer.WriteLineAsync("NEED_MORE_INFO");
                            res = $"Пингуется {reply.RoundtripTime}мс\\Клиент активен";
                            backColor = Color.Green;
                        }
                        catch
                        {
                            res = "Сбой";
                        }
                    }
                    else
                    {
                        res = $"Пингуется {reply.RoundtripTime}мс\\Клиент не активен";
                        backColor = Color.Yellow;
                    }
                }
                else
                {
                    res = $"Нет связи: {reply.Status.ToString()}";
                }
            }
            catch
            {
                res = "Сбой";
            }

            // Записываем результат и цвет в UI-потоке
            UpdateUiLog(res, row.Index);
            /*row.DataGridView?.Invoke(() =>
            {
                var lastCell = row.Cells[row.Cells.Count - 1];
                lastCell.Value = res;
                lastCell.Style.BackColor = backColor;
            });*/
        }

        /// <summary>
        /// 2. Метод для параллельного пинга ВСЕХ строк таблицы
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private async Task PingGridAsync(DataGridView grid)
        {
            // Превращаем строки в массив, чтобы Parallel.ForEachAsync мог с ними работать
            var rows = grid.Rows.Cast<DataGridViewRow>().ToArray();

            // Фоновый поток + правильный асинхронный параллельный цикл
            await Task.Run(() => Parallel.ForEachAsync(rows, async (row, ct) =>
            {
                await PingRowAsync(row);
            }));
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
                    btn_remoteDesctop.Enabled = true;
                    btn_BData.Enabled = true;
                    btn_taskComplete.Enabled = true;
                    btn_taskSave.Enabled = true;
                    break;
                case Role.RoleType.Admin or Role.RoleType.MainAdmin:
                    btn_remoteDesctop.Enabled = true;
                    btn_BData.Enabled = true;
                    btn_Administ.Enabled = true;
                    btn_taskComplete.Enabled = true;
                    btn_taskSave.Enabled = true;
                    break;
                    /*case :
                        break;*/
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
            catch
            {

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
                        int rowIndex = -1;

                        // Безопасно ищем индекс строки с нужным IP в UI-потоке
                        grid.Invoke(() =>
                        {
                            foreach (DataGridViewRow row in grid.Rows)
                            {
                                if (row.IsNewRow) continue;

                                // Сравниваем IP из ячейки cells (индекс 2) с полученным clientIp
                                if (row.Cells[2].Value?.ToString()?.Trim() == clientIp)
                                {
                                    rowIndex = row.Index;
                                    break; // Строка найдена, выходим из цикла поиска
                                }
                            }
                        });

                        // Если строка найдена (rowIndex не равен -1), работаем с ней
                        if (rowIndex != -1)
                        {
                            UpdateUiLog(line, rowIndex);
                            // Здесь ваш код (например, обновить статус этой строки, зная её индекс)
                            // ЗАМЕНИТЬ НА КЕЙС С ОШИБКАМИ
                        }

                    }
                }
                finally
                {
                    // При отключении обязательно удаляем клиента из коллекции
                    _connectedClients.TryRemove(clientIp, out _);
                }
            }
        }
        private void UpdateUiLog(string message, int? id = null)
        {
            if (id is null)
            {
                MessageBox.Show(message, "UpdateUiLog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (grid.InvokeRequired)
                {
                    grid.Invoke(new Action(() => UpdateUiLog(message, id)));
                }
                else
                {
                    try
                    {
                        grid.Rows[id.Value].Cells[grid.ColumnCount - 1].Value = message;
                    }
                    catch { }
                }
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
        private void btn_pingToPC_Click(object sender, EventArgs e)
        {
            // Получаем IP-адрес из текстового поля на форме
            if (grid.CurrentRow is null)
                return;
            _ = PingRowAsync(grid.CurrentRow);
        }
        private void btn_taskSave_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectTask.SelectedValue is null or -1 || grid.CurrentRow is null || (int?)grid.CurrentRow.Cells[5].Value is 0 || userId is null)
                return;
            if (MessageBox.Show("Точно хотите принять задание?", "Тикеты", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                return;
            Sql.QueryNonReturns("UPDATE `Tickets` SET `user_id` = @user_id, " +
                "`status` = 'In_progress' WHERE `id` = @id",
                [new("@user_id", userId), new("@id", comboBoxSelectTask.SelectedValue)]);
            menuUpdate_Click(null, null);
        }
        private void btn_taskComplete_Click(object sender, EventArgs e)
        {
            if (new ToArchiveForm(Convert.ToInt32(grid.CurrentRow?.Cells[0].Value), userId).ShowDialog() != DialogResult.OK)
                return;
            MessageBox.Show("Данные по заданию сохранены!", "Тикеты", MessageBoxButtons.OK, MessageBoxIcon.Information);
            menuUpdate_Click(null, null);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // Ограничиваем минимальный размер формы, чтобы элементы не накладывались
            this.MinimumSize = new Size(800, 500);

            // 1. Вычисляем доступную ширину для нижних элементов
            int totalWidth = this.ClientSize.Width - 36; // 36 - это сумма отступов (12 слева, 12 справа, 12 между ними)
            int halfWidth = totalWidth / 2;

            // 2. Изменяем размеры и положение таблицы (Левая часть)
            grid.Width = halfWidth;
            grid.Height = this.ClientSize.Height - grid.Top - 12; // 12 - отступ снизу

            // 3. Изменяем положение элементов управления над правым полем
            int rightColumnLeft = grid.Left + halfWidth + 12; // Координата X для правой колонки

            label2.Left = rightColumnLeft;

            // Перемещаем комбобокс и его метку к правому краю
            label3.Left = this.ClientSize.Width - label3.Width - 12;
            comboBoxSelectTask.Left = this.ClientSize.Width - comboBoxSelectTask.Width - 12;

            // 4. Изменяем размеры и положение текстового поля (Правая часть)
            textBoxPCStatus.Left = rightColumnLeft;
            textBoxPCStatus.Width = this.ClientSize.Width - rightColumnLeft - 12;
            textBoxPCStatus.Height = grid.Height; // Высота такая же, как у таблицы
        }
    }
}
