using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public int currentLevel;
    public int stars;

    public Dictionary<string, int> level = new Dictionary<string, int>();

    void Awake () {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

	}

    public void GetDicitonary(Dictionary<string, int> dictionary, string name)
    {
        if (level[name] < dictionary[name])
            level = dictionary;
        else
            Debug.Log("Menor");
    }
	
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameData.dat");

        GameData data = new GameData();
        data.currentLevel = currentLevel;
        data.stars = stars;
        data.level = level;

        bf.Serialize(file, data);
        file.Close();
    }

    public bool Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);

            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            currentLevel = data.currentLevel;
            stars = data.stars;
            level = data.level;
            return true;
        }
        else
            return false;
        
    }
}

[Serializable]
class GameData
{
    public int currentLevel;
    public int stars;
    public Dictionary<string, int> level = new Dictionary<string, int>();
}
