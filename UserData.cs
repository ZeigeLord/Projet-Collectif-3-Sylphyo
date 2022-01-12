using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserData : MonoBehaviour
{
    private string path;
    private string json;
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

    public void Save()
    {
        path = Application.streamingAssetsPath;

        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    public void Load()
    {
        
    }
}
