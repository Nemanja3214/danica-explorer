using System;
using System.Collections.Generic;

namespace app.Model;

public partial class Service : ISigthSeeing
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public byte[]? Image { get; set; }

    public int? LocationId { get; set; }

    public bool? Ishotel { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<TripService> TripServices { get; set; } = new List<TripService>();

    public override string GetName()
    {
        return Title;
    }

    public override Location GetLocation()
    {
        return Location;
    }
}
