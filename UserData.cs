using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UserData : MonoBehaviour
{
    /// <summary>
    /// Contains an user's data
    /// <summary>


    ////////////////MEMBERS////////////////

    public string _userName;
    public bool[] tutorialsFinished = new bool[31];
    public bool[] exercicesFinished = new bool[31];
    public float[] highestScores = new float[31];
    public GameObject main_panel, creer_panel, charger_panel;
    public Text myText;
    public GameObject inputField;


    ////////////////METHODS////////////////

    public bool SetNewData(string userName)
    {
        if (LoadData(userName) == false)
        {
            _userName = userName;
            exercicesFinished[0] = true;
            tutorialsFinished[0] = true;
            highestScores[0] = 0;

            for (int i = 0; i < 30; i++)
            {
                exercicesFinished[i + 1] = false;
                tutorialsFinished[i + 1] = false;
                highestScores[i + 1] = 0;
            }
            UserDataManager.Add(this);
            UserDataManager.Save();
            return true;
        }
        return false;
    }

    public bool LoadData(string userName)
    {
        List<UserData> dataArray = new List<UserData>();
        dataArray = UserDataManager.GetUserDataArray();

        foreach (UserData data in dataArray)
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

    public void LoadDataChangePage()
    {
        _userName = inputField.GetComponent<Text>().text;

        if (LoadData(_userName))
        {
            main_panel.SetActive(true);
            charger_panel.SetActive(false);
        }
        else
        {
            main_panel.SetActive(false);
            myText.GetComponent<Text>().text = "Mauvais nom d'utilisateur";
        }
    }
    public void NewDataChangePage()
    {
        _userName = inputField.GetComponent<Text>().text;
        if (SetNewData(_userName))
        {
            main_panel.SetActive(true);
            creer_panel.SetActive(false);
        }
        else
        {
            creer_panel.SetActive(false);
            myText.GetComponent<Text>().text = "Nom d'utilisateur déjà existant";
        }
    }

    public void UpdateData()
    {
        UserDataManager.UpdateData(this);
        UserDataManager.Save();
    }
}