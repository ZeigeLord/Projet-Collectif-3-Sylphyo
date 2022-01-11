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
    public string fileName;
    public int indexOutput;
    public MPTKEvent inputMidiEvent = null;



    ////////////////METHODS////////////////

    // File Playing //

    public void playFile()
    {
        midiFilePlayer.MPTK_MidiName = fileName;
        midiFilePlayer.MPTK_Play();
    }

    public void decreaseTempo()
    {
        midiFilePlayer.MPTK_Speed -= 0.1f;
    }

    public void inscreaseTempo()
    {
        midiFilePlayer.MPTK_Speed += 0.1f;
    }


    // Event Reading //

    public void LaunchReading()
    {
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenAllInp();
        MidiKeyboard.OnActionInputMidi += ReadEvent;
        MidiKeyboard.MPTK_SetRealTimeRead();
    }

    public void ReadEvent(MPTKEvent midiEvent)
    {
        inputMidiEvent = midiEvent;
    }

    public void StopReading()
    {
        MidiKeyboard.MPTK_UnsetRealTimeRead();
        MidiKeyboard.MPTK_CloseAllInp();
    }


    // Event Sending

    public void LaunchSending()
    {
        MidiKeyboard.MPTK_OpenOut(indexOutput);
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
        MidiKeyboard.MPTK_UnsetRealTimeRead();
        MidiKeyboard.MPTK_CloseAllInp();
    }

}
