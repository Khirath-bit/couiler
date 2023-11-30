namespace Couiler;

/// <summary>
/// Registers a method as command that can be executed
/// </summary>
[AttributeUsage(validOn: AttributeTargets.Method)]
public class CommandAttribute : Attribute
{
    /// <summary>
    /// Gets the name of this property
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Creates a new instance of <see cref="CommandAttribute"/>
    /// </summary>
    /// <param name="name">Name of the command</param>
    public CommandAttribute(string name) {
        Name = name;
    }
}
