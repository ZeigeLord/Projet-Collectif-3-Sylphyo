using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class TestMidi : MonoBehaviour
{
    public MidiFilePlayer midiFilePlayer;
    public List<MPTKEvent> midiList;

    void Start()
    {
        midiFilePlayer.MPTK_MidiName = "seq_scSlider";
        midiFilePlayer.MPTK_Play();
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
        Debug.Log("Event : "+midiFilePlayer.MPTK_LastEventPlayed.Command + " "+midiFilePlayer.MPTK_LastEventPlayed.Controller + " "+midiFilePlayer.MPTK_LastEventPlayed.Value);
    }

}
