using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
