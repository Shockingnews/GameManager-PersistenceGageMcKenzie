using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController control;

    public float health;
    public float experience;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }

        else if (control != this)
        {
            Destroy(gameObject);
        }

        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10,10,100,30), "health: " + health);
        GUI.Label(new Rect(10, 40, 100, 30), "XP: " + experience);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data._health = health;
        data._experience = experience;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            health = data._health;
            experience = data._experience;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        { 
            SceneManager.LoadScene(0); 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(3);
        }
    }


}

[Serializable]
class PlayerData
{
    public float _health;
    public float _experience;

}
