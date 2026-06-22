using Microsoft.Maui.Controls;

namespace PCADM.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
}
