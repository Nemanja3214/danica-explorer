using System.Collections.Generic;
using System.Threading.Tasks;

namespace app.Services.Interfaces;

public interface ISearchService<T>
{
    public Task<IEnumerable<T>> Search(string input, bool isHotel = false);
}