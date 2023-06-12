using app.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Services.Interfaces;

public interface ITripServiceService
{
    public Task<TripService?> GetById(int id);
    public Task<IEnumerable<Service>> GetServicesForTrip(Trip trip);
    public Task<IEnumerable<Trip>> GetTripsForService(Service service);
    public Task<IEnumerable<TripService>> GetAll();
    public TripService Create(TripService tripService);
    public TripService Update(TripService tripService);
    public TripService Delete(TripService tripService);
}