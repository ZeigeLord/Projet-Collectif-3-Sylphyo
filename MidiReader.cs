using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class MidiReader : MonoBehaviour
{
    /// <summary>
    /// Reads in real time MIDI infos sent by all MIDI controllers
    /// </summary>
    /// 
    public int indexOutput;
    public bool playMode;

    void Start()
    {
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenAllInp();
        MidiKeyboard.OnActionInputMidi += ReadEvent;
        MidiKeyboard.MPTK_SetRealTimeRead();
    }

    public void ReadEvent(MPTKEvent midiEvent)
    {
        Debug.Log("Im processing a  " + midiEvent.Command);

        if(playMode)
        {
            Debug.Log("Play Mode");
            MidiSend play;
            play = new MidiSend();
            play.indexOutput = indexOutput;
            play.SendEvent(midiEvent);
        }

        else
        {

        }
    }

    private void OnApplicationQuit()
    {
        MidiKeyboard.MPTK_UnsetRealTimeRead();
        MidiKeyboard.MPTK_CloseAllInp();
    }
}