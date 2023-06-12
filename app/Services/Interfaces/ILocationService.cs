using System.Threading.Tasks;
using app.Model;

namespace app.Services.Interfaces;

public interface ILocationService
{
    public  Task<Location> GetById(int id);
    public  Location Create(Location location);
}