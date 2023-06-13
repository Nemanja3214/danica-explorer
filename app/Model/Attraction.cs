using System;
using System.Collections.Generic;

namespace app.Model;

public partial class Attraction : ISigthSeeing
{
    public int Id { get; set; }

  

    public string? Description { get; set; }

    public byte[]? Image { get; set; }

    public int? LocationId { get; set; }

    public bool? Isdeleted { get; set; }



    public virtual ICollection<TripAttraction> TripAttractions { get; set; } = new List<TripAttraction>();
    
}
