using Couiler.Exceptions;
using System.Reflection;

namespace Couiler;

public class CouilerProgram
{
    private static string[]? _args;

    /// <summary>
    /// Method to pass arguments
    /// </summary>
    /// <param name="args">Program arguments to parse and operate on</param>
    /// <param name="executeImmediately">True if the commands should be executed immediately, else they can be run via <see cref="RunCommands"/></param>
    protected static void Args(string[] args, bool executeImmediately = true)
    {
        _args = args;

        if(executeImmediately) { Execute(); }
    }

    /// <summary>
    /// Runs the commands manually if executeImmediately bool is set to false in the args method
    /// <exception cref="ArgsNotProvidedException">This exception will be thrown if no arguments were provided via <see cref="Args"/></exception>
    /// </summary>
    protected void RunCommands()
    {
        if (_args == null)
            throw new ArgsNotProvidedException();

        Execute();
    }

    /// <summary>
    /// Actually executes the commands
    /// </summary>
    private static void Execute()
    {
        var cmdBuilder = CommandBuilder.Create;

        var methods = Assembly.GetEntryAssembly()?
            .GetTypes()
            .SelectMany(s => s.GetMethods())
            .Where(w => w.GetCustomAttributes<CommandAttribute>().Any())
            .ToArray() ?? throw new NoCommandsRegisteredException();

        foreach (var method in methods)
        {
            Action<string[]> action;

            if (method.IsStatic)
                action = (a) => method.Invoke(null, new object?[] { a });
            else
            {
                action = (b) =>
                {
                    var instance = Activator.CreateInstance(method.DeclaringType!);
                    method.Invoke(instance, new object?[]{b});
                };
            }

            cmdBuilder.AddCommand(method.GetCustomAttribute<CommandAttribute>()!.Name, action);
        }

        cmdBuilder.Build().Execute(_args);
    }
}
