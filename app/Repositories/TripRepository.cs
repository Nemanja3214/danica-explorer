using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using app.Model;
using app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class TripRepository : ITripRepository
{
    private readonly DanicaExplorerContext _context;

    public TripRepository(DanicaExplorerContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Trip>> GetAll()
    {
        return await _context.Trips.ToListAsync();
    }

    public async Task<IEnumerable<Trip>> GetAllForMonth(DateTime dateTime)
    {
        DateOnly date = DateOnly.FromDateTime(dateTime);
        return await _context.Trips
            .Include(x => x.Reservations)
            .ToListAsync();
    }

    public async Task<Trip> GetById(int id)
    {
        return await _context.Trips.FindAsync(id);
    }

    public Trip Create(Trip trip)
    {
        Trip newTrip = _context.Trips.Add(trip).Entity;
        _context.SaveChanges();
        return newTrip;
    }

    public Trip Update(Trip trip)
    {
        EntityEntry<Trip> res = _context.Trips.Attach(trip);
        _context.SaveChanges();
        return res.Entity;
    }

    public Trip Delete(Trip trip)
    {
        trip.Isdeleted = true;
        return Update(trip);
    }
}