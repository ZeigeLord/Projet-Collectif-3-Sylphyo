using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiPlayerTK;

public class Tutorial 
{
    bool isFinished = false;
    public Nuance nuance;
    public Attaques attaques;
    public ShakeVibrato skakeVibrato;
    public Slider1 slider1;
    public Slider2 slider2;
    public Slider3 slider3;
    public Tangage tangage;
    public Roulis roulis;
    public ModeMvt modeMvt;
    public int tutoId;
    public MidiInOut myMidiInOut;
    public UserData myUserData;


    private void Start()
    {

    }

    void Update()
    {
       
    }
    public void SetMidiStream()
    {
        myMidiInOut.SetFile(tutoId);
        myMidiInOut.StartReading();
    }

    public void CloseMidiStream()
    {
        myMidiInOut.StopReading();
        myMidiInOut.StopSending();
    }

    public void StartBackingTrack()
    {
        myMidiInOut.PlayFile();
    }

    public bool GetIsFinished()
    {
        return myUserData.tutorialsFinished[tutoId];
    }
    public void SetFinished()
    {
        myUserData.tutorialsFinished[tutoId] = isFinished;
    }

    public void call_tuto(int id)
    {
        switch(id)
        {
            case 1:
                nuance.Process();
                break;
            case 2:
                attaques.Process();
                break;
            case 3:
                skakeVibrato.Process();
                break;
            case 4:
                slider1.Process();
                break;
            case 5:
                slider2.Process();
                break;    
            case 6:
                slider3.Process();
                break;  
            case 7:
                tangage.Process();
                break;  
            case 8:
                roulis.Process();
                break;             
            case 9:
                modeMvt.Process();
                break;
            default :
                break; 
        }
    }
}