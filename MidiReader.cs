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

    public void LaunchReading()
    {
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenAllInp();
        MidiKeyboard.OnActionInputMidi += ReadEvent;
        MidiKeyboard.MPTK_SetRealTimeRead();      
    }

    public void ReadEvent(MPTKEvent midiEvent)
    {
        Debug.Log("Im reading a  " + midiEvent.Command);

        if(playMode)
        {
            Debug.Log("Play Mode");
            MidiSend play;
            play = new MidiSend();
            play.indexOutput = indexOutput;
            play.SendEvent(midiEvent);
        }

        else if(tutoMode)
        {
            Debug.Log("Tuto Mode");
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