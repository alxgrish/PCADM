using MSTSCLib;
using PCAdministration_;
using RoyalApps.Community.Rdp;

namespace PCADM
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

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

    }
}
