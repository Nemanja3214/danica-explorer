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

    public TripDetailsViewModel()
    {
    }
}


