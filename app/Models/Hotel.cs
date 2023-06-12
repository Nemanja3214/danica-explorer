using System;

namespace app.Models;

public class Hotel : IsSightseeing
{
    public override string GetName()
    {
        return "Hotel" + base.GetName();
    }
}