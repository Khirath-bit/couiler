using Couiler.Exceptions;
using System.Text;

namespace Couiler.Internal;

public class CommandHandler
{
    private readonly List<Command> _commands;

    /// <summary>
    /// Creates a new instance of <see cref="CommandHandler"/>
    /// </summary>
    /// <param name="commands"></param>
    internal CommandHandler(List<Command> commands)
    {
        _commands = commands;
    }

    /// <summary>
    /// Executes commands registered in here
    /// </summary>
    /// <param name="args">Arguments to pass to the command methods</param>
    /// <exception cref="ArgsNotProvidedException">Thrown if no arguments were passed</exception>
    public void Execute(string[]? args)
    {
        if (args == null)
            throw new ArgsNotProvidedException();

        var builder = new StringBuilder();

        foreach (var s in args)
        {
            if(builder.Length > 0)
                builder.Append(" ");

            builder.Append(s);

            var cmd = _commands.FirstOrDefault(f => f.NameMatches(builder.ToString()));

            if (cmd == null)
                continue;

            cmd.Execute(args);
            return;
        }
    }
}
