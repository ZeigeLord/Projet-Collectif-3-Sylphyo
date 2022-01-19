using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class InstantiatePitchDisplay : MonoBehaviour
{
    /// <summary>
    /// Display points on the screen representing pitch
    /// <summary>


    ////////////////MEMBERS////////////////

    public GameObject pitchDisplayPointPrefab, pitchDisplayPointPrefabFile;
    public GameObject[] pitchDisplayPoints = new GameObject[500];
    public GameObject[] pitchDisplayPointsFile = new GameObject[500];
    public MidiInOut mio;
    public int[] pitchHistory = new int[500];
    private bool display = false;


    ////////////////METHODS////////////////

    public void StartPitchDisplay()
    {
        mio.StartReading();
        mio.SetFile(1);
        mio.PlayFile();
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
        display = true;
    }

    void Update()
    { 
        if (display)
        {
            if (mio.GetCurrentEvent().Command == MPTKCommand.NoteOn)
            {
                mio.UpdatePitchHistory(mio.GetCurrentEvent().Value);
                for (int i = 0; i < pitchDisplayPoints.Length; i++)
                {
                    pitchDisplayPoints[i].transform.position = new Vector3(10 + i * 10, 500 + 10 * mio.pitchHistory[i], 0);
                }
                for (int i = 0; i < pitchDisplayPointsFile.Length; i++)
                {
                    pitchDisplayPointsFile[i].transform.position = new Vector3(10 + i * 10, 500 + 10 * mio.pitchHistory[i], 0);
                }
            }
        }
    }
}