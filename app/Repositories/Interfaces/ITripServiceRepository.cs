﻿using app.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Repositories.Interfaces;

public interface ITripServiceRepository
{
    public Task<TripService?> GetById(int id);
    public Task<IEnumerable<TripService>> GetAllForTrip(Trip trip);
    public Task<IEnumerable<TripService>> GetHotelsForTrip(Trip trip);
    public Task<IEnumerable<TripService>> GetRestaurantsForTrip(Trip trip);
    public Task<IEnumerable<TripService>> GetAllForService(Service service);
    public Task<IEnumerable<TripService>> GetAll();
    public TripService Create(TripService service);
    public TripService Update(TripService service);
    public TripService Delete(TripService service);
}