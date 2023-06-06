using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace app.Views;

public partial class TripDetails : UserControl
{
    public TripDetails()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void InputElement_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}