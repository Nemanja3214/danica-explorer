using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;

namespace app.ViewModels;

public class AccomodationCreateFormViewModel :ViewModelBase
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

    public AccomodationCreateFormViewModel()
    {
        _command = ReactiveCommand.Create(() => { RatingValue++; });
    }
}