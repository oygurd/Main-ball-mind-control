using System.Collections;
using System.Collections.Generic;

public class CommandInvoker
{
    private static List<ICommand> command = new List<ICommand>();

    public static void ExecuteCommand(ICommand command)
    {
        command.execute();
    }
}