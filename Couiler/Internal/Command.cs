namespace Couiler.Internal;

public class Command
{
    private readonly string _name;
    private readonly Action<string[]> _associatedMethod;

    internal Command(string name, Action<string[]> associatedMethod)
    {
        _name = name;
        _associatedMethod = associatedMethod;
    }

    public bool NameMatches(string name) => name.Equals(_name);

    public void Execute(string[] args) => _associatedMethod(args);
}
