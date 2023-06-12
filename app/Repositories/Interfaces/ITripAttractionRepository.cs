using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;

namespace app.Repositories.Interfaces;

public interface ITripAttractionRepository
{
    public Task<TripAttraction?> GetById(int id);
    public Task<IEnumerable<TripAttraction>> GetAllForAttractions(Attraction attraction);
    public Task<IEnumerable<TripAttraction>> GetAllForTrip(Trip trip);
    public Task<IEnumerable<TripAttraction>> GetAll();
    public TripAttraction Create(TripAttraction attraction);
    public TripAttraction Update(TripAttraction attraction);
    public TripAttraction Delete(TripAttraction attraction);
}