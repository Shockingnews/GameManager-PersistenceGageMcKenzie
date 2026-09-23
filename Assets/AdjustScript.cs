using UnityEngine;

public class AdjustScript : MonoBehaviour
{

    void OnGUI()
    {
        if(GUI.Button(new Rect(10,100,100,30),"Health up"))
        {
            GameController.control.health += 10;
        }
        if (GUI.Button(new Rect(10, 140, 100, 30), "Health down"))
        {
            GameController.control.health -= 10;
        }
        if (GUI.Button(new Rect(10, 180, 100, 30), "Xp up"))
        {
            GameController.control.experience += 10;
        }
        if (GUI.Button(new Rect(10, 220, 100, 30), "xp down"))
        {
            GameController.control.experience -= 10;
        }
        if (GUI.Button(new Rect(10, 260, 100, 30), "Save"))
        {
            GameController.control.Save();
        }

        if (GUI.Button(new Rect(10, 300, 100, 30), "Load"))
        {
            GameController.control.Load();
        }
    }
    
}
