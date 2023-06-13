using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Reactive;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using app.Utils;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Metadata;
using Avalonia.Threading;
using ExCSS;
using ReactiveUI;
using ReactiveValidation;
using ReactiveValidation.Extensions;

namespace app.ViewModels;

public class RestaurantCreateFormViewModel :BaseViewModel, INotifyPropertyChanged
{
    private int _RatingValue = 2;
    public event EventHandler LocationChanged;

    [Range(0, 5)]
    public int RatingValue
    {
        get { return _RatingValue; }
        set
        {
            _RatingValue = value;
            OnPropertyChanged(nameof(RatingValue));
        }
    }

    private ObservableCollection<LocationDTO> _generatedCompletes;
    
    public ObservableCollection<LocationDTO>  GeneratedCompletes
    {
        get => _generatedCompletes;
        // check again
        set
        {
            _generatedCompletes = value; 
            OnPropertyChanged(nameof(GeneratedCompletes));
        }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string _query = null;

    public string Query
    {
        get => _query;
        set {
            if (_query != value)
            {
                _query = value;
                OnPropertyChanged(nameof(Query));
                UpdateSuggestions();
            }
        }
    }

    private ReactiveCommand<Unit, Unit> _queryChangedCommand = ReactiveCommand.Create(() =>
    {
    
    });

    public ReactiveCommand<Unit, Unit> QueryChangedCommand
    {
        get => _queryChangedCommand;
        set => _queryChangedCommand = value ?? throw new ArgumentNullException(nameof(value));
    }

    private LocationDTO _selectedLocation;

    public LocationDTO SelectedLocation
    {
        get => _selectedLocation;
        set
        {
            if (value != null)
            {
                _selectedLocation = value;
                Query = _query;
                LocationChanged?.Invoke(this, EventArgs.Empty);
                IsButtonEnabled();
            }
        }
    }

    private string _restaurantName;
    public string RestaurantName
    {
        get => _restaurantName;
        set
        {
            _restaurantName = value;
            IsButtonEnabled();
            OnPropertyChanged(nameof(RestaurantName));
        }
    }

    public string Description { get; set; }


    private async void UpdateSuggestions()
    {
        List<LocationDTO> locations = await NominatimUtil.GetLocations(_query);

        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            GeneratedCompletes.Clear();
            foreach (var suggestion in locations)
            {
                GeneratedCompletes.Add(suggestion);
            }
        });
    }
    
    


    public RestaurantCreateFormViewModel()
    {
        GeneratedCompletes = new ObservableCollection<LocationDTO>();
        Validator = GetValidator();
    }

    private IObjectValidator GetValidator()
    {
        var builder = new ValidationBuilder<RestaurantCreateFormViewModel>();

        builder.RuleFor(vm => vm.RestaurantName)
            .NotEmpty()
            .WithMessage("Obavezno polje")
            .AllWhen(vm => vm.RestaurantName != null);

        //builder.RuleFor(vm => vm.Query)
        //    .Must(validLocation)
        //    .WithMessage("Obavezno polje")
        //    .AllWhen(vm => vm.SelectedLocation == null && vm.Query != null);

        return builder.Build(this);
    }

    private bool validLocation(string? query)
    {
        return SelectedLocation != null;
    }

    public bool ButtonEnabled { get; set; }

    public void IsButtonEnabled()
    {
        ButtonEnabled = RestaurantName != null && RestaurantName.Length > 0 && SelectedLocation != null;
        OnPropertyChanged(nameof(ButtonEnabled));
    }
}