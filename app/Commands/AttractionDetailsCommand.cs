using System;

namespace app.Commands;

public class AttractionDetailsCommand : CommandBase
{

    // Implement redirection
    public override void Execute(object? parameter)
    {
        Console.Out.WriteLine("Learn more");
    }
}