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
    public List<MPTKEvent> eventsList;
    public int exerciceId;
    public float score = 0;
    public float scoreMin;
    public float highestScore;
    public bool isFinished;
    private bool playing = false;
    private float timer = 4;
    private bool counting = false;
    private int counTimer;
    private bool timerActive = false;

    //GameObject[] interfaceExercices_objects;
    //GraphicInterface[] interfaceExercices;
    ////////////////METHODS////////////////

    private void Start()
    {
        //interfaceExercices_objects = GameObject.FindGameObjectsWithTag("ExerciceInterface");
        //interfaceExercices = FindObjectsOfType<GraphicInterface>();
        
    }

    // GraphicInterface Communication

    public void SetGraphicInterface()
    {
        myGraphicInterface.StartPitchDisplay();
        myGraphicInterface.StartScoreScrolling();
    }


    // MidiInOut Communication

    public void SetMidiStream()
    {
        myMidiInOut.SetFile(exerciceId);
        myMidiInOut.PlayFile();
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

    public bool Checking(MPTKEvent playingEvent, MPTKEvent refEvent, int id)
    {
        return myComputing.accuracy_note(playingEvent, refEvent, id);
    }

    public void CheckSuccess(float score, float scoreMin)
    {
        if (myComputing.score(score, scoreMin))
            isFinished = true;
    }

    public void CheckHighScore(float score, float scoreMax)
    {
        if (myComputing.meilleur_score(score, scoreMax))
            highestScore = score;
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
        myUserData.highestScores[exerciceId] = highestScore;
    }

    public void SetFinished()
    {
        myUserData.exercicesFinished[exerciceId] = isFinished;
    }


    // Processing

    public void StartTimer()
    {
        counting = true;
    }

    public void Process()
    {
        //isFinished = GetIsFinished();
        //highestScore = GetHighestScore();
        SetMidiStream();
        SetGraphicInterface();
        playing = true;
    }

    public void EndOfExercice()
    {
        CheckSuccess(score, scoreMin);
        CheckHighScore(score, highestScore);
        SetFinished();
        SetHighestScore();
        CloseMidiStream();
        myUserData.UpdateData();
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
                timer -= Time.deltaTime;
                counTimer = (int)timer;
        }

        if (playing)
        {
            if (myMidiInOut.midiFilePlayer.MPTK_TickCurrent != myMidiInOut.midiFilePlayer.MPTK_TickLast)
            {
                //if (Checking(myMidiInOut.inputMidiEvent, myMidiInOut.GetCurrentEvent(), exerciceId))
                //score++;
                //update graphic
            }
            else
            {
                //if (Checking(myMidiInOut.inputMidiEvent, myMidiInOut.GetCurrentEvent(), exerciceId))
                //score++;
                //update graphic
                playing = false;
                EndOfExercice();
            }
        }
        myGraphicInterface.StartTimerDisplaying(counTimer);
    }
}