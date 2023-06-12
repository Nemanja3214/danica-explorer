﻿using System;
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
    
    public string SightName { get => Title; set => Title=value; }
    public Location SightLocation { get => Location; set => Location=value; }

}
