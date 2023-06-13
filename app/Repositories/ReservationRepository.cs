using app.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace app.Repositories;

public class ReservationRepository : IReservationRepository
{
    public DanicaExplorerContext _context;

    public ReservationRepository(DanicaExplorerContext context)
    {
        _context = context;
    }

    public async Task<Reservation?> GetById(int id)
    {
        return await _context.Reservations.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAll()
    {
        return await _context.Reservations
            .Include(x => x.Trip)
            .Include(x => x.User)
            .Include(x => x.Trip.TripServices)
            .Include(x => x.Trip.TripAttractions)
            .ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAllForUser(User u)
    {
        return await _context.Reservations
            .Include(x => x.Trip)
            .Include(x => x.User)
            .Include(x => x.Trip.TripServices)
            .Include(x => x.Trip.TripAttractions)
            .Where(x => x.UserId == u.Id)
            .ToListAsync();
    }

    public async Task<IEnumerable<Reservation>> GetAllForTrip(Trip t)
    {
        return await _context.Reservations
            .Include(x => x.Trip)
            .Include(x => x.User)
            .Include(x => x.Trip.TripServices)
            .Include(x => x.Trip.TripAttractions)
            .Where(x => x.TripId == t.Id)
            .ToListAsync();
    }

    public Reservation Create(Reservation reservation)
    {
        EntityEntry<Reservation> res = _context.Reservations.Add(reservation);
        _context.SaveChanges();
        return res.Entity;
    }

    public Reservation Update(Reservation reservation)
    {
        EntityEntry<Reservation> res = _context.Reservations.Attach(reservation);
        _context.SaveChanges();
        return res.Entity;
    }

    public Reservation Delete(Reservation reservation)
    {
        reservation.Isdeleted = true;
        return Update(reservation);
    }
}