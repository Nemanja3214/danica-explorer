using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;
using Microsoft.EntityFrameworkCore;

namespace app.Services.Interfaces;

public interface ITripService
{
    public Task<IEnumerable<Trip>> GetAll();

    public Task<List<Trip>> GetAllForMonth(DateTime dateTime, DanicaExplorerContext dbContext);

    public Task<Trip> GetById(int id);
    
    public Trip Create(Trip attraction);

    public Trip Update(Trip attraction);

    public Trip Delete(Trip attraction);
}