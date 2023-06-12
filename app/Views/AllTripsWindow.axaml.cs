using System;
using System.ComponentModel;
using app.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace app.Views
{
    public partial class AllTripsWindow : UserControl
    {
        public AllTripsWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void showData(object? sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            UniformGrid grid = this.FindControl<UniformGrid>("Grid");
            AllTripsViewModel context = (AllTripsViewModel)DataContext;
            if (context != null && propertyChangedEventArgs.PropertyName.Equals(nameof(context.AllTrips)))
            {
                foreach (TripCard trip in context.AllTrips)
                {
                    grid.Children.Add(trip);
                }
            }
        }

        protected override void OnDataContextChanged(EventArgs e)
        {
            AllTripsViewModel context = (AllTripsViewModel)DataContext;
            if (context != null)
            {
                context.PropertyChanged += showData;
            }
        }

    }
}
