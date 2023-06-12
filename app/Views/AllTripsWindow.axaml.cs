using System;
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

        protected override void OnDataContextChanged(EventArgs e)
        {
            UniformGrid grid = this.FindControl<UniformGrid>("Grid");
            AllTripsViewModel context = (AllTripsViewModel)DataContext;
            if (context != null)
            {
                foreach (TripCard trip in context.AllTrips)
                {
                    grid.Children.Add(trip);
                }
            }
        }

    }
}
