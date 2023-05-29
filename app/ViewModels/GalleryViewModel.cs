using System;
using System.Reactive;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.OpenGL;
using ReactiveUI;

namespace app.ViewModels;

public class GalleryViewModel : ViewModelBase
{
    private readonly ReactiveCommand<Unit, Unit> _getNextCommand;
    private readonly ReactiveCommand<Unit, Unit> _getPreviousCommand;

    public GalleryViewModel()
    {
        _getNextCommand = ReactiveCommand.Create(() => { Console.WriteLine("Next pozvan");} );
        _getPreviousCommand = ReactiveCommand.Create(() => { Console.WriteLine("Previous pozvan");} );
    }

    public ReactiveCommand<Unit, Unit> GetNextCommand => _getNextCommand;

    public ReactiveCommand<Unit, Unit> GetPreviousCommand => _getPreviousCommand;
}