using System;
using System.ComponentModel;
using app.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;

namespace app.Views
{
    public partial class AllAttractionsWindow : UserControl
    {
        public AllAttractionsWindow()
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
            grid.Children.Clear();
            AllAttractionsViewModel context = (AllAttractionsViewModel)DataContext;
            if (context != null && propertyChangedEventArgs.PropertyName.Equals(nameof(context.AllAttractions)))
            {
                foreach (AttractionCard attraction in context.AllAttractions)
                {
                    grid.Children.Add(attraction);
                }
            }
        }

        protected override void OnDataContextChanged(EventArgs e)
        {
            AllAttractionsViewModel context = (AllAttractionsViewModel)DataContext;
            if (context != null)
            {
                context.PropertyChanged += showData;
            }
        }

    }
}
