using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Xamarin.Forms;

namespace app.Views;

public partial class AccomodationCreate : UserControl
{
    public AccomodationCreate()
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