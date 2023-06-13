using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Repositories.Interfaces;

public interface ISearchRepository<T>
{
    public Task<IEnumerable<T>> Search(string input, bool isHotel = false);
}