using System;
using System.Collections.Generic;

namespace app.Model;

public partial class Location
{
    public int Id { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual ICollection<Attraction> Attractions { get; set; } = new List<Attraction>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
