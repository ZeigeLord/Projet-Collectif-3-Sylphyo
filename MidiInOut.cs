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
    public int[] pitchHistory = new int[500];


    ////////////////METHODS////////////////

    // File Playing //

    public void SetFile(int exerciceId)
    {
        switch (exerciceId)
        {
            case 1:
                midiFilePlayer.MPTK_MidiName = "ex_1_1";
                break;
            case 2:
                midiFilePlayer.MPTK_MidiName = "ex_1_2";
                break;
            case 3:
                midiFilePlayer.MPTK_MidiName = "ex_1_3";
                break;
            case 4:
                midiFilePlayer.MPTK_MidiName = "ex_1_4";
                break;
            case 5:
                midiFilePlayer.MPTK_MidiName = "ex_2_1_1";
                break;
            case 6:
                midiFilePlayer.MPTK_MidiName = "ex_2_1_2";
                break;
            case 7:
                midiFilePlayer.MPTK_MidiName = "ex_2_1_3";
                break;
            case 8:
                midiFilePlayer.MPTK_MidiName = "ex_2_2_1";
                break;
            case 9:
                midiFilePlayer.MPTK_MidiName = "ex_2_2_2";
                break;
            case 10:
                midiFilePlayer.MPTK_MidiName = "ex_2_2_3";
                break;
            default:
                break;
        }
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

        Debug.Log(pitch);
        for (int i = pitchHistory.Length - 1; i > 0; i--)
        {
            pitchHistory[i] = pitchHistory[i - 1];
        }
        pitchHistory[0] = pitch;
    }

    public void ReadEvent(MPTKEvent midiEvent)
    {
        inputMidiEvent = midiEvent;
        if (midiEvent.Command != MPTKCommand.NoteOff)
        {
            UpdatePitchHistory(midiEvent.Value);
        }

        if (StartSending() == true)
            SendEvent(midiEvent);
    }

    public void ReadFileEvent()
    {
        Debug.Log("VA BIEN TE FAIRE ENCULER");
        /*midiFilePlayer.MPTK_MidiName = "seq_sc";
        PlayFile();
        MPTKEvent midiEvent;
        midiEvent = GetCurrentEvent();
        if (midiEvent.Command != MPTKCommand.NoteOff)
        {
            UpdatePitchHistory(midiEvent.Value);       
        }*/
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