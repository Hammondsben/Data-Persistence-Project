using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Start is called before the first frame update
    public string PlayerName = "";
    public int bestScore = 0;
    
    void Awake()
    {
        LoadScore();
        if  (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerName);
    }

    public void getPlayerName(string playerName)
    {
        PlayerName = playerName;
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
        }
    }
}
