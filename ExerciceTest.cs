using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;
using System.IO;

public class ExerciceTest : Exercice
{
  public string dataSeparator = "%SEPARATOR%";
  public override void SaveData()
  {
    string[] data = new string[];
    {
      exerciceTried.ToString(),
      lastScore.ToString(),
      exerciceSucceeded.ToString(),
      highScore.ToString()
    };
    string dataSeparated = string.Join(dataSeparator, data);
    File.WriteAllText (Application.dataPath + "/exerciceTest.txt", dataSeparated);      //change name of text file according to exercice name
    Debug.Log ("Sauvegarde effectuée");
  }
  
  public override void LoadData()
  {
    string dataSeparated = File.ReadAllText (Application.dataPath + "/exerciceTest.txt");
    string[] data = dataSeparated.Split (new[] { dataSeparator }, System.StringSplitOptions.None);
    
    exerciceTried = bool.Parse (data[0]);
    lastScore = float.Parse (data[1]);
    exerciceSucceeded = bool.Parse (data[2]);
    highScore = float.Parse (data[3]);
    
    Debug.Log ("Chargement des données de l'exercice effectué");
  }

};
