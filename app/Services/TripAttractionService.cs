using app.Repositories.Interfaces;
using app.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;

namespace app.Services;

public class TripAttractionService : ITripAttractionService
{
    private readonly ITripAttractionRepository _repository;

    public TripAttractionService(ITripAttractionRepository repository)
    {
        _repository = repository;
    }

    public async Task<TripAttraction?> GetById(int id)
    {
        return await _repository.GetById(id);

    }

    public async Task<IEnumerable<TripAttraction>> GetAll()
    {
        return await _repository.GetAll();
    }

    public TripAttraction Create(TripAttraction tripAttraction)
    {
        return _repository.Create(tripAttraction);
    }

    public TripAttraction Update(TripAttraction tripAttraction)
    {
        return _repository.Update(tripAttraction);
    }

    public TripAttraction Delete(TripAttraction tripAttraction)
    {
        return _repository.Delete(tripAttraction);
    }
}