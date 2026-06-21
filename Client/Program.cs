using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System;
using System.Diagnostics;
using System.Threading;
namespace Client
{
    internal class Program
    {
        private const string ServerIp = "127.0.0.1";
        private const int ServerPort = 65432;
        static void Main(string[] args)
        {
            Console.WriteLine($"Клиент запущен. Отправка данных на {ServerIp}:{ServerPort}...");

            // Инициализация счетчиков для Windows
            using var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            using var memCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");

            // Первое чтение счетчика CPU часто возвращает 0, делаем холостой вызов
            cpuCounter.NextValue();

            while (true)
            {
                try
                {
                    // Собираем метрики
                    var status = new
                    {
                        hostname = Environment.MachineName,
                        cpu_usage = Math.Round(cpuCounter.NextValue(), 1),
                        ram_usage = Math.Round(memCounter.NextValue(), 1),
                        disk_usage = GetDiskUsage()
                    };

                    // Сериализация в JSON
                    string jsonString = JsonSerializer.Serialize(status);
                    byte[] data = Encoding.UTF8.GetBytes(jsonString);

                    // Отправка через TCP
                    using (TcpClient client = new TcpClient(ServerIp, ServerPort))
                    using (NetworkStream stream = client.GetStream())
                    {
                        stream.Write(data, 0, data.Length);
                        Console.WriteLine($"Данные отправлены: {jsonString}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка отправки: {ex.Message}");
                }

                Thread.Sleep(5000); // Интервал 5 секунд
            }
        }
        private static double GetDiskUsage()
        {
            try
            {
                var drive = new System.IO.DriveInfo("C");
                double total = drive.TotalSize;
                double used = total - drive.AvailableFreeSpace;
                return Math.Round((used / total) * 100, 1);
            }
            catch
            {
                return 0.0;
            }
        }
    }
}
