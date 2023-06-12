using app.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System;
using System.ComponentModel;

namespace app.Views
{
    public partial class AttractionDetails : UserControl
    {
        public AttractionDetails()
        {
            InitializeComponent();
        }
        private void showData(object? sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            UniformGrid grid = this.FindControl<UniformGrid>("Grid");
            AttractionDetailsViewModel context = (AttractionDetailsViewModel)DataContext;
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
            AttractionDetailsViewModel context = (AttractionDetailsViewModel)DataContext;
            if (context != null)
            {
                context.PropertyChanged += showData;
            }
        }
    }
}
