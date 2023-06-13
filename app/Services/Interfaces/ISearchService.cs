namespace app.Services.Interfaces;

public interface ISearchService<T>
{
    public T Search(string input, bool isHotel = false);
}