using app.Model;
using app.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Services.Interfaces;

namespace app.Services;

public class TripServiceService : ITripServiceService
{
    private readonly ITripServiceRepository _repository;

    public TripServiceService(ITripServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Model.TripService?> GetById(int id)
    {
        return await _repository.GetById(id);

    }

    public async Task<IEnumerable<Service>> GetServicesForTrip(Trip trip)
    {
        IEnumerable<Model.TripService> data = await _repository.GetAllForTrip(trip);
        List<Service> services = new List<Service>();
        foreach (Model.TripService ts in data)
        {
            if (ts.Service != null) services.Add(ts.Service);
        }
        return services;
    }

    public async Task<IEnumerable<Trip>> GetTripsForService(Service service)
    {
        IEnumerable<Model.TripService> data = await _repository.GetAllForService(service);
        List<Trip> trips = new List<Trip>();
        foreach (Model.TripService ts in data)
        {
            if (ts.Trip != null) trips.Add(ts.Trip);
        }
        return trips;
    }

    public async Task<IEnumerable<Model.TripService>> GetAll()
    {
        return await _repository.GetAll();
    }

    public Model.TripService Create(Model.TripService tripService)
    {
        return _repository.Create(tripService);
    }

    public Model.TripService Update(Model.TripService tripService)
    {
        return _repository.Update(tripService);
    }

    public Model.TripService Delete(Model.TripService tripService)
    {
        return _repository.Delete(tripService);
    }
}