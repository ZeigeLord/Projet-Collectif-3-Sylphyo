using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserData : MonoBehaviour
{
    /// <summary>
    /// Processes saving and loading data
    /// <summary>


    ////////////////MEMBERS////////////////
    
    public string _userName;
    public bool[] tutorialsFinished = new bool[30];
    public bool[] exercicesFinished = new bool[30];
    public float[] highestScores = new float[30];


    ////////////////METHODS////////////////

    public void SetNewData(string userName)
    {
        _userName = userName;
        exercicesFinished[0] = true;
        tutorialsFinished[0] = true;
        highestScores[0] = 0;

        for(int i = 0; i < 30; i++)
        {
            exercicesFinished[i + 1] = false;
            tutorialsFinished[i + 1] = false;
            highestScores[i + 1] = 0;
        }

    }
}