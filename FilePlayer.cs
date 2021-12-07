using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class FilePlayer : MonoBehaviour
{

    /// <summary>
    /// Allows to play a MIDI file, using the MidiFilePlayer Prefab
    /// Can play only one file at a time
    /// decreaseTempo and increaseTempo change the speed reading of the file
    /// Add more MidiFilePlayer Prefabs to play several files simultaneously
    /// Enter the corresponding Prefab and file name in Unity editor
    /// </summary>


    public MidiFilePlayer midiFilePlayer;
    public string fileName;

    private void Start()
    {
        midiFilePlayer.MPTK_PlayOnStart = false; //useless
    }

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
}