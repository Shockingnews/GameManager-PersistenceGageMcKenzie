using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int count;
    public static GameController control;
    public bool isActive = false;

    public float health;
    public float sheild;
    public float experience;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (!isActive)
        {
            if (control == null)
            {
                DontDestroyOnLoad(gameObject);
                control = this;
            }

            else if (control != this)
            {
                count += 1;
                Destroy(gameObject);
                Debug.Log("GameManager Destroyed" );
            }
        }

        
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10,10,100,30), "health: " + health);
        GUI.Label(new Rect(10, 40, 100, 30), "XP: " + experience);
        GUI.Label(new Rect(10, 60, 100, 30), "Shield: " + sheild);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data._health = health;
        data._experience = experience;
        data._sheild = sheild;

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
            sheild = data._sheild;
        }
    }

    public void NewGame()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
            //PlayerData data = (PlayerData)bf.Deserialize(file);
            PlayerData data = new PlayerData();
            health = 100;
            experience = 1200;
            sheild = 100;
            data._health = health;
            data._experience = experience;
            data._sheild = sheild;
            bf.Serialize(file, data);
            file.Close();
            
        }
        else if(!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            health = 100;
            experience = 1200;
            sheild= 100;
        }
    }

    private void Update()
    {
        //if (isActive)
        //{
        //    if (control == null)
        //    {
        //        DontDestroyOnLoad(gameObject);
        //        control = this;
        //    }

        //    else if (control != this)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
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
    public float _sheild;

}
