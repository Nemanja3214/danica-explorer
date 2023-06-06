using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Input.GestureRecognizers;
using Avalonia.Interactivity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;
using Svg;

namespace app.ViewModels;

public class TripDetailsViewModel
{
    private bool _mapHovered = false;
    public bool MapNotHovered
    {
        get => !_mapHovered;
    }

    private ReactiveCommand<ScrollChangedEventArgs, Unit> _scrollCommand;

    public TripDetailsViewModel()
    {
        Gvm = new GalleryViewModel();
        _scrollCommand = ReactiveCommand.Create<ScrollChangedEventArgs>(e =>
        {
            if (_mapHovered)
                e.Handled = true;
        }, this.WhenAnyValue(x => x._mapHovered).Select(mapHovered => !mapHovered));
    }

    public ReactiveCommand<ScrollChangedEventArgs, Unit> ScrollCommand
    {
        get => _scrollCommand;
        set => _scrollCommand = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    

    public GalleryViewModel Gvm { get; set; }
}

public class ScrolledBehaviour : AvaloniaObject
{

    static ScrolledBehaviour()
    {
        
        CommandProperty.Changed.Subscribe(x => HandleCommandChanged(x.Sender, x.NewValue.GetValueOrDefault<ICommand>()));
    }
    
    public static readonly AttachedProperty<ICommand> CommandProperty = AvaloniaProperty.RegisterAttached<ScrolledBehaviour, Interactive, ICommand>(
        "Command", default(ICommand), false, BindingMode.OneTime);
    
    public static readonly AttachedProperty<object> CommandParameterProperty = AvaloniaProperty.RegisterAttached<ScrolledBehaviour, Interactive, object>(
        "CommandParameter", default(object), false, BindingMode.OneWay, null);
    

    private static void HandleCommandChanged(IAvaloniaObject element, ICommand commandValue)
    {
        if (element is InputElement interactElem)
        {
            interactElem.RemoveHandler(ScrollViewer.ScrollChangedEvent, Handler);
            if (commandValue != null)
            {
                interactElem.AddHandler(ScrollViewer.ScrollChangedEvent, Handler);
            }
            else
            {
                interactElem.RemoveHandler(ScrollViewer.ScrollChangedEvent, Handler);
            }
        }

        static void Handler(object s, ScrollChangedEventArgs e)
        {
            if (s is ScrollViewer interactElem)
            {
                object commandParameter = interactElem.GetValue(CommandParameterProperty);
                ICommand commandValue = interactElem.GetValue(CommandProperty);
                if (commandValue?.CanExecute(e) == true)
                {
                    commandValue.Execute(e);
                }
            }
        }
    }
    public static void SetCommand(AvaloniaObject element, ICommand commandValue)
    {
        element.SetValue(CommandProperty, commandValue);
    }
    
    public static ICommand GetCommand(AvaloniaObject element)
    {
        return element.GetValue(CommandProperty);
    }
    
    public static void SetCommandParameter(AvaloniaObject element, object parameter)
    {
        element.SetValue(CommandParameterProperty, parameter);
    }
    
    public static object GetCommandParameter(AvaloniaObject element)
    {
        return element.GetValue(CommandParameterProperty);
    }
}