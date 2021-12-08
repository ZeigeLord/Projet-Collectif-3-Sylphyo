using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class Exercice : MonoBehaviour
{
    public FilePlayer backingTrack;
    public string backingTrackName;
   
    // Start is called before the first frame update
    void Start()
    {
        backingTrack.fileName = backingTrackName;
    }

    public void LaunchExercice()
    {
        backingTrack.playFile();
        //process
    }

    public void DisplayInstructions()
    {
        //shows the player what he has to do
        //input : exercice data
        //output : graphic
    }

    public void DisplayVisualFeedback()
    {
        //shows the player what he is doing on the Sylhpyo model
        //input : midiEvent
        //output : graphic
    }

    public void VerifyCorrectness()
    {
        //verifies if the player is doing the right thing
        //input : midiEvent + exercice data
        //output : bool + graphic
    }
}
