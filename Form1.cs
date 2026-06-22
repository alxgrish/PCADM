using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder; // Используем новую библиотеку

namespace PCADM
{
    public partial class Qr : Form
    {
        public Qr(string Value)
        {
            InitializeComponent();

            // Запускаем генерацию при открытии формы
            GenerateQR(Value);
        }

        private void GenerateQR(string text)
        {
            try
            {
                if (string.IsNullOrEmpty(text)) return;

                // Создаем генератор QR-кода
                using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                {
                    // Создаем данные кода с максимальным уровнем кодирования (QRCodeGenerator.ECCLevel.Q)
                    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q))
                    {
                        // Создаем сам объект кода
                        using (QRCode qrCode = new QRCode(qrCodeData))
                        {
                            // Генерируем Bitmap. Число 20 — это размер пикселя (модуля) QR-кода
                            Bitmap qrCodeImage = qrCode.GetGraphic(20);

                            // Помещаем изображение в ваш элемент QrPB
                            QrPB.Image = qrCodeImage;

                            // Настраиваем режим отображения, чтобы картинка красиво вписывалась в размеры
                            QrPB.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации QR-кода: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
