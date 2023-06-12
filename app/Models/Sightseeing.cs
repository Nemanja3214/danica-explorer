using System;
using ExCSS;
using Point = NetTopologySuite.Geometries.Point;

namespace app.Models;

public class Sightseeing
{
    protected string name;
    protected Time time;
    protected DateTime date;
    protected Point location;

    public Point Location
    {
        get => location;
        set => location = value;
    }

    public DateTimeOffset DateOffset
    {
        get => new DateTimeOffset(date);
    }

    public DateTime Date
    {
        get => date;
        set => date = value;
    }

    public Time Time
    {
        get => time;
        set => time = value;
    }

    public string Name
    {
        get => GetName();
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    protected bool Equals(Sightseeing other)
    {
        return name == other.name && time.Equals(other.time) && date.Equals(other.date);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Sightseeing)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(name, time, date);
    }

    public virtual string GetName()
    {
        return name;
    }
}