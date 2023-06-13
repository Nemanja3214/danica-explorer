using app.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using System.ComponentModel;
using System;

namespace app.Views;

public partial class AllRestaurantsWindow : UserControl
{
    public AllRestaurantsWindow()
    {
        InitializeComponent();
    }

    private void showData(object? sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        UniformGrid grid = this.FindControl<UniformGrid>("Grid");
        grid.Children.Clear();
        AllRestaurantsViewModel context = (AllRestaurantsViewModel)DataContext;
        if (context != null && propertyChangedEventArgs.PropertyName.Equals(nameof(context.AllRestaurants)))
        {
            foreach (ServiceCard service in context.AllRestaurants)
            {
                grid.Children.Add(service);
            }
        }
    }

    protected override void OnDataContextChanged(EventArgs e)
    {
        AllRestaurantsViewModel context = (AllRestaurantsViewModel)DataContext;
        if (context != null)
        {
            context.PropertyChanged += showData;
        }
    }
}