using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class MainManagerx : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainManagerx Instance;
    public string playerName;
    public string playerNameHig;
    public int playerScore;
    public int HigPlayerScore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        //LoadColor();

    }
    [System.Serializable]
    class SaveData
    {
        public string playerName;
     
        public string playerNameHig;
        public int playerScoreHig;
    }
    public void SaveCurrentName(string playerNamep)
    {
        SaveData data = new SaveData();
        data.playerName = playerNamep;
        //data.lastScore = lastScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefileSaveCurrentName.json", json);
    }
    public void SaveNameHig(string playerNamep)
    {
        SaveData data = new SaveData();
        data.playerNameHig = playerNamep;
        //data.lastScore = lastScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefileNameHigt.json", json);
    }
   
    public void SaveHigScore(int playerScorep)
    {
        SaveData data = new SaveData();
        data.playerScoreHig = playerScorep;
        Debug.Log("puntaje que se ha guardado " + data.playerScoreHig);
        //data.lastScore = lastScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefileHigthScore.json", json);
    }
    public void LoadCurrentName()
    {
        string path = Application.persistentDataPath + "/savefileSaveCurrentName.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
        }
    }
    public void LoadNameHig()
    {
        string path = Application.persistentDataPath + "/savefileNameHigt.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerNameHig = data.playerNameHig;
        }
    }
   
    public void LoadHightScore()
    {
        string path = Application.persistentDataPath + "/savefileHigthScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HigPlayerScore = data.playerScoreHig; 
            Debug.Log("puntaje cargado"+ HigPlayerScore);
        }
        else
        {
            Debug.Log("No se encontró el archivo de guardado.");
        }
    }
}
