using app.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Repositories.Interfaces;

public interface IReservationRepository
{
    public Task<Reservation?> GetById(int id);
    public Task<IEnumerable<Reservation>> GetAll();
    public Reservation Create(Reservation reservation);
    public Reservation Update(Reservation reservation);
    public Reservation Delete(Reservation reservation);
}