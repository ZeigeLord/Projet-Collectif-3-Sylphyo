using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class Tutorial : MonoBehaviour
{
    //Nuances, Attaques, Shake vibrato, Slider, Tangage, Roulis, Mode Mouvement
    bool isFinished = false;

    public void LaunchTutorial()
    {
        MidiReader tutorialMidiReader;
        tutorialMidiReader = new MidiReader()
        {
            playMode = false,
            exerciceMode = false,
            tutoMode = true
        };
        tutorialMidiReader.LaunchReading();
        Process(tutorialMidiReader);
    }

    public bool IsCorrect(MPTKEvent _midiEvent, int _referenceValue)
    {
        if (_midiEvent.Value >= _referenceValue - 15 && _midiEvent.Value <= _referenceValue + 15)
            return true;
        return false;
    }

    public void Process(MidiReader _tutorialMidiReader)
    {
        int level = 1;
        float timer = 60.0f;
        int referenceValue = 50;
        int successCounter = 0;

        while (_tutorialMidiReader.inputMidiEvent == null)
        {
            continue;
        }
        Debug.Log("Début tuto");
        
        do
        {
            do
            {   //update reference slider's value
                Debug.Log("Level 1");
                while (timer > 0.0f)
                {
                    if (IsCorrect(_tutorialMidiReader.inputMidiEvent, referenceValue))
                    {
                        Debug.Log("Reference testing");
                        timer -= Time.deltaTime;
                    }
                    else
                        //timer = 3.0f;
                    //update player slider's value
                    timer -= Time.deltaTime; //cette ligne est là pour qu'il sorte de la boucle pour éviter de planter, il faudra l'enver à terme
                }
                level++;
            } while (level == 1);

            timer = 60.0f;
            referenceValue = 100;

            do
            {
                Debug.Log("Level 2");
                //update reference slider's value
                while (timer > 0.0f)
                {
                    if (IsCorrect(_tutorialMidiReader.inputMidiEvent, referenceValue))
                    {
                        timer -= Time.deltaTime;
                    }
                    else
                        //timer = 3.0f;
                        //update player slider's value
                    timer -= Time.deltaTime;//cette ligne est là pour qu'il sorte de la boucle pour éviter de planter, il faudra l'enver à terme
                }
                level++;
            } while (level == 2);

            timer = 60.0f;
            referenceValue = 20;

            do
            {
                Debug.Log("Level 3");
                //update reference slider's value
                while (timer > 0.0f)
                {
                    if (IsCorrect(_tutorialMidiReader.inputMidiEvent, referenceValue))
                    {
                        timer -= Time.deltaTime;
                    }
                    else
                        //timer = 3.0f;
                        //update player slider's value
                    timer -= Time.deltaTime;//cette ligne est là pour qu'il sorte de la boucle pour éviter de planter, il faudra l'enver à terme
                }
                level++;
            } while (level == 3);

            referenceValue = 0;
            /*
            do
            {
                Debug.Log("Level 4");
                //update reference slider's value
                while (timer < 60.0f)
                {
                    if (IsCorrect(_tutorialMidiReader.inputMidiEvent, referenceValue))
                        successCounter++;
                    referenceValue++;
                    //update reference slider's value
                    //update player slider's value
                    timer += 20 * Time.deltaTime;
                }
                if (successCounter > referenceValue - 15)
                    level++;
                level++;//cette ligne est là pour qu'il sorte de la boucle pour éviter de planter, il faudra l'enver à terme
            } while (level == 4);
            */

            isFinished = true;
        } while (isFinished == false);
             
    }
}