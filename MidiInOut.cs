using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class MidiInOut : MonoBehaviour
{
    /// <summary>
    /// Manages MIDI stream
    /// <summary>


    ////////////////MEMBERS////////////////

    public MidiFilePlayer midiFilePlayer;
    public int indexOutput;
    public MPTKEvent inputMidiEvent = null;
    public MPTKEvent inputMidiFileEvent = null;
    public int[] pitchHistory = new int[500];
    public int[] filePitchHistory = new int[500];
    public int indexDistance;


    ////////////////METHODS////////////////

    // File Playing //

    public void SetFile(int exerciceId)
    {
        switch (exerciceId)
        {
            case 1:
                midiFilePlayer.MPTK_MidiName = "Exo 1 MIDI";
                break;
            case 2:
                midiFilePlayer.MPTK_MidiName = "Exo 2 MIDI";
                break;
            case 3:
                midiFilePlayer.MPTK_MidiName = "Octave Ex 1";
                break;
            case 4:
                midiFilePlayer.MPTK_MidiName = "Octave Ex 2";
                break;
            case 5:
                midiFilePlayer.MPTK_MidiName = "Octave Ex3 (chromatique)";
                break;
            case 6:
                midiFilePlayer.MPTK_MidiName = "intervalles Ex 1";
                break;
            case 7:
                midiFilePlayer.MPTK_MidiName = "intervalles Ex 2";
                break;
            case 8:
                midiFilePlayer.MPTK_MidiName = "intervallez Ex 3";
                break;
            case 9:
                midiFilePlayer.MPTK_MidiName = "intervalles Ex 4";
                break;
            case 10:
                midiFilePlayer.MPTK_MidiName = "";
                break;
            case 11:
                midiFilePlayer.MPTK_MidiName = "";
                break;
            default:
                break;
        }
        midiFilePlayer.OnEventEndPlayMidi.AddListener(EndPlay);
        midiFilePlayer.OnEventNotesMidi.AddListener(MidiReadEvents);
    }

    public void PlayFile()
    {
        midiFilePlayer.MPTK_Play();
    }

    public void DecreaseTempo()
    {
        midiFilePlayer.MPTK_Speed -= 0.1f;
    }

    public void InscreaseTempo()
    {
        midiFilePlayer.MPTK_Speed += 0.1f;
    }

    public MPTKEvent GetCurrentEvent()
    {
        return midiFilePlayer.MPTK_LastEventPlayed;
    }

    public List<MPTKEvent> GetAllEvents()
    {
        return midiFilePlayer.MPTK_ReadMidiEvents();
    }

    public MPTKEvent[] GetNoteOnEvents()
    {
        List<MPTKEvent> noteOnEvents = new List<MPTKEvent>();
        foreach (MPTKEvent midiEvent in GetAllEvents())
        {
            if (midiEvent.Command == MPTKCommand.NoteOn)
                noteOnEvents.Add(midiEvent);
        }
        return noteOnEvents.ToArray();
    }

    public double GetTime()
    {
        return midiFilePlayer.MPTK_Position;
    }

    public void UpdateFilePitchHistory(int pitch)
    {
        for (int i = filePitchHistory.Length - 1; i > 0; i--)
        {
            filePitchHistory[i] = filePitchHistory[i - 1];
        }
        filePitchHistory[0] = pitch;
    }

    public void MidiReadEvents(List<MPTKEvent> events)
    {
        foreach (MPTKEvent midiEvent in events)
        {
            if (midiEvent.Command == MPTKCommand.NoteOn)
                UpdateFilePitchHistory(midiEvent.Value);
        }

        if (midiFilePlayer.MPTK_DeltaTicksPerQuarterNote != 0)
        {
            indexDistance = (int)midiFilePlayer.MPTK_TickCurrent / (3 * midiFilePlayer.MPTK_DeltaTicksPerQuarterNote);
        }
    }

    public void EndPlay(string midiname, EventEndMidiEnum reason)
    {
        Debug.LogFormat("End playing {0} reason:{1}", midiname, reason);
    }


    // Event Reading //

    public void StartReading()
    {
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenAllInp();
        MidiKeyboard.OnActionInputMidi += ReadEvent;
        MidiKeyboard.MPTK_SetRealTimeRead();
    }

    public void UpdatePitchHistory(int pitch)
    {
        for (int i = pitchHistory.Length - 1; i > 0; i--)
        {
            pitchHistory[i] = pitchHistory[i - 1];
        }
        pitchHistory[0] = pitch;
    }

    public void ReadEvent(MPTKEvent midiEvent)
    {
        inputMidiEvent = midiEvent;
        if (midiEvent.Command == MPTKCommand.NoteOn)
            UpdatePitchHistory(midiEvent.Value);
        if (StartSending() == true)
            SendEvent(midiEvent);
    }

    public void StopReading()
    {
        MidiKeyboard.MPTK_UnsetRealTimeRead();
        MidiKeyboard.MPTK_CloseAllInp();
    }


    // Event Sending

    public bool StartSending()
    {
        MidiKeyboard.MPTK_OpenOut(indexOutput);
        return true;
    }

    public void SendEvent(MPTKEvent midiEvent)
    {
        MidiKeyboard.MPTK_PlayEvent(midiEvent, indexOutput);
    }

    public void StopSending()
    {
        MidiKeyboard.MPTK_CloseOut(indexOutput);
    }

    public void ChangeSound(int soundIndex)
    {
        if (soundIndex <= 33)
        {
            MPTKEvent changeSound;
            changeSound = new MPTKEvent()
            {
                Command = MPTKCommand.PatchChange,
                Value = soundIndex,
            };
            SendEvent(changeSound);
        }

        else
            Debug.Log("Error : Only 34 sounds available");
    }


    // Application Processing

    private void OnApplicationQuit()
    {
        StopReading();
        StopSending();
    }
}