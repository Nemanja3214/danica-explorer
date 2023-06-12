namespace app.Models;

public class Restaurant : IsSightseeing
{
    public override string GetName()
    {
        return "Restaurant" + base.GetName();
    }
}