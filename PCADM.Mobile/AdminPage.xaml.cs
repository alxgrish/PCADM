using Microsoft.Maui.Controls;
using MySqlConnector;
using System.Data;

namespace PCADM.Mobile;

public partial class AdminPage : ContentPage
{
    public AdminPage()
    {
        InitializeComponent();
        LoadUsers();
    }

    private void LoadUsers()
    {
        var query = "SELECT `User`.`id`, `full_name`, `login`, `role`, CONCAT(`Cabinet`.`name`, '-', `Cabinet`.`floor`) AS `cabinet` " +
                    "FROM `User` LEFT JOIN `Cabinet` ON `User`.`linked_cabinet_id` = `Cabinet`.`id` ORDER BY `User`.`id`;";
        var table = SqlMobile.Query(query);
        UsersCollection.ItemsSource = table?.Rows.Cast<DataRow>().Select(row => new
        {
            id = row["id"],
            full_name = row["full_name"],
            login = row["login"],
            role = row["role"],
            cabinet = row["cabinet"]
        }).ToList();
    }

    private void UsersCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // selection currently not used
    }

    private async void AddUser_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddEditPage));
    }

    private void Refresh_Clicked(object sender, EventArgs e)
    {
        LoadUsers();
    }
}
