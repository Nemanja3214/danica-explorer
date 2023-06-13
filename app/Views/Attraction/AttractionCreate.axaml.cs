using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace app.Views;

public partial class AttractionCreate : UserControl
{
    public AttractionCreate()
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