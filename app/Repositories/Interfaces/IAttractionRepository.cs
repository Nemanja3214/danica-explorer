using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;

namespace app.Repositories.Interfaces;

public interface IAttractionRepository : ISearchRepository<Attraction>
{
    public Task<IEnumerable<Attraction>> GetAll();

    public Task<Attraction?> GetById(int id);
    
    public Attraction Create(Attraction attraction);

    public Attraction Update(Attraction attraction);

    public Attraction Delete(Attraction attraction);

}