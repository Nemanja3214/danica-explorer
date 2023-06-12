using System;
using System.Threading.Tasks;
using app.Model;
using app.Repositories.Interfaces;
using app.Services.Interfaces;

namespace app.Services;

public class LocationService : ILocationService
{   
    private readonly ILocationRepository _locationRepository;

    public LocationService(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<Location> GetById(int id)
    {
        Location location = await _locationRepository.GetById(id);
        if (location == null)
        {
            throw new InvalidOperationException("Location not found");
        }

        return location;
    }

    public Location Create(Location location)
    {
        return _locationRepository.Create(location);
    }
}