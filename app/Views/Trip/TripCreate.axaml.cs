using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace app.Views;

public partial class TripCreate : UserControl
{
    public TripCreate()
    {
        InitializeComponent();
        Focusable = true;
        AttachedToVisualTree += (s, e) => Focus();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}