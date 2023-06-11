using System;
using ExCSS;

namespace app.Models;

public class Sightseeing
{
    protected string name;
    protected DateTime time;

    public DateTime Time
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
        return name == other.name && time.Equals(other.time);
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
        return HashCode.Combine(name, time.ToString());
    }

    public virtual string GetName()
    {
        return name;
    }
}