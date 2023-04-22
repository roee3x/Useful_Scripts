using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleCommand : ICommand {

    //here i can cash any fields i need initialized in the constcructor for the command
    
    public ExampleCommand() { 
        // using this constructor, i can initialize any references i need for this command
    }

    public void Execute() {
        // do logic of said command
    }

    public void Undo() {
        // do opposite logic to execute (can be the same method)
    }
}
