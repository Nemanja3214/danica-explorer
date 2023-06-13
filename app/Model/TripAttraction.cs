using System;
using System.Collections.Generic;

namespace app.Model;

public partial class TripAttraction
{
    public TripAttraction(int? attractionId, int? tripId)
    {
        AttractionId = attractionId;
        TripId = tripId;
    }

    public int Id { get; set; }

    public int? AttractionId { get; set; }

    public int? TripId { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Attraction? Attraction { get; set; }

    public virtual Trip? Trip { get; set; }
}
