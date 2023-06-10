using app.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System;

namespace app.Views
{
    public partial class AttractionDetails : UserControl
    {
        public AttractionDetails()
        {
            InitializeComponent();
        }

        protected override void OnDataContextChanged(EventArgs e)
        {
            UniformGrid grid = this.FindControl<UniformGrid>("Grid");
            AttractionDetailsViewModel context = (AttractionDetailsViewModel)DataContext;
            foreach (TripCard trip in context.AllTrips)
            {
                grid.Children.Add(trip);
            }
        }
    }
}
