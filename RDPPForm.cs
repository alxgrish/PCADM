using System;
using System.Windows.Forms;
using RoyalApps.Community.Rdp.WinForms; // Для SensitiveString
using RoyalApps.Community.Rdp.WinForms.Configuration; // Для ResizeBehavior

namespace PCADM
{
    public partial class RDPPForm : System.Windows.Forms.Form
    {
        public RDPPForm()
        {
            InitializeComponent();
            this.Shown += RDPP_Shown;
        }

        private void RDPP_Shown(object sender, EventArgs e)
        {
            try
            {
               
                axMsRdpClient91.RdpConfiguration.Server = "127.0.0.1";
                axMsRdpClient91.RdpConfiguration.Port = 3389;
                
                axMsRdpClient91.RdpConfiguration.Credentials.Username = "ALX";
                axMsRdpClient91.RdpConfiguration.Credentials.Password = new SensitiveString("");

                axMsRdpClient91.RdpConfiguration.Display.ResizeBehavior = ResizeBehavior.SmartSizing;

                axMsRdpClient91.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации RDP: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                axMsRdpClient91.Disconnect();
            }
            catch { }
            base.OnFormClosing(e);
        }
    }
}
