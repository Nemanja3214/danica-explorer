using System;
using ExCSS;
using Point = NetTopologySuite.Geometries.Point;

namespace app.Models;

public class Sightseeing
{
    protected string name;
    protected Point location;

    public Point Location
    {
        get => location;
        set => location = value;
    }

    public string Name
    {
        get => GetName();
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }


    protected bool Equals(Sightseeing other)
    {
        return name == other.name && location.Equals(other.location);
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
        return HashCode.Combine(name, location);
    }

    public virtual string GetName()
    {
        return name;
    }
}