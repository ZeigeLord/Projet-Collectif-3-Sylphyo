using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class MidiSend : MonoBehaviour
{
    public int indexOutput;

    public void LaunchSending()
    {
        MidiKeyboard.MPTK_OpenOut(indexOutput);
    }

    public void SendEvent(MPTKEvent midiEvent)
    {
        Debug.Log("Im sending a  " + midiEvent.Command + " to MIDI Output " + indexOutput);
        MidiKeyboard.MPTK_PlayEvent(midiEvent, indexOutput);
    }

    public void StopSending()
    {
        MidiKeyboard.MPTK_CloseOut(indexOutput);
    }
}
