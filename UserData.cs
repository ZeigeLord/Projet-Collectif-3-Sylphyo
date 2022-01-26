using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserData : MonoBehaviour
{
    /// <summary>
    /// Contains an user's data
    /// <summary>


    ////////////////MEMBERS////////////////

    public string _userName;
    public bool[] tutorialsFinished = new bool[30];
    public bool[] exercicesFinished = new bool[30];
    public float[] highestScores = new float[30];


    ////////////////METHODS////////////////

    public bool SetNewData(string userName)
    {
        if (LoadData(userName) == false)
        {
            _userName = userName;
            exercicesFinished[0] = true;
            tutorialsFinished[0] = true;
            highestScores[0] = 0;

            for (int i = 0; i < 31; i++)
            {
                exercicesFinished[i + 1] = false;
                tutorialsFinished[i + 1] = false;
                highestScores[i + 1] = 0;
            }
            UserDataManager.Add(this);
            return true;
        }
        return false;
    }

    public bool LoadData(string userName)
    {
        List<UserData> dataArray = new List<UserData>();
        dataArray = UserDataManager.GetUserDataArray();

        foreach(UserData data in dataArray)
        {
            if (data._userName == userName)
            {
                _userName = userName;
                tutorialsFinished = data.tutorialsFinished;
                exercicesFinished = data.exercicesFinished;
                highestScores = data.highestScores;
                return true;
            }
        }
        return false;
    }
}