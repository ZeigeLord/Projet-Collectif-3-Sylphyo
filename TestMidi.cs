using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class TestMidi : MonoBehaviour
{
    public MidiFilePlayer midiFilePlayer;
    public List<MPTKEvent> midiList;
    public int indexOutput;
    public List<MPTKEvent> noteOnEvents;

    void Start()
    {
        midiFilePlayer.MPTK_MidiName = "seq_sc";
        midiFilePlayer.MPTK_Play();
        midiList = midiFilePlayer.MPTK_ReadMidiEvents();
        Debug.Log(midiList.Capacity);
        //ShowMidiEvents();
        noteOnEvents = new List<MPTKEvent>();
        foreach (MPTKEvent midiEvent in midiList)
        {
            if (midiEvent.Command == MPTKCommand.NoteOn)
            {
                noteOnEvents.Add(midiEvent);
            }
        }
        ShowNoteOn();
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenAllInp();
        MidiKeyboard.OnActionInputMidi += ReadEvent;
        MidiKeyboard.MPTK_SetRealTimeRead();
        MidiKeyboard.MPTK_OpenOut(indexOutput);
    }

    void Update()
    {

    }

    public void PlayFile()
    {
        //Debug.Log(midiLoad.MPTK_TickCurrent);
        //midiList = midiLoad.MPTK_ReadMidiEvents();
    }

    public void ShowTick()
    {
        Debug.Log("Event : " + midiFilePlayer.MPTK_LastEventPlayed.Command + " " + midiFilePlayer.MPTK_LastEventPlayed.Controller + " " + midiFilePlayer.MPTK_LastEventPlayed.Value + " " + midiFilePlayer.MPTK_LastEventPlayed.Duration);
    }

    public void ReadEvent(MPTKEvent midiEvent)
    {
        MidiKeyboard.MPTK_PlayEvent(midiEvent, indexOutput);
        if (midiEvent.Command == MPTKCommand.NoteOn)
            Debug.Log(midiEvent.Value);
    }

    public void ShowMidiEvents()
    {
        foreach (MPTKEvent midiEvent in midiList)
        {
            Debug.Log(midiEvent);
        }
    }

    public void ShowNoteOn()
    {
        foreach (MPTKEvent noteOn in noteOnEvents)
        {
            Debug.Log(noteOn);
        }
    }
}

