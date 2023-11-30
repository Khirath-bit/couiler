# Couiler - argument to command mapper

[![.NET](https://github.com/Khirath-bit/couiler/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Khirath-bit/couiler/actions/workflows/dotnet.yml)

## Usage
```Easiest way is to checkout the example folder in the project files.```

Add the following NuGet via your packet manager: [NuGet](https://www.nuget.org/packages/Couiler)

Create a console program and adjust the program.cs to the following example:

```c#
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
}
```

The program has to derive from **CouilerProgram**, args have to be passed to **Args()** and from there you can add command methods anywhere in your project by adding the **Command** attribute to them. They have to accept the args parameter that contain the original program args.

**Important info:** This framework creates new instances of the surrounding class of each command method. If the method is static obviously no instance needs to be created and it will simply execute it. 