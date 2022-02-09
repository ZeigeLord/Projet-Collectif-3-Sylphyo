using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class UserDataManager
{
    /// <summary>
    /// Processes saving and loading data
    /// <summary>


    ////////////////MEMBERS////////////////

    static List<UserData> _userDataArray = new List<UserData>();


    ////////////////METHODS////////////////

    public static void Save()
    {
        string path = Application.streamingAssetsPath;

        string json = JsonUtility.ToJson(_userDataArray);

        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    public static string ConvertFileToJson()
    {
        string path = Application.streamingAssetsPath;

        using (StreamReader reader = new StreamReader(path))
        {
            string json = reader.ReadToEnd();
            return json;
        }
    }

    public static void Load()
    {
        string dataToConvert = ConvertFileToJson();

        _userDataArray = JsonUtility.FromJson<List<UserData>>(dataToConvert);
    }

    public static void Add(UserData dataToAdd)
    {
        foreach (UserData checking in _userDataArray)
        {
            if (dataToAdd._userName == checking._userName)
                break;
        }
        _userDataArray.Add(dataToAdd);
    }

    public static void UpdateData(UserData data)
    {
        foreach (UserData dataToUpdate in _userDataArray)
        {
            if (data._userName == dataToUpdate._userName)
            {
                dataToUpdate.exercicesFinished = data.exercicesFinished;
                dataToUpdate.tutorialsFinished = data.tutorialsFinished;
                dataToUpdate.highestScores = data.highestScores;
            }
        }
    }

    public static List<UserData> GetUserDataArray()
    {
        return _userDataArray;
    }
}