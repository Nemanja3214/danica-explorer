using app.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using System.ComponentModel;
using System;

namespace app.Views;

public partial class AllHotelsWindow : UserControl
{
    public AllHotelsWindow()
    {
        InitializeComponent();
    }

    private void showData(object? sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        UniformGrid grid = this.FindControl<UniformGrid>("Grid");
        grid.Children.Clear();
        AllHotelsViewModel context = (AllHotelsViewModel)DataContext;
        if (context != null && propertyChangedEventArgs.PropertyName.Equals(nameof(context.AllHotels)))
        {
            foreach (ServiceCard service in context.AllHotels)
            {
                grid.Children.Add(service);
            }
        }
    }

    protected override void OnDataContextChanged(EventArgs e)
    {
        AllHotelsViewModel context = (AllHotelsViewModel)DataContext;
        if (context != null)
        {
            context.PropertyChanged += showData;
        }
    }
}