using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class Exercice : MonoBehaviour
{
    /// <summary>
    /// this class contains all methods relative to the exercices of the application
    /// subclasses refer to the corresponding type of exercices
    /// </summary>

    float mistakesCounter=0;
    bool exerciceSucceeded = false;
    float successReference = 0;
    float successRate = 0;
    float successLimit = 60;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void LaunchExercice()
    {
        MidiReader exerciceMidiReader;
        exerciceMidiReader = new MidiReader();
        exerciceMidiReader.playMode = false;
        exerciceMidiReader.exerciceMode = true;
        exerciceMidiReader.LaunchReading();
        Process(exerciceMidiReader);
    }

    public void DisplayInstructions()
    {
        //shows the player what he has to do
        //input : exercice data
        //output : graphic
    }

    public void DisplayVisualFeedback(MPTKEvent midiEvent)
    {
        //shows the player what he is doing on the Sylhpyo model
        //input : midiEvent
        //output : graphic
    }

    public bool IsCorrect(MPTKEvent midiEvent, MPTKEvent tester)
    {
        //verifies if the player is doing the right thing
        //input : midiEvent + exercice data
        //output : bool + graphic
        return false;
    }

    public void Process(MidiReader exerciceMidiReader)
    {
        //while exercice isnt finished
        {
            while (exerciceMidiReader.inputMidiEvent == null)
            {
                continue;
            }

            Debug.Log("Début entrée MIDI");
            DisplayVisualFeedback(exerciceMidiReader.inputMidiEvent);
            if (IsCorrect(exerciceMidiReader.inputMidiEvent, exerciceMidiReader.inputMidiEvent) == false) //to be modified
            {
                mistakesCounter++;
                DisplayVisualFeedback(exerciceMidiReader.inputMidiEvent); //to be modified
            }
            else
                DisplayVisualFeedback(exerciceMidiReader.inputMidiEvent); //to be modified
            successReference++;
        }

        //when exercice is finished
        successRate = ((successReference- mistakesCounter) / successReference) * 100;

        if (successRate >= successLimit)
        {
            Debug.Log("You win");
            exerciceSucceeded = true;
        }
        else
            Debug.Log("You lose");

        exerciceMidiReader.StopReading();
    }
}
