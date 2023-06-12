using app.Model;
using app.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Services.Interfaces;
using app.Models;

namespace app.Services;

public class TripServiceService : ITripServiceService
{
    private readonly ITripServiceRepository _repository;

    public TripServiceService(ITripServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<TripService?> GetById(int id)
    {
        return await _repository.GetById(id);

    }

    public async Task<IEnumerable<Service>> GetServicesForTrip(Trip trip)
    {
        IEnumerable<TripService> data = await _repository.GetAllForTrip(trip);
        List<Service> trips = new List<Service>();
        foreach (TripService ts in data)
        {
            if (ts.Service != null) trips.Add(ts.Service);
        }
        return trips;
    }

    public async Task<IEnumerable<Trip>> GetTripsForService(Service service)
    {
        IEnumerable<TripService> data = await _repository.GetAllForService(service);
        List<Trip> trips = new List<Trip>();
        foreach (TripService ts in data)
        {
            if (ts.Trip != null) trips.Add(ts.Trip);
        }
        return trips;
    }

    public async Task<IEnumerable<TripService>> GetAll()
    {
        return await _repository.GetAll();
    }

    public TripService Create(TripService tripService)
    {
        return _repository.Create(tripService);
    }

    public TripService Update(TripService tripService)
    {
        return _repository.Update(tripService);
    }

    public TripService Delete(TripService tripService)
    {
        return _repository.Delete(tripService);
    }
}