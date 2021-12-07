using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;


public class MidiReader : MonoBehaviour
{

    /// <summary>
    /// Reads in real time MIDI infos sent by all MIDI controllers
    /// Sends the information to the selected MIDI output
    /// /!\ LATENCY PROBLEMS WITH INTEGRATED OUTPUT : NEED TO CHECK WITH SYLHPYO LINK
    /// </summary>


    public int indexOutput;

    void Start()
    {
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenOut(indexOutput);
        MidiKeyboard.MPTK_OpenAllInp();

        MidiKeyboard.OnActionInputMidi += ProcessEvent;
        MidiKeyboard.MPTK_SetRealTimeRead();
    }

    private void ProcessEvent(MPTKEvent midiEvent)
    {
        Debug.Log("Note :" + midiEvent.Value + " - Velocity : " + midiEvent.Velocity);
        MidiKeyboard.MPTK_PlayEvent(midiEvent, indexOutput);
    }

    private void OnApplicationQuit()
    {
        MidiKeyboard.MPTK_UnsetRealTimeRead();
        MidiKeyboard.MPTK_CloseAllInp();
    }
}

