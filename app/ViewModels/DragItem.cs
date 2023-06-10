using System;

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