using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;
using app.Services.Interfaces;

namespace app.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _repository;

    public ServiceService(IServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Service?> GetById(int id)
    {
        return await _repository.GetById(id);

    }

    public async Task<IEnumerable<Service>> GetAll()
    {
        return await _repository.GetAll();
    }

    public Service Create(Service service)
    {
        return _repository.Create(service);
    }

    public Service Update(Service service)
    {
        return _repository.Update(service);
    }

    public Service Delete(Service service)
    {
        return _repository.Delete(service);
    }

    public async Task<IEnumerable<Service>> Search(string input, bool isHotel = true)
    {
        return await _repository.Search(input, isHotel);
    }
}