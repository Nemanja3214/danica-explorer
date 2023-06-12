namespace app.Models;

public class Attraction : IsSightseeing
{
    public override string GetName()
    {
        return "Attraction" + base.GetName();
    }
}