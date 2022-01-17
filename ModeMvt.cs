using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiPlayerTK;


public class ModeMvt : Tutorial
{
    public Tutorial tutorial;
    public MidiInOut midiInOut;
    //public MidiFilePlayer midiFilePlayer;
    //public string fileName;
    //public int indexOutput;
    //public MPTKEvent inputMidiEvent = null;
    
    void Start()
    {
        //midiInOut.GetComponent<MidiInOut>();
        //MidiInOut midiInOut = new MidiInOut(midiFile, file, index, input);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeValue()
    {

    }

    public void Message_good()
    {

            
    }
    public void Process()
    {
        ChangeValue();
        Message_good();
    }

        
}