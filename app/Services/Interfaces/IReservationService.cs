﻿using app.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Services.Interfaces;

public interface IReservationService
{
    public Task<Reservation?> GetById(int id);
    public Task<IEnumerable<Reservation>> GetAll();
    public Reservation Create(Reservation reservation);
    public Reservation Update(Reservation reservation);
    public Reservation Delete(Reservation reservation);
}