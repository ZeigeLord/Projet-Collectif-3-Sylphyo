using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class MyMidiInOut : MonoBehaviour
{
    public InputInt InputNote;
    public int indexOutput = 1;
    // Start is called before the first frame update
    void Start()
    {
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenOut(indexOutput);
        MidiKeyboard.MPTK_OpenAllInp();

        MidiKeyboard.OnActionInputMidi += ProcessEvent;
        MidiKeyboard.MPTK_SetRealTimeRead();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnApplicationQuit()
    {
        MidiKeyboard.MPTK_UnsetRealTimeRead();
        MidiKeyboard.MPTK_CloseAllInp();

    }

    public void PlayOneNote(MPTKEvent midiEvent, int device )
    {
        device = indexOutput;
        MidiKeyboard.MPTK_PlayEvent(midiEvent, device);
        Debug.Log("Im playing a note " + midiEvent.Value);
        midiEvent.Command = MPTKCommand.NoteOn;
        midiEvent.Velocity = 0;
        midiEvent.Delay = 2000;
        MidiKeyboard.MPTK_PlayEvent(midiEvent, device);

        Debug.Log("Im at the end of PlayOneNote");
    }
    
    /*
    public void PlayOneNote()
    {
        MPTKEvent midiEvent;
        // playing a NoteOn
        midiEvent = new MPTKEvent()
        {

            Command = MPTKCommand.NoteOn,
            Value = 64,
            Channel = 1,
            Velocity = 64,
            Delay = 0,
        };
        MidiKeyboard.MPTK_PlayEvent(midiEvent, indexOutput);
        // Send Notoff with a delay of 2 seconds
        midiEvent = new MPTKEvent()
        {
            Command = MPTKCommand.NoteOff,
            Value = 64,
            Channel = 1,
            Velocity = 0,
            Delay = 2000,
        };
        MidiKeyboard.MPTK_PlayEvent(midiEvent, indexOutput);
    }*/

    
    private void ProcessEvent(MPTKEvent midievent)
    {
        Debug.Log("Note :" + midievent.Value + " - Velocity : " + midievent.Velocity);
        
    }
}
