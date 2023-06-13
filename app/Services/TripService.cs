using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;
using app.Services.Interfaces;

namespace app.Services;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;

    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }
    
    public async Task<IEnumerable<Trip>> GetAll()
    {
        return await _tripRepository.GetAll();
    }

    public async Task<IEnumerable<Trip>> GetAllForMonth(DateTime dateTime)
    {
        IEnumerable<Trip> data = await _tripRepository.GetAll();

        return data.Where(x => x.Startdate.Value.CompareTo(DateOnly.FromDateTime(dateTime)) > 0);
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