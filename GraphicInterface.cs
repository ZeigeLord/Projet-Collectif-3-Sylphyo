using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class GraphicInterface : MonoBehaviour
{
    /// <summary>
    /// Manages GUI
    /// <summary>


    ////////////////MEMBERS////////////////

    public GameObject pitchDisplayPointPrefab, pitchDisplayPointPrefabFile;
    public GameObject[] pitchDisplayPoints = new GameObject[500];
    public GameObject[] pitchDisplayPointsFile = new GameObject[500];
    private MidiInOut myMidiInOut;
    private bool pitchDisplay = false;


    ////////////////METHODS////////////////

    public void StartPitchDisplay()
    {
        myMidiInOut.SetFile(1);
        for (int i = 0; i < pitchDisplayPoints.Length; i++)
        {
            pitchDisplayPoints[i] = GameObject.Instantiate(pitchDisplayPointPrefab);
            pitchDisplayPoints[i].GetComponent<RectTransform>().localPosition = new Vector3(10 + i * 10, 500, 0);
            pitchDisplayPoints[i].transform.SetParent(transform);
        }

        for (int i = 0; i < pitchDisplayPointsFile.Length; i++)
        {
            pitchDisplayPointsFile[i] = GameObject.Instantiate(pitchDisplayPointPrefabFile);
            pitchDisplayPointsFile[i].GetComponent<RectTransform>().localPosition = new Vector3(10 + i * 10, 500, 0);
            pitchDisplayPointsFile[i].transform.SetParent(transform);
        }
        pitchDisplay = true;
    }

    void Update()
    {
        if (pitchDisplay)
        {
            if (myMidiInOut.GetCurrentEvent().Command == MPTKCommand.NoteOn)
            {
                myMidiInOut.UpdatePitchHistory(myMidiInOut.GetCurrentEvent().Value);
                for (int i = 0; i < pitchDisplayPoints.Length; i++)
                {
                    pitchDisplayPoints[i].transform.position = new Vector3(10 + i * 10, 500 + 10 * myMidiInOut.pitchHistory[i], 0);
                }
                for (int i = 0; i < pitchDisplayPointsFile.Length; i++)
                {
                    pitchDisplayPointsFile[i].transform.position = new Vector3(10 + i * 10, 500 + 10 * myMidiInOut.pitchHistory[i], 0);
                }
            }
        }
    }
}
