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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PCADM
{
    public partial class ToArchiveForm : Form
    {
        public ToArchiveForm(int? ticketId, int? userId)
        {
            InitializeComponent();
            this.ticketId = ticketId;
            textBoxMaster.Text = Sql.QueryOneReturn("select ConCat(`full_name`, '(', `login` ,')') from `User` where `id` = @id", [ new ("@id", userId) ])?.ToString();
            textBoxProblem.Text = Sql.QueryOneReturn("select concat(`type`, '(' , `code`, ')') from `Problem` where `id` = @id",
                [ new ("@id", Sql.QueryOneReturn("select `problem_id` from `Tickets` where `id` = @id",
                    [ new ("@id", ticketId) ] )) ])?.ToString();
            textBoxPC.Text = Sql.QueryOneReturn("select Concat(`pc_number`, '(', `cabinet_id`, ')', 'ip=(', `ip`, ')') from `PC` where `id` = @id",
                [ new("@id", Sql.QueryOneReturn("select `pc_id` from `Tickets` where `id` = @id", 
                    [new("@id", ticketId)])) ])?.ToString();
            comboBoxState.Items.AddRange(["Resolved", "In_progress", "Computing", "Not_resolved"]);
        }
        int? ticketId;
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxComment.Text))
            {
                MessageBox.Show("Поле комментария обязательно!", "Архивирование", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxComment.Focus();
                return;
            }
            Sql.QueryNonReturns("INSERT INTO Archive (master, problem_id, pc_id, status, " +
                "solution_and_info) VALUES (@master, @problem_id, @pc_id, @status, @solution_and_info)", 
                [
                    new ("@master", textBoxMaster.Text),
                    new ("@problem_id", Sql.QueryOneReturn("select `problem_id` from `Tickets` where `id` = @id", [ new("@id", ticketId) ])),
                    new ("@pc_id", Sql.QueryOneReturn("select `pc_id` from `Tickets` where `id` = @id", [ new("@id", ticketId) ])),
                    new ("@status", comboBoxState.Text),
                    new ("@solution_and_info", textBoxComment.Text),
                ]);
            Sql.QueryNonReturns("delete from `Tickets` where `id` = @id", [new("@id", ticketId)]);
        }
    }
}
