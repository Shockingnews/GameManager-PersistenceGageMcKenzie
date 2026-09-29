using UnityEngine;

public class AddManagers : MonoBehaviour
{
    private GameObject manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 180, 100, 30), "Add Manager"))
        {
            manager = new GameObject("manager");
            manager.AddComponent<GameController>();
            Instantiate(manager);
        }
        
    }
}
