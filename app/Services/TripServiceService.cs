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

    public async Task<TripService?> GetById(int id)
    {
        return await _repository.GetById(id);

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