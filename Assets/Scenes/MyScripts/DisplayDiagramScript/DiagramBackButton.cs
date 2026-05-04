using UnityEngine;
using UnityEngine.SceneManagement;

public class DiagramBackButton : MonoBehaviour
{
    public void GoBackToMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}