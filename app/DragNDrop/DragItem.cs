using System;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using ReactiveUI;

namespace app.Models;

public class DragItem
{
    private string _name;
    private DateTime _time;
    
    public string Name
    {
        get => _name;
        set => _name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public DateTime Time
    {
        get => _time;
        set => _time = value;
    }


}