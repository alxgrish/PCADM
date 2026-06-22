using Microsoft.Maui.Controls;
using MySqlConnector;
using System.Data;

namespace PCADM.Mobile;

public partial class BDataPage : ContentPage
{
    private string currentTable = string.Empty;

    public BDataPage()
    {
        InitializeComponent();
    }

    private void LoadTable(string table)
    {
        currentTable = table;
        var query = table switch
        {
            "Cabinet" => "SELECT id, CONCAT(floor, ' - ', name) AS display FROM Cabinet ORDER BY floor, name;",
            "PC" => "SELECT id, CONCAT(pc_number, ' | ', IFNULL(ip, 'нет IP')) AS display FROM PC ORDER BY pc_number;",
            "Problem" => "SELECT id, CONCAT(type, ' | ', code, ' | приоритет: ', priority) AS display FROM Problem ORDER BY priority;",
            "Archive" => "SELECT id, CONCAT('Запись #', id) AS display FROM Archive ORDER BY id;",
            _ => string.Empty
        };

        if (string.IsNullOrWhiteSpace(query))
            return;

        var tableData = SqlMobile.Query(query);
        RecordsCollection.ItemsSource = tableData?.Rows.Cast<DataRow>().Select(row => new
        {
            id = row["id"],
            display = row["display"]
        }).ToList();
    }

    private void Cabinets_Clicked(object sender, EventArgs e) => LoadTable("Cabinet");
    private void PCs_Clicked(object sender, EventArgs e) => LoadTable("PC");
    private void Problems_Clicked(object sender, EventArgs e) => LoadTable("Problem");
    private void Archive_Clicked(object sender, EventArgs e) => LoadTable("Archive");
    private void Refresh_Clicked(object sender, EventArgs e) => LoadTable(currentTable);
}
