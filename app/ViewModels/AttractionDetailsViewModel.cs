using app.Views;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splat;

namespace app.ViewModels
{
    public class AttractionDetailsViewModel : BaseViewModel
    {
        public ObservableCollection<TripCard> AllTrips;

        private string _imageSource;
        public string ImageSource { get => _imageSource; set => _imageSource = value; }

        private string _attractionName;
        public string AttractionName { get => _attractionName; set => _attractionName = value; }

        private string _attractionLocation;
        public string AttractionLocation { get => _attractionLocation; set => _attractionLocation= value; }

        private string _attractionDescription;
        public string AttractionDescription { get => _attractionDescription; set => _attractionDescription= value; }

        public AttractionDetailsViewModel()
        {
            _imageSource = "../Assets/tripimage.jpeg";
            _attractionName = "Sagrada familija";
            _attractionLocation = "Negde u Barseloni";
            _attractionDescription =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis orci tortor, consectetur sed ipsum in, " +
                "blandit tempor nulla. Aenean non purus eros. Nunc at blandit erat. Donec a erat non nisi faucibus luctus. " +
                "Vivamus bibendum justo eu odio ultricies, eu ultrices risus mollis. Vestibulum ac orci at erat vestibulum " +
                "tincidunt sed a dui. Integer sed tortor lacus. Nullam lacinia augue in orci iaculis, a tincidunt tortor facilisis. " +
                "Fusce quis imperdiet erat. Integer gravida mattis fringilla. Pellentesque habitant morbi tristique senectus et netus et " +
                "malesuada fames ac turpis egestas. Etiam interdum velit mauris, eu vehicula lacus aliquam vel. Nunc interdum ultrices.";


            AllTrips = new ObservableCollection<TripCard>();
            for (int i = 0; i < 20; i++)
            {
                TripCardViewModel viewModel = Locator.Current.GetService<TripCardViewModel>();
                TripCard card = new TripCard();
                card.DataContext = viewModel;
                AllTrips.Add(card);
            }
        }
    }
}
