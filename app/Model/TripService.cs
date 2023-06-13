using System;
using System.Collections.Generic;

namespace app.Model;

public partial class TripService
{
    public TripService(int? serviceId, int? tripId)
    {
        ServiceId = serviceId;
        TripId = tripId;
    }

    public int Id { get; set; }

    public int? ServiceId { get; set; }

    public int? TripId { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Service? Service { get; set; }

    public virtual Trip? Trip { get; set; }
}
