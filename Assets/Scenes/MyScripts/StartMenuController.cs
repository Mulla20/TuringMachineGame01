using UnityEngine;
using UnityEngine.SceneManagement; //dont forget to add this

public class StartMenuController : MonoBehaviour
{
   public void StartGame(){

        SceneManager.LoadScene("InstructionScene");
   }

   public void ExitGame(){

   #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
   #endif
        Application.Quit();

   }

}
