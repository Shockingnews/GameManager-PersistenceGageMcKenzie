using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "New Game"))
        {
            
            GameController.control.NewGame();
            SceneManager.LoadScene(1);
        }
        if (GUI.Button(new Rect(10, 140, 100, 30), "Load Game"))
        {

            
            SceneManager.LoadScene(1);
        }

    }
}
