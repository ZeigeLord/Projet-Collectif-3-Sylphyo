using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class MidiSend : MonoBehaviour
{
    public int indexOutput;
    // Start is called before the first frame update
    void Start()
    {
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenOut(indexOutput);
    }

    public void SendEvent(MPTKEvent midiEvent)
    {
        Debug.Log("Im sending a  " + midiEvent.Command + " to MIDI Output " + indexOutput);
        MidiKeyboard.MPTK_PlayEvent(midiEvent, indexOutput);
    }
}
