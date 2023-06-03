using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;

namespace app.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif  
    }
    

}
