namespace Couiler.Exceptions;

public class NoCommandsRegisteredException : Exception
{
    /// <summary>
    /// Creates a new instance of <see cref="NoCommandsRegisteredException"/>
    /// </summary>
    public NoCommandsRegisteredException() :
        base("No registered commands found. Please make sure to register commands with the CommandAttribute")
    { }
}
