using Couiler;

namespace Basic;
public class CommandClass
{
    [Command("help")]
    public void PrintHelp(string[] args)
    {
        Console.WriteLine("Command List:");
        Console.WriteLine("Test - Prints hello world");
        Console.WriteLine("Echo - Requests input and prints it");
        Console.WriteLine("Help - Display this list");
    }
}
