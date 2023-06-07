using System;
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

        protected override void OnDataContextChanged(EventArgs e)
        {
            UniformGrid grid = this.FindControl<UniformGrid>("Grid");
            AllAttractionsViewModel context = (AllAttractionsViewModel)DataContext;
            foreach (AttractionCard attraction in context.AllAttractions)
            {
                grid.Children.Add(attraction);
            }
        }

    }
}
