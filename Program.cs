using PCAdministration_;

namespace PCADM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Sql.ConnectionStringBuilding.Database = "Answer_Book_problem";
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}