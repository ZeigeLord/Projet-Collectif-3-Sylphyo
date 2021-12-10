using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class ExpressionTutorial : MonoBehaviour
{
    //Nuances, Attaques, Shake vibrato, Slider, Tangage, Roulis, Mode Mouvement
    public int referenceValue = 50;
    bool isFinished = false;

    public void LaunchTutorial()
    {
        MidiReader tutorialMidiReader;
        tutorialMidiReader = new MidiReader()
        {
            playMode = false,
            exerciceMode = false,
            tutoMode = true,
        };

        tutorialMidiReader.LaunchReading();
        Process(tutorialMidiReader);
    }

    public void Process (MidiReader tutorialMidiReader)
    {
        int level = 1;
        while (isFinished == false)
        {
            while (level == 1)
            {
                if (tutorialMidiReader.inputMidiEvent.Value >= referenceValue-15 && tutorialMidiReader.inputMidiEvent.Value <= referenceValue +15)
                {

                }
            }
        }
    }
}
