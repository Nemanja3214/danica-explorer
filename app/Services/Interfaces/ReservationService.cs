using app.Model;
using app.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Services.Interfaces;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _repository;

    public ReservationService(IReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Reservation?> GetById(int id)
    {
        return await _repository.GetById(id);

    }

    public async Task<IEnumerable<Reservation>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<IEnumerable<Reservation>> GetAllForUser(User u)
    {
        return await _repository.GetAllForUser(u);
    }

    public async Task<IEnumerable<Reservation>> GetAllForTrip(Trip t)
    {
        return await _repository.GetAllForTrip(t);
    }

    public Reservation Create(Reservation reservation)
    {
        return _repository.Create(reservation);
    }

    public Reservation Update(Reservation reservation)
    {
        return _repository.Update(reservation);
    }

    public Reservation Delete(Reservation reservation)
    {
        return _repository.Delete(reservation);
    }
}