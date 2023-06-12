using System;

namespace app.Commands;

public class BookCommand : CommandBase
{
    //Implement booking dialog
    public override void Execute(object? parameter)
    {
        Console.Out.WriteLine("Booked");
    }
}