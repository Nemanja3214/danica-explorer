using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;
using app.Services.Interfaces;

namespace app.Services;

public class AttractionService : IAttractionService
{
    private readonly IAttractionRepository _attractionRepository;

    public AttractionService(IAttractionRepository attractionRepository)
    {
        _attractionRepository = attractionRepository;
    }

    public async Task<IEnumerable<Attraction>> GetAll()
    {
        return await _attractionRepository.GetAll();
    }

    public async Task<Attraction> GetById(int id)
    {
        return await _attractionRepository.GetById(id);
    }

    public Attraction Create(Attraction attraction)
    {
        return _attractionRepository.Create(attraction);
    }

    public Attraction Update(Attraction attraction)
    {
        return _attractionRepository.Update(attraction);
    }

    public Attraction Delete(Attraction attraction)
    {
        return _attractionRepository.Delete(attraction);
    }
}