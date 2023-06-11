using System;
using System.Collections.Generic;
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

    protected bool Equals(DragItem other)
    {
        return _name == other._name && _time.Equals(other._time);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((DragItem)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_name, _time.ToString());
    }
}