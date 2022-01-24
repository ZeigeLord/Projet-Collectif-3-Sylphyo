using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public MidiInOut myMidiInOut;
    public MidiFilePlayer midiFilePlayer;
    private bool pitchDisplay = false;
    private int index = 0;
    private List<MPTKEvent> midiEvents = new List<MPTKEvent>();
    private List<MPTKEvent> noteOnEvents = new List<MPTKEvent>();
    public Slider sliderIntensite, sliderIntensiteRef, sliderRoulis, sliderRoulisRef, sliderTangage;

    ////////////////METHODS////////////////

    public void StartPitchDisplay()
    {
        for (int i = 0; i < pitchDisplayPoints.Length; i++)
        {
            pitchDisplayPoints[i] = GameObject.Instantiate(pitchDisplayPointPrefab);
            //pitchDisplayPoints[i].GetComponent<RectTransform>().localPosition = new Vector3(10 + i * 10, 800, 0);
            pitchDisplayPoints[i].transform.SetParent(transform);
        }

        for (int i = 0; i < pitchDisplayPointsFile.Length; i++)
        {
            pitchDisplayPointsFile[i] = GameObject.Instantiate(pitchDisplayPointPrefabFile);
            //pitchDisplayPointsFile[i].GetComponent<RectTransform>().localPosition = new Vector3(10 + i * 10, 800, 0);
            pitchDisplayPointsFile[i].transform.SetParent(transform);
        }
        pitchDisplay = true;
        midiEvents = myMidiInOut.GetAllEvents();
        noteOnEvents = myMidiInOut.GetNoteOnEvents();
        foreach (MPTKEvent midiEvent in noteOnEvents)
        {
            pitchDisplayPointsFile[index].transform.position = new Vector3(10 + index * 10, 800 + 10 * midiEvent.Value, 0);
            index++;
        }
    }

    void Update()
    {
        if (pitchDisplay)
        {
            if (myMidiInOut.inputMidiEvent != null && myMidiInOut.inputMidiEvent.Command == MPTKCommand.NoteOn)
            {
                myMidiInOut.UpdatePitchHistory(myMidiInOut.inputMidiEvent.Value);
                for (int i = 0; i < pitchDisplayPoints.Length; i++)
                {
                    pitchDisplayPoints[i].transform.position = new Vector3(10 + i * 10, 800 + 10 * myMidiInOut.pitchHistory[i], 0);
                }
            }
            for (int i = 0; i < pitchDisplayPointsFile.Length; i++)
            {
                pitchDisplayPointsFile[i].transform.Translate(1, 0, 0);
            }
        }

        ChangeRealValueIntensite();
        ChangeFileValueIntensite();
    }
    public void ChangeRealValueIntensite()
    {
        if (myMidiInOut.inputMidiEvent == null)
        {
            sliderIntensite.value = 0;
            Debug.Log("Bonjour <3");
        }
        else if (myMidiInOut.inputMidiEvent.Controller == MPTKController.Expression)
        {
            sliderIntensite.value = myMidiInOut.inputMidiEvent.Value;
            Debug.Log(myMidiInOut.inputMidiEvent.Value);
        }
    }

    public void ChangeFileValueIntensite()
    {
        myMidiInOut.SetFile(1);
        myMidiInOut.PlayFile();
        if (myMidiInOut.GetCurrentEvent() == null)
        {
            sliderIntensiteRef.value = 0;
            Debug.Log("Bonjour <3");
        }
        else if (myMidiInOut.GetCurrentEvent().Controller == MPTKController.Expression)
        {
            sliderIntensiteRef.value = myMidiInOut.GetCurrentEvent().Value;
            Debug.Log(myMidiInOut.GetCurrentEvent().Value);
        }
    }
}