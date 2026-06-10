using MSTSCLib;
using RoyalApps.Community.Rdp;

namespace PCADM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RDPP rdp = new RDPP();
            rdp.ShowDialog();
        }
    }
}
