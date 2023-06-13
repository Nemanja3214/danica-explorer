using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;

namespace app.Services.Interfaces;

public interface IServiceService
{
    //getByID, getAll, create, update, delete

    public Task<Service?> GetById(int id);
    public Task<IEnumerable<Service>> GetAll();
    public Task<IEnumerable<Service>> GetAllHotels();
    public Task<IEnumerable<Service>> GetAllRestaurants();
    public Service Create(Service service);
    public Service Update(Service service);
    public Service Delete(Service service);

}