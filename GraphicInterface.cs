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
    private bool pitchDisplay = false;
    private int index = 0;
    private List<MPTKEvent> midiEvents = new List<MPTKEvent>();
    private List<MPTKEvent> noteOnEvents = new List<MPTKEvent>();
    public Slider sliderIntensite, sliderIntensiteRef, sliderTangage, sliderTangageRef;
    
    //Curved slider 
    public Image bar, barRef;
    public RectTransform buttonRef;
    public float valueBar = 0;
    public float valueBarRef = 0;

    ////////////////METHODS////////////////

    void Start()
    {
        myMidiInOut.StartReading();
    }

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

        ChangeRealValueRoulis();
        ChangeFileValueRoulis();
        ChangeRealValueIntensite();
        ChangeFileValueIntensite();
        ChangeRealValueTangage();
        ChangeFileValueTangage();
    }

    public void BarChange(float barValue)
    {
        float amount = (barValue / 100.0f) * 180.0f / 360;
        bar.fillAmount = amount;
        float buttonAngle = amount * 360;    
    }
    public void BarChangeRef(float barValue)
    {
        float amount = (barValue / 100.0f) * 180.0f / 360;
        barRef.fillAmount = amount;
        float buttonAngle = amount * 360;
        buttonRef.localEulerAngles = new Vector3(0, 0, -buttonAngle);
    }
    public void ChangeRealValueRoulis()
      {
        BarChange(valueBar);
        if (myMidiInOut.inputMidiEvent == null)
        {
            valueBar = 0;
            Debug.Log("Roulis nul");
        }
        else if (myMidiInOut.inputMidiEvent.Controller == MPTKController.SOUND_CTRL7)
        {
            valueBar = myMidiInOut.inputMidiEvent.Value;
            Debug.Log(myMidiInOut.inputMidiEvent.Value);
        }
    }

    public void ChangeFileValueRoulis()
    {
        myMidiInOut.SetFile(1);
        myMidiInOut.PlayFile();
        BarChangeRef(valueBarRef);
        if (myMidiInOut.GetCurrentEvent() == null)
        {
            valueBarRef = 0;
            Debug.Log("Roulis du fichier nul");
        }
        else if (myMidiInOut.GetCurrentEvent().Controller == MPTKController.SOUND_CTRL7)
        {
            valueBarRef = myMidiInOut.GetCurrentEvent().Value;
            Debug.Log(myMidiInOut.GetCurrentEvent().Value);
        }
    }

    public void ChangeRealValueIntensite()
    {
        if (myMidiInOut.inputMidiEvent == null)
        {
            sliderIntensite.value = 0;
            Debug.Log("Volume nul");
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
            Debug.Log("volume du fichier nul");
        }
        else if (myMidiInOut.GetCurrentEvent().Controller == MPTKController.Expression)
        {
            sliderIntensiteRef.value = myMidiInOut.GetCurrentEvent().Value;
            Debug.Log(myMidiInOut.GetCurrentEvent().Value);
        }
    }
    public void ChangeRealValueTangage()
    {
        if (myMidiInOut.inputMidiEvent == null)
        {
            sliderIntensite.value = 0;
            Debug.Log("Tangage nul");
        }
        else if (myMidiInOut.inputMidiEvent.Controller == MPTKController.SOUND_CTRL6)
        {
            sliderIntensite.value = myMidiInOut.inputMidiEvent.Value;
            Debug.Log(myMidiInOut.inputMidiEvent.Value);
        }
    }

    public void ChangeFileValueTangage()
     {
         myMidiInOut.SetFile(1);
         myMidiInOut.PlayFile();
         if (myMidiInOut.GetCurrentEvent() == null)
         {
             sliderIntensiteRef.value = 0;
             Debug.Log("Tangage du fichier nul");
         }
         else if (myMidiInOut.GetCurrentEvent().Controller == MPTKController.SOUND_CTRL6)
         {
             sliderIntensiteRef.value = myMidiInOut.GetCurrentEvent().Value;
             Debug.Log(myMidiInOut.GetCurrentEvent().Value);
         }
     }

}