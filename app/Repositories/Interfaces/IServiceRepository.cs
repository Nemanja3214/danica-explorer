﻿using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;

namespace app.Repositories.Interfaces;

public interface IServiceRepository : ISearchRepository<Service>
{
    public Task<Service?> GetById(int id);
    public Task<IEnumerable<Service>> GetAll();
    public Task<IEnumerable<Service>> GetAllHotels();
    public Task<IEnumerable<Service>> GetAllRestaurants();
    public Service Create(Service service);
    public Service Update(Service service);
    public Service Delete(Service service);
}