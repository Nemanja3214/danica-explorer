using System;

namespace app.Commands;

public class TripDetailsCommand : CommandBase
{
    //Implement redirection to details page
    public override void Execute(object? parameter)
    {
        Console.Out.WriteLine("Learn more");
    }
}