using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class GraphicInterface : MonoBehaviour
{
    /// <summary>
    /// Processes graphic interface
    /// <summary>

    ////////////////MEMBERS////////////////

    public MidiInOut midiInOut;
    //public CircularBuffer cicleBuffer;
    public MidiFilePlayer midiFilePlayer;
    public int indexOutput;
    public MPTKEvent inputMidiEvent = null;
    public int[] pitchHistory = new int[500];
    //CircularBuffer<T> queue = new CircularBuffer<T>(500);
    //midiInOut.Process();


    ////////////////METHODS////////////////

    public void StartReading()
    {
        MidiKeyboard.MPTK_Init();
        MidiKeyboard.MPTK_OpenAllInp();
        MidiKeyboard.OnActionInputMidi += ReadEvent;
        MidiKeyboard.MPTK_SetRealTimeRead();
    }

    void UpdatePitchHistory(int pitch)
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
        //if (StartSending() == true)
            //SendEvent(midiEvent);
    }

   /* public void ReadFileEvent(MPTKEvent midiEvent, int exerciceId)
    {
        inputMidiEvent = midiEvent;
        if (midiEvent.Command != MPTKCommand.NoteOff)
        {
            switch (exerciceId)
            {
                case 1:
                    midiFilePlayer.MPTK_MidiName = "F:\Asset\Script\MidiFile\Vocalise1.mid";
                    break;
                case 2:
                    midiFilePlayer.MPTK_MidiName = "F:\Asset\Script\MidiFile\Vocalise1.mid"";
                    break;
                case 3:
                    midiFilePlayer.MPTK_MidiName = "F:\Asset\Script\MidiFile\Vocalise1.mid"";
                    break;
                case 4:
                    midiFilePlayer.MPTK_MidiName = "F:\Asset\Script\MidiFile\Vocalise1.mid";
                    break;
            }
        }
        if (StartSending() == true)
            SendEvent(midiEvent);
    }*/


}
