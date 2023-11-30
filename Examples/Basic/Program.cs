using Couiler;

namespace Basic;

internal class Program : CouilerProgram
{
    static void Main(string[] args)
    {
        Args(args);
    }

    [Command("Test")]
    public void Test(string[] args)
    {
        Console.WriteLine("Hello World");
    }

    [Command("Echo")]
    public void Echo(string[] args)
    {
        Console.Write("> Input: ");
        Console.WriteLine("> Echo: " + Console.ReadLine());
    }
}
