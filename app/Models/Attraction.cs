namespace app.Models;

public class Attraction : Sightseeing
{
    public override string GetName()
    {
        return "Attraction" + base.GetName();
    }
}