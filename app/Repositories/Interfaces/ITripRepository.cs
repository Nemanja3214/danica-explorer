using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;

namespace app.Repositories.Interfaces;

public interface ITripRepository
{
    public Task<IEnumerable<Trip>> GetAll();

    public Task<IEnumerable<Trip>> GetAllForMonth(DateTime dateTime);

    public Task<Trip> GetById(int id);
    
    public Trip Create(Trip attraction);

    public Trip Update(Trip attraction);

    public Trip Delete(Trip attraction);

}