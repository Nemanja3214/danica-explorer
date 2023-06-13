using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;

namespace app.Repositories.Interfaces;

public interface ILocationRepository
{
    public Task<IEnumerable<Location>> GetAll();

    public Task<Location> GetById(int id);
    
    public Location Create(Location location);
}