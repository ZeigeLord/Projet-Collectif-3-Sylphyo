using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

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
    public List<MPTKEvent> eventsList;
    public int exerciceId;
    public float score;
    public float highestScore;
    public bool isFinished;
    private bool playing;


    ////////////////METHODS////////////////

    // GraphicInterface Communication





    // MidiInOut Communication
    
    public void SetMidiStream()
    {
        myMidiInOut.SetFile(exerciceId);
        eventsList = myMidiInOut.GetAllEvents();
        myMidiInOut.StartReading();
        //myMidiInOut.StartSending();
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


    // Computing Communication

    public bool Checking(MPTKEvent refEvent, MPTKEvent playingEvent, int id)
    {
        return myComputing.accuracy_note(playingEvent, refEvent, id);
    }



    // UserData Communication

    public float GetHighestScore()
    {
        return myUserData.highestScores[exerciceId];
    }

    public bool GetIsFinished()
    {
        return myUserData.exercicesFinished[exerciceId];
    }

    public void SetHighestScore()
    {
        myUserData.highestScores[exerciceId] = score;
    }
    
    public void SetFinished()
    {
        myUserData.exercicesFinished[exerciceId] = isFinished;
    }


    // Processing

    public void Process()
    {
        isFinished = GetIsFinished();
        highestScore = GetHighestScore();
        //SetGraphicInteface
        SetMidiStream();
        StartBackingTrack();
        playing = true;
    }

    void Update()
    {
        if (playing)
        {
            //checking
            //incrémentation score ou non
            //update graphic
        }
    }
}
