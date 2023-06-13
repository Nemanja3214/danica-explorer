using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace app.Views;

public partial class LandingPage : UserControl
{
    public LandingPage()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}