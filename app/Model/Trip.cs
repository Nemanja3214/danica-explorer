using System;
using System.Collections.Generic;

namespace app.Model;

public partial class Trip
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateOnly Startdate { get; set; }

    public int? Durationindays { get; set; }

    public double? Price { get; set; }

    public byte[]? Image { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<TripAttraction> TripAttractions { get; set; } = new List<TripAttraction>();

    public virtual ICollection<TripService> TripServices { get; set; } = new List<TripService>();

    public override string ToString()
    {
        return Title;
    }
}
