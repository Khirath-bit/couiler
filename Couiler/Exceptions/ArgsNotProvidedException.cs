namespace Couiler.Exceptions;

public class ArgsNotProvidedException : Exception
{
    /// <summary>
    /// Creates a new instance of <see cref="ArgsNotProvidedException"/>
    /// </summary>
    public ArgsNotProvidedException() :
        base("No arguments provided to the Args method. Please call the Args Method before executing commands") { }
}
