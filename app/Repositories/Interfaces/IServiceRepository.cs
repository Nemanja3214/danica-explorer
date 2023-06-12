﻿using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;

namespace app.Repositories.Interfaces;

public interface IServiceRepository
{
    public Task<Service?> GetById(int id);
    public Task<IEnumerable<Service>> GetAll();
    public Service Create(Service service);
    public Service Update(Service service);
    public Service Delete(Service service);
}