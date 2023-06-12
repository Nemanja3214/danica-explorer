using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;

namespace app.Services.Interfaces;

public interface ITripAttractionService
{
    public Task<TripAttraction?> GetById(int id);
    public Task<IEnumerable<Attraction>> GetAttractionsForTrip(Trip trip);
    public Task<IEnumerable<Trip>> GetTripsForAttraction(Attraction attraction);
    public Task<IEnumerable<TripAttraction>> GetAll();
    public TripAttraction Create(TripAttraction tripAttraction);
    public TripAttraction Update(TripAttraction tripAttraction);
    public TripAttraction Delete(TripAttraction tripAttraction);
}