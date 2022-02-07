using System.Collections;
using System.Collections.Generic;
using System;
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
    public bool playing = true;
    public int value;


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
                midiFilePlayer.MPTK_MidiName = "Exo 3 MIDI";
                break;
            case 4:
                midiFilePlayer.MPTK_MidiName = "Octave Ex 1";
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
                midiFilePlayer.MPTK_MidiName = "gamme Dm (4 octaves)";
                break;
            case 11:
                midiFilePlayer.MPTK_MidiName = "intervalles Ex 1";
                break;
            case 12:
                midiFilePlayer.MPTK_MidiName = "intervalles Ex 2";
                break;
            case 13:
                midiFilePlayer.MPTK_MidiName = "intervallez Ex 3";
                break;
            case 14:
                midiFilePlayer.MPTK_MidiName = "intervalles Ex 4";
                break;
            case 15:
                midiFilePlayer.MPTK_MidiName = "exo1 roulis Classic SineTri";
                break;
            case 16:
                midiFilePlayer.MPTK_MidiName = "Exo_2_roulis_Big_Blue";
                break;
            case 17:
                midiFilePlayer.MPTK_MidiName = "exo_3_roulis_Resozen";
                break;
            case 18:
                midiFilePlayer.MPTK_MidiName = "exercice_simple_bend";
                break;
            case 19:
                midiFilePlayer.MPTK_MidiName = "Exercice Bend";
                break;
            case 20:
                midiFilePlayer.MPTK_MidiName = "Exercice_braveheart";
                break;
            case 21:
                midiFilePlayer.MPTK_MidiName = "Exercice_de_départ";
                break;
            case 22:
                midiFilePlayer.MPTK_MidiName = "ex2";
                break;
            case 23:
                midiFilePlayer.MPTK_MidiName = "ex3";
                break;
            case 24:
                midiFilePlayer.MPTK_MidiName = "Exercices_house_of_chords";
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

    public int GetTimeSigNumerator()
    {
        return midiFilePlayer.midiLoaded.MPTK_TimeSigNumerator;
    }

    public int GetTimeSigDenominator()
    {
        return midiFilePlayer.midiLoaded.MPTK_TimeSigDenominator;
    }

    public double GetReferenceDuration()
    {
        foreach (MPTKEvent midiEvent in GetNoteOnEvents())
        {
            if (midiFilePlayer.MPTK_NoteLength(midiEvent) == MPTKEvent.EnumLength.Quarter)
            {
                switch (GetTimeSigDenominator())
                {
                    case 1:
                        return midiEvent.Duration * 2.0;
                    case 2:
                        return midiEvent.Duration;
                    case 3:
                        if (midiEvent.Duration % 2 != 0)
                            return (midiEvent.Duration / 2) + 1;
                        return midiEvent.Duration / 2;
                    default:
                        return -1;
                }
            }
            else if (midiFilePlayer.MPTK_NoteLength(midiEvent) == MPTKEvent.EnumLength.Half)
            {
                switch (GetTimeSigDenominator())
                {
                    case 1:
                        return midiEvent.Duration;
                    case 2:
                        if (midiEvent.Duration % 2 != 0)
                            return (midiEvent.Duration / 2) + 1;
                        return midiEvent.Duration / 2;
                    case 3:
                        if (midiEvent.Duration % 2 != 0)
                            return (midiEvent.Duration / 4) + 1;
                        return midiEvent.Duration / 4;
                    default:
                        return -1;
                }
            }
            else if (midiFilePlayer.MPTK_NoteLength(midiEvent) == MPTKEvent.EnumLength.Eighth)
            {
                switch (GetTimeSigDenominator())
                {
                    case 1:
                        return midiEvent.Duration * 4.0;
                    case 2:
                        return midiEvent.Duration * 2.0;
                    case 3:
                        return midiEvent.Duration;
                    default:
                        return -1;
                }
            }
        }
        return -1;
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
        {
            playing = true;
            value = midiEvent.Value;
            UpdatePitchHistory(midiEvent.Value);
        }

        else if (midiEvent.Command == MPTKCommand.NoteOff && midiEvent.Value == value)
            playing = false;

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