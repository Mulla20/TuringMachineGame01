using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayDiagramController : MonoBehaviour //learned to use this controller to
                                                      // prevent jumping to the diagram while the TM is still running through the states (rules)
{
    public StateManager stateManager; //looked up how to do this as ran into issue with the TM randomly jumping to the diagram scene

    public void GoToDiagramScene()
    {
        if (stateManager.isRunning)
        {
            Debug.Log("Machine is still running.");
            return;
        }

        SceneManager.LoadScene("StateDiagramScene");
    }
}