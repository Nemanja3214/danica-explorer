using System;
using System.Collections.Generic;
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
using ReactiveUI;

namespace app.ViewModels;

public class AccomodationCreateFormViewModel :ViewModelBase, INotifyPropertyChanged
{
    private int _RatingValue = 2;

    [Range(0, 5)]
    public int RatingValue
    {
        get { return _RatingValue; }
        set { this.RaiseAndSetIfChanged(ref _RatingValue, value); }
    }

    private ReactiveCommand<Unit, Unit> _command;

    public ReactiveCommand<Unit, Unit> Command
    {
        get => _command;
        set => _command = value ?? throw new ArgumentNullException(nameof(value));
    }

    CancellationTokenSource source = new CancellationTokenSource();
    private CancellationToken token;
    private IEnumerable<String> _generatedCompletes;
    
    public IEnumerable<String>  GeneratedCompletes
    {
        get => _generatedCompletes;
        set { this.RaiseAndSetIfChanged(ref _generatedCompletes, value); }
    }

    private string _query = "Location";

    public string Query
    {
        get => _query;
        set {
            _query = value;
            GeneratedCompletes =  NominatimUtil.GetLocations(Query);

            this.RaisePropertyChanged("Query");
            
        }
    }



    public AccomodationCreateFormViewModel()
    {
        token = source.Token;
        _command = ReactiveCommand.Create(() => { RatingValue++; });
    }
    
}