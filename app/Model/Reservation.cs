using System;
using System.Collections.Generic;

namespace app.Model;

public partial class Reservation
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }

    public int? UserId { get; set; }

    public int? TripId { get; set; }

    public bool? Isdeleted { get; set; }

    public virtual Trip? Trip { get; set; }

    public virtual User? User { get; set; }
}
