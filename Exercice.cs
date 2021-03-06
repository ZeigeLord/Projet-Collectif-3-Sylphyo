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
    public GraphicInterface myGraphicInterface;
    public UserData myUserData;
    public List<MPTKEvent> eventsList;
    public int exerciceId;
    public float score = 0;
    public float scoreMin;
    public float highestScore;
    public bool isFinished;
    private bool playing = false;


    ////////////////METHODS////////////////

    // GraphicInterface Communication

    public void SetGraphicInterface()
    {
        myGraphicInterface.StartPitchDisplay();
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

    public void Process()
    {
        //isFinished = GetIsFinished();
        //highestScore = GetHighestScore();
        SetGraphicInterface();
        SetMidiStream();
        playing = true;
    }

    public void EndOfExercice()
    {
        CheckSuccess(score, scoreMin);
        CheckHighScore(score, highestScore);
        SetFinished();
        SetHighestScore();
        CloseMidiStream();
    }


    void Update()
    {
        if (playing)
        {   if (myMidiInOut.midiFilePlayer.MPTK_TickCurrent != myMidiInOut.midiFilePlayer.MPTK_TickLast)
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
    }
}