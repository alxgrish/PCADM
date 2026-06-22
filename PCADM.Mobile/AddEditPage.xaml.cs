using Microsoft.Maui.Controls;
using MySqlConnector;

namespace PCADM.Mobile;

public partial class AddEditPage : ContentPage
{
    public AddEditPage()
    {
        InitializeComponent();
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(FullNameEntry.Text) ||
            string.IsNullOrWhiteSpace(LoginEntry.Text) ||
            string.IsNullOrWhiteSpace(PasswordEntry.Text) ||
            RolePicker.SelectedItem == null)
        {
            await DisplayAlert("Ошибка", "Заполните все обязательные поля.", "ОК");
            return;
        }

        var query = "INSERT INTO `User` (full_name, login, password, role) VALUES (@full_name, @login, @password, @role);";
        var parameters = new[]
        {
            new MySqlParameter("@full_name", FullNameEntry.Text.Trim()),
            new MySqlParameter("@login", LoginEntry.Text.Trim()),
            new MySqlParameter("@password", PasswordEntry.Text.Trim()),
            new MySqlParameter("@role", RolePicker.SelectedItem.ToString())
        };

        var success = SqlMobile.QueryNonReturns(query, parameters);
        if (!success)
        {
            await DisplayAlert("Ошибка", "Не удалось сохранить пользователя.", "ОК");
            return;
        }

        await DisplayAlert("Готово", "Пользователь сохранён.", "ОК");
        await Shell.Current.GoToAsync("..", true);
    }
}
