using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace app.Views;

public partial class AttractionCreateForm : UserControl
{
    public AttractionCreateForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}