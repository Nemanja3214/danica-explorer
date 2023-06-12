using app.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Services.Interfaces;

public interface ITripServiceService
{
    public Task<Model.TripService?> GetById(int id);
    public Task<IEnumerable<Service>> GetServicesForTrip(Trip trip);
    public Task<IEnumerable<Trip>> GetTripsForService(Service service);
    public Task<IEnumerable<Model.TripService>> GetAll();
    public Model.TripService Create(Model.TripService tripService);
    public Model.TripService Update(Model.TripService tripService);
    public Model.TripService Delete(Model.TripService tripService);
}