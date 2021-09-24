using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Name : MonoBehaviour
{
    public static Name Instance;
    public Text bestScoreField;

    public string bestScoreText;
    public string nameOfPlayer;
    public int best_points;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadText();
    }

    private void Start()
    {
        bestScoreField.text = bestScoreText;
    }

    public void SetName(string name)
    {
        nameOfPlayer = name;
        //bestScoreText = "Best Score : " + name + " : 0";
    }

    [System.Serializable]
    class SaveData
    {
        public string bestScoreText;
        public int best_points;
    }

    public void SaveText()
    {
        SaveData data = new SaveData();
        data.bestScoreText = bestScoreText;
        data.best_points = best_points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadText()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreText = data.bestScoreText;
            best_points = data.best_points;
        }
    }
}
