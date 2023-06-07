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
    
    // the initial value is 2
    private int _RatingValue = 2;

    /// <summary>
    /// Gets or sets the current rating value. 
    /// It must be between 0 and 5
    /// </summary>
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
    public static Task<IEnumerable<object>> GetLocations(string query, CancellationToken token)
    {
        using (WebClient wc = new WebClient())
        {
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            wc.Headers.Add("Referer", "http://www.microsoft.com");
            return new Task<IEnumerable<object>>(() =>{
                var json = wc.DownloadData($"https://nominatim.openstreetmap.org/?q=subotica&format=json&limit=10&bounded=1&viewbox=18.471223,46.338158,23.682220,42.202836");
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<LocationDTO>));
                var rootObject = ser.ReadObject(new MemoryStream(json));
                try
                {
                    List<LocationDTO> locations = (List<LocationDTO>)rootObject;
                    return locations.Select(dto => dto.display_name).ToList();
                }
                catch(InvalidCastException e)
                {
                    return new List<String>();
                }
            });
        }
    }

    CancellationTokenSource source = new CancellationTokenSource();
    private CancellationToken token;
    private Task<List<String>> _generatedCompletes;
    
    public Task<List<String>>  GeneratedCompletes
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
            // GeneratedCompletes =  NominatimUtil.GetLocations(Query);

            this.RaisePropertyChanged("Query");
            
        }
    }

    private Func<string, CancellationToken, Task<IEnumerable<object>>> populator = GetLocations;
    public Func<string, CancellationToken, Task<IEnumerable<object>>> Populator
    {
        get => populator;
        set => populator = value;
    }



    public AccomodationCreateFormViewModel()
    {
        token = source.Token;
        _command = ReactiveCommand.Create(() => { RatingValue++; });
    }
    
}