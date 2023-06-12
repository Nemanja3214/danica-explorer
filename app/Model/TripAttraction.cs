using System;
using System.Collections.Generic;

namespace app.Model;

public partial class TripAttraction
{
    public int Id { get; set; }

    public int? AttractionId { get; set; }

    public int? TripId { get; set; }

    public virtual Attraction? Attraction { get; set; }

    public virtual Trip? Trip { get; set; }
}
