using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiPlayerTK;

public class Exercice : MonoBehaviour
{
    /// <summary>
    /// Processes an exercice
    /// </summary>

    ////////////////MEMBERS////////////////

    public MidiInOut myMidiInOut;
    public Computing myComputing;
    public GraphicInterface myGraphicInterface;
    public UserData myUserData;
    public GraphicExercice myGraphicExercice;
    private EventsBufferType refEvent, playingEvent;
    public List<MPTKEvent> eventsList;
    public int exerciceId;
    public float score = 0;
    public float scoreMin;
    public float highestScore;
    public bool isFinished;
    private bool playing;
    private float timer = 5;
    private bool counting = false;
    private int counTimer;
    private int regulator = 1;
    private bool succeeded;


    ////////////////METHODS////////////////

    // GraphicInterface Communication

    public void SetGraphicInterface()
    {
        myGraphicInterface.StartPitchDisplay();
        myGraphicInterface.StartScoreScrolling();
    }


    // MidiInOut Communication

    public void SetMidiStream()
    {
        eventsList = myMidiInOut.GetAllEvents();
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
        myUserData.highestScores[exerciceId] = highestScore;
    }

    public void SetFinished()
    {
        myUserData.exercicesFinished[exerciceId] = isFinished;
    }


    // Processing

    public void StartTimer()
    {
        myMidiInOut.SetFile(exerciceId);
        myMidiInOut.PlayFile();
        myMidiInOut.midiFilePlayer.MPTK_Pause((Convert.ToSingle(myMidiInOut.midiFilePlayer.MPTK_Tempo) / 60) * 4000);
        counting = true;
        playing = false;
    }

    public void Process()
    {
        //isFinished = GetIsFinished();
        //highestScore = GetHighestScore();
        playing = true;
        refEvent = new EventsBufferType();
        playingEvent = new EventsBufferType();
        SetMidiStream();
        SetGraphicInterface();

    }

    public void EndOfExercice()
    {
        SetFinished();
        SetHighestScore();
        CloseMidiStream();
    }

    void Update()
    {
        if (counting)
        {
            if (timer <= 0)
            {
                counting = false;
                Process();
            }
            else
                timer -= Time.deltaTime * (Convert.ToSingle(myMidiInOut.midiFilePlayer.MPTK_Tempo) / 60);
            counTimer = (int)timer;
            myGraphicInterface.StartTimerDisplaying(counTimer);
        }
        Debug.Log(playing);
        if (playing)
        {
            refEvent.FillBuffers(myMidiInOut.GetCurrentEvent());
            playingEvent.FillBuffers(myMidiInOut.inputMidiEvent);
                
            if (regulator%6 == 0)
            {
                regulator = 0;
                succeeded = myComputing.AccuracyAnalysis(playingEvent, refEvent);
                myGraphicInterface.SetSignalColor(succeeded);
            }

            regulator++;            
        }
    }
}