using System;

namespace app.Models;

public class Hotel : Sightseeing
{
    public override string GetName()
    {
        return "Hotel" + base.GetName();
    }
}