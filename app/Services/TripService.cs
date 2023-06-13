using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;
using app.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace app.Services;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;

    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }
    
    public async Task<IEnumerable<Trip>> GetAll()
    {
        return await _tripRepository.GetAll();
    }

    public async Task<List<Trip>> GetAllForMonth(DateTime dateTime, DanicaExplorerContext dbContext)
    {
        IEnumerable<Trip> data =  await dbContext.Trips.Include(x=>x.Reservations).ToListAsync();
        List<Trip> dataList = data.ToList();
        List<Trip> trips = new();

        DateOnly dateTimeOnly = new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day);
        
        foreach (Trip trip in dataList)
        {
            DateOnly tripTime = trip.Startdate;
            bool isSameMonth = (dateTimeOnly.Month == tripTime.Month) && (dateTimeOnly.Year == tripTime.Year);
            if (isSameMonth)
            {
                trips.Add(trip);
            }
        }
        return trips;
    }

    public async Task<Trip> GetById(int id)
    {
        return await _tripRepository.GetById(id);
    }

    public Trip Create(Trip trip)
    {
        return _tripRepository.Create(trip);
    }

    public Trip Update(Trip trip)
    {
        return _tripRepository.Update(trip);
    }

    public Trip Delete(Trip trip)
    {
        return _tripRepository.Delete(trip);
    }
}