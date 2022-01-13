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


    ////////////////METHODS////////////////

    // File Playing //

    public void SetFile(int level, int typeId, int exerciceId)
    {
        switch(level)
        {
            case 1:
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
                    default:
                        break;
                }
                break;
            case 2:
                switch (typeId)
                {
                    case 1:
                        switch (exerciceId)
                        {
                            case 1:
                                midiFilePlayer.MPTK_MidiName = "ex_2_1_1";
                                break;
                            case 2:
                                midiFilePlayer.MPTK_MidiName = "ex_2_1_2";
                                break;
                            case 3:
                                midiFilePlayer.MPTK_MidiName = "ex_2_1_3";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 2:
                        switch (exerciceId)
                        {
                            case 1:
                                midiFilePlayer.MPTK_MidiName = "ex_2_2_1";
                                break;
                            case 2:
                                midiFilePlayer.MPTK_MidiName = "ex_2_2_2";
                                break;
                            case 3:
                                midiFilePlayer.MPTK_MidiName = "ex_2_2_3";
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
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

    public MPTKEvent GetEvent()
    {
        return midiFilePlayer.MPTK_LastEventPlayed;
    }


    // Event Reading //

    public void StartReading()
    {
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenAllInp();
        MidiKeyboard.OnActionInputMidi += ReadEvent;
        MidiKeyboard.MPTK_SetRealTimeRead();
    }

    public void ReadEvent(MPTKEvent midiEvent)
    {
        inputMidiEvent = midiEvent;
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