using Avalonia.Controls;

namespace app.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        new TripDetails().Show();
    }
}