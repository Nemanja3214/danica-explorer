using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;
using app.Services.Interfaces;
using BruTile.Wms;

namespace app.Services;

public class UserService : IUserService
{
    
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetById(int id)
    {
        User user = await _userRepository.GetById(id);
        if (user == null)
        {
            throw new InvalidOperationException("User not found!");
        }

        return user;
    }

    public async Task<User> Login(string email, string password)
    {
        User user = await _userRepository.GetByEmail(email);
        if (user == null || user.Password != password)
        {
            throw new InvalidOperationException("Invalid username or password!");
        }
        return user;
    }

    public async Task<User> Register(User user)
    {
        User existingUser = await _userRepository.GetByEmail(user.Email);
        if (existingUser != null)
        {
            throw new InvalidOperationException("A user with the same email already exists.");
        }
        User createdUser = _userRepository.Create(user);
        return createdUser;
    }

    public async Task<IEnumerable<Reservation>> GetAllReservations(User user)
    {
        return await _userRepository.GetAllReservations(user);
    }
}