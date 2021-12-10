using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class MidiReader : MonoBehaviour
{
    /// <summary>
    /// Reads in real time MIDI infos sent by all MIDI controllers
    /// </summary>

    public int indexOutput;
    public bool playMode = false;
    public bool exerciceMode = false;
    public bool tutoMode = false;
    public MPTKEvent inputMidiEvent = null;
    MidiSend playSender;

    void Start()
    {
        playSender = gameObject.AddComponent<MidiSend>();
        playSender.indexOutput = indexOutput;
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenAllInp();
        MidiKeyboard.OnActionInputMidi += ReadEvent;
        MidiKeyboard.MPTK_SetRealTimeRead();
    }

    public void LaunchReading()
    {
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenAllInp();
        MidiKeyboard.OnActionInputMidi += ReadEvent;
        MidiKeyboard.MPTK_SetRealTimeRead();      
    }

    public void ReadEvent(MPTKEvent midiEvent)
    {
        Debug.Log("Im reading a  " + midiEvent.Command + " of Controller " + midiEvent.Controller + " of Value" + midiEvent.Value);

        if(playMode)
        {
            Debug.Log("Play Mode");
            playSender.SendEvent(midiEvent);
        }

        else if(tutoMode)
        {
            Debug.Log("Tuto Mode");
            inputMidiEvent = midiEvent;
        }

        else if(exerciceMode)
        {
            Debug.Log("Exercice Mode");
            inputMidiEvent = midiEvent;
        }
    }

    public void StopReading()
    {
        playMode = false;
        exerciceMode = false;
        tutoMode = false;
        inputMidiEvent = null;
        MidiKeyboard.MPTK_UnsetRealTimeRead();
        MidiKeyboard.MPTK_CloseAllInp();
    }


    private void OnApplicationQuit()
    {
        MidiKeyboard.MPTK_UnsetRealTimeRead();
        MidiKeyboard.MPTK_CloseAllInp();
    }
}