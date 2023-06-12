using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;

namespace app.Services.Interfaces;

public interface ITripAttractionService
{
    public Task<TripAttraction?> GetById(int id);
    public Task<IEnumerable<TripAttraction>> GetAll();
    public TripAttraction Create(TripAttraction tripAttraction);
    public TripAttraction Update(TripAttraction tripAttraction);
    public TripAttraction Delete(TripAttraction tripAttraction);
}