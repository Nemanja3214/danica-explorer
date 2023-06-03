using System;
using System.Data.SqlTypes;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.OpenGL;
using ReactiveUI;

namespace app.ViewModels;

public class GalleryViewModel : ViewModelBase

{
    private readonly bool _canExecute = true; 
    private readonly ReactiveCommand<Unit, Unit> _getNextCommand = ReactiveCommand.Create(() => { Console.WriteLine("Next pozvan");});
    private readonly ReactiveCommand<Unit, Unit> _getPreviousCommand = ReactiveCommand.Create(() => { Console.WriteLine("Previous pozvan");});
    
    
    public GalleryViewModel()
    {
        IObservable<bool> canExecute =
            this.WhenAnyValue(vm => vm._canExecute);
        _getNextCommand = ReactiveCommand.Create(() => { Console.WriteLine("Next pozvan");}, canExecute);
        _getPreviousCommand = ReactiveCommand.Create(() => { Console.WriteLine("Previous pozvan");}, canExecute );
    }

    public ReactiveCommand<Unit, Unit> GetNextCommand => _getNextCommand;

    public ReactiveCommand<Unit, Unit> GetPreviousCommand => _getPreviousCommand;
}