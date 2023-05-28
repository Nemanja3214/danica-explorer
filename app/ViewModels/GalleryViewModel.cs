using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.OpenGL;

namespace app.ViewModels;

public class GalleryViewModel : ViewModelBase
{
    private readonly Command<string> _getNextCommand;
    private readonly Command<string> _getPreviousCommand;

    public GalleryViewModel()
    {
        _getNextCommand = new Command<string>(
            (s) => { Console.WriteLine("Next pozvan");}, 
            (s) => true 
        );
        
        _getPreviousCommand = new Command<string>(
            (s) => { Console.WriteLine("Previous pozvan");}, 
            (s) => true 
        );
    }

    public Command<string> GetNextCommand => _getNextCommand;

    public Command<string> GetPreviousCommand => _getPreviousCommand;
}