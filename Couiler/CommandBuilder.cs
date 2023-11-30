using Couiler.Internal;

namespace Couiler;

public class CommandBuilder
{
    private readonly List<Command> _commands = new (50);

    public static CommandBuilder Create => new CommandBuilder();

    public CommandBuilder AddCommand(Command command)
    {
        _commands.Add(command);
        return this;
    }

    public CommandBuilder AddCommand(string name, Action<string[]> associatedMethod)
    {
        _commands.Add(new Command(name, associatedMethod));
        return this;
    }

    public CommandHandler Build()
    {
        return new CommandHandler(_commands);
    }
}
