using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserData : MonoBehaviour
{
    /// <summary>
    /// Processes saving and loading data
    /// <summary>


    ////////////////MEMBERS////////////////
    
    public string userName;
    public bool[] tutorialsFinished;
    public bool[] exercicesFinished;
    public float[] highestScores;

    [Serializable]
    public class Data
    {
        public string _userName;
        public bool[] _tutorialsFinished;
        public bool[] _exercicesFinished;
        public float[] _highestScores;
    }


    ////////////////METHODS////////////////

    public void Save()
    {
        Data saveData = new Data();
        saveData._userName = userName;
        saveData._tutorialsFinished = tutorialsFinished;
        saveData._exercicesFinished = exercicesFinished;
        saveData._highestScores = highestScores;

        string path = Application.streamingAssetsPath;

        string json = JsonUtility.ToJson(saveData);

        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    public string ConvertData()
    {
        string path = Application.streamingAssetsPath;

        using (StreamReader reader = new StreamReader(path))
        {
            string json = reader.ReadToEnd();
            return json;
        }
    }

    public void Load()
    {
        string dataToConvert = ConvertData();

        Data dataToLoad = new Data();
        dataToLoad = JsonUtility.FromJson<Data>(dataToConvert);
        userName = dataToLoad._userName;
        tutorialsFinished = dataToLoad._tutorialsFinished;
        exercicesFinished = dataToLoad._exercicesFinished;
        highestScores = dataToLoad._highestScores;        
    }
}
