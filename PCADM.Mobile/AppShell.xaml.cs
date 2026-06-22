using Microsoft.Maui.Controls;

namespace PCADM.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(AdminPage), typeof(AdminPage));
        Routing.RegisterRoute(nameof(BDataPage), typeof(BDataPage));
        Routing.RegisterRoute(nameof(AddEditPage), typeof(AddEditPage));
    }
}
