using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice : MonoBehaviour
{
    /// <summary>
    /// Processes an exercice
    /// <summary>

    ////////////////MEMBERS////////////////
    
    public MidiInOut myMidiInOut;
    public Computing myComputing;
    public GraphicInterface myGrapicInterface;
    public UserData myUserData;
    public int level;
    public int exerciceId;
    public int typeId;
    public float score;
    public bool finished;


    ////////////////METHODS////////////////

    // GraphicInterface Communication

    // MidiInOut Communication
    
    public void SetMidiStream()
    {
        myMidiInOut.SetFile(level, typeId, exerciceId);
        myMidiInOut.StartReading();
        //myMidiInOut.StartSending();
    }

    public void CloseMidiStream()
    {
        myMidiInOut.StopReading();
        myMidiInOut.StopSending();
    }


    // Computing Communication

    // UserData Communication
}
