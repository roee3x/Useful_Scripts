using UnityEngine;

public class SomeBehaviour : MonoBehaviour {
    [Header("commands fields")]
    private ExampleInvoker _invoker;

    private void Start() {
        _invoker = new ExampleInvoker();
    }


    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            ICommand newCommand = new ExampleCommand(); //if needed i can pass info to the constructor here
            _invoker.AddCommand(newCommand);
        }

        if(Input.GetKeyDown(KeyCode.Z)) {
            _invoker.UndoCommand();
        }
    }
}
