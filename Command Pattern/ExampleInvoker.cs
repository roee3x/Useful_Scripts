using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// the name of the invoker can be related to a specific region, for an instance, if i use this for lamps, i can call this "light app"
/// </summary>

public class ExampleInvoker : MonoBehaviour
{
    [Header("Command List & Control")]
    //can be any type of list
    private List<ICommand> commands;
    private Stack<ICommand> stack;

    public ExampleInvoker() {
        //i will use the constructor to initialize the list of commands and any additional data

        commands = new List<ICommand>();
        stack = new Stack<ICommand>();
    }

    public void AddCommand(ICommand command) {
        command.Execute();
        commands.Add(command);
        stack.Push(command);
    }

    public void UndoCommand() {
        if(commands.Count > 0) {
            ICommand latestCommand = commands[commands.Count];
            latestCommand.Undo();
            commands.RemoveAt(commands.Count);
        }

        if(stack.Count > 0) {
            ICommand latestCommand = stack.Pop();
            latestCommand.Undo();
        }
    }
}
