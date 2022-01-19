using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class InstantiatePitchDisplay : MonoBehaviour
{
    public GameObject pitchDisplayPointPrefab, pitchDisplayPointPrefabFile;
    public GameObject[] pitchDisplayPoints = new GameObject[500];
    public GameObject[] pitchDisplayPointsFile = new GameObject[500];
    public MidiInOut mio;
    public int[] pitchHistory = new int[500];
    //public int[] pitchHistory2 = new int[500];
    MPTKEvent midiEvent;
    int pitch;
    int file;

    // Start is called before the first frame update
    void Start()
    {
        //mio.StartReading();
        //mio.ReadEvent(midiEvent);
        mio.ReadFileEvent();
        mio.UpdatePitchHistory(pitch);
        for (int i = 0; i< pitchDisplayPoints.Length; i++)
        {
            pitchDisplayPoints[i] = GameObject.Instantiate(pitchDisplayPointPrefab);
            pitchDisplayPoints[i].GetComponent<RectTransform>().localPosition = new Vector3(10+i*10, 500, 0);
            pitchDisplayPoints[i].transform.SetParent(transform);
        }

        for (int i = 0; i < pitchDisplayPointsFile.Length; i++)
        {
            pitchDisplayPointsFile[i] = GameObject.Instantiate(pitchDisplayPointPrefabFile);
            pitchDisplayPointsFile[i].GetComponent<RectTransform>().localPosition = new Vector3(10 + i * 10, 500, 0);
            pitchDisplayPointsFile[i].transform.SetParent(transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pitchDisplayPoints.Length; i++)
        {
            pitchDisplayPoints[i].transform.position = new Vector3(10 + i * 10, 500 + 10* mio.pitchHistory[i], 0);
        }
        for (int i = 0; i < pitchDisplayPointsFile.Length; i++)
        {
            pitchDisplayPointsFile[i].transform.position = new Vector3(10 + i * 10, 500 + 10 * mio.pitchHistory[i], 0);
        }
    }

    public void NiqueTaRace()
    {

    }


}
