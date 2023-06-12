using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;
using app.Services.Interfaces;

namespace app.Services;

public class TripService : ITripService
{
    private readonly ITripService _tripRepository;

    public TripService(ITripService tripRepository)
    {
        _tripRepository = tripRepository;
    }
    
    public async Task<IEnumerable<Trip>> GetAll()
    {
        return await _tripRepository.GetAll();
    }

    public async Task<Trip> GetById(int id)
    {
        return await _tripRepository.GetById(id);
    }

    public Trip Create(Trip trip)
    {
        return _tripRepository.Create(trip);
    }

    public Trip Update(Trip trip)
    {
        return _tripRepository.Update(trip);
    }

    public Trip Delete(Trip trip)
    {
        return _tripRepository.Delete(trip);
    }
}