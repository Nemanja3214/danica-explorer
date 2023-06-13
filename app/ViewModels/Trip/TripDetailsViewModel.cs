using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using app.Model;
using app.Services.Interfaces;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Input.GestureRecognizers;
using Avalonia.Interactivity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;
using Splat;

namespace app.ViewModels;

public class TripDetailsViewModel : BaseViewModel
{
    private bool _mapHovered = false;

    public bool MapHovered
    {
        get => _mapHovered;
        set => _mapHovered = value;
    }

    public bool MapNotHovered
    {
        get => !_mapHovered;
    }

    private ObservableCollection<TripDetailsItemViewModel> _hotels;

    public ObservableCollection<TripDetailsItemViewModel> Hotels
    {
        get => _hotels;
        set => _hotels = value;
    }

    private ObservableCollection<TripDetailsItemViewModel> _restaurants;

    public ObservableCollection<TripDetailsItemViewModel> Restaurants
    {
        get => _restaurants;
        set => _restaurants = value;
    }

    private ObservableCollection<TripDetailsItemViewModel> _attractions;

    public ObservableCollection<TripDetailsItemViewModel> Attractions
    {
        get => _attractions;
        set => _attractions = value;
    }

    public TripDetailsViewModel()
    {
    }

    public TripDetailsViewModel(Trip t)
    {
        _restaurants = new ObservableCollection<TripDetailsItemViewModel>();
        _hotels = new ObservableCollection<TripDetailsItemViewModel>();
        _attractions = new ObservableCollection<TripDetailsItemViewModel>();
        SelectedTrip = t;
        Price = "Cena: " + t.Price + " din";
        Date = "Datum: " + t.Startdate.Value.ToString("dd.MM.yyyy.");
        Duration = "Trajanje: " + t.Durationindays + " dana";
        FillData();
    }

    public string Duration { get; set; }

    public string Date { get; set; }

    public string Price { get; set; }

    private async void FillData()
    {
        IEnumerable<Service> services = await Locator.Current.GetService<ITripServiceService>().GetServicesForTrip(SelectedTrip);
        foreach (var service in services)
        {
            if (service.Ishotel == true)
            {
                _hotels.Add(new TripDetailsItemViewModel(service));
            }
            else
            {
                _restaurants.Add(new TripDetailsItemViewModel(service));
            }
        }

        IEnumerable<Attraction> attractions = await Locator.Current.GetService<ITripAttractionService>().GetAttractionsForTrip(SelectedTrip);

        foreach (var attraction in attractions)
        {
            _attractions.Add(new TripDetailsItemViewModel(attraction));
        }
    }

    public Trip SelectedTrip { get; set; }
}


