using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace app.Views;

public partial class DayPlan : UserControl
{
    public DayPlan()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}