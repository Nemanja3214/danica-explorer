namespace app.Models;

public class Restaurant : Sightseeing
{
    public override string GetName()
    {
        return "Restaurant" + base.GetName();
    }
}