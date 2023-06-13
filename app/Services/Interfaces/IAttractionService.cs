using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;

namespace app.Services.Interfaces;

public interface IAttractionService 
{
    public Task<IEnumerable<Attraction>> GetAll();

    public Task<Attraction> GetById(int id);
    
    public Attraction Create(Attraction attraction);

    public Attraction Update(Attraction attraction);

    public Attraction Delete(Attraction attraction);
}