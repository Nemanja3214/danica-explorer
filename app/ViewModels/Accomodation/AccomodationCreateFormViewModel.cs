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
using app.Model;
using app.Utils;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Metadata;
using Avalonia.Threading;
using ExCSS;
using ReactiveUI;

namespace app.ViewModels;

public class AccomodationCreateFormViewModel :BaseViewModel, INotifyPropertyChanged, IReactiveObject
{
    private int _ratingValue = 3;
    public event EventHandler LocationChanged;

    [Range(0, 5)]
    public int RatingValue
    {
        get => _ratingValue;
        set => this.RaiseAndSetIfChanged(ref _ratingValue, value);
    }

    private ObservableCollection<LocationDTO> _generatedCompletes;
    
    public ObservableCollection<LocationDTO>  GeneratedCompletes
    {
        get => _generatedCompletes;
        // check again
        set { this.RaiseAndSetIfChanged(ref _generatedCompletes, value); }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string _query = "Location";

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
    private readonly ReactiveCommand<EventArgs, Unit> _raiseRating;
    private readonly ReactiveCommand<EventArgs, Unit> _lowerRating;

    public LocationDTO SelectedLocation
    {
        get => _selectedLocation;
        set
        {
            _selectedLocation = value;
            LocationChanged?.Invoke(this, EventArgs.Empty); 
        }
    }


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

    public AccomodationCreateFormViewModel()
    {
        GeneratedCompletes = new ObservableCollection<LocationDTO>();
        _raiseRating = ReactiveCommand.Create<EventArgs>((e) =>
        {
            RatingValue++;
        });
        
        _lowerRating = ReactiveCommand.Create<EventArgs>((e) =>
        {
            RatingValue--;
        });
    }

    public ReactiveCommand<EventArgs, Unit> RaiseRating => _raiseRating;

    public ReactiveCommand<EventArgs, Unit> LowerRating => _lowerRating;
    public string Description { get; set; }
    public string Title { get; set; }
    
}