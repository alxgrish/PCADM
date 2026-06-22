using Microsoft.Maui.Controls;

namespace PCADM.Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Admin_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AdminPage));
    }

    private async void BData_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BDataPage));
    }

    private void RemoteDesktop_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("RDP", "RDP не поддерживается на мобильной версии.", "ОК");
    }
}
