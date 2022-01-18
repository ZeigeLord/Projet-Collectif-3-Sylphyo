using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiPlayerTK;

public class Attaques : Tutorial
{
    public MidiInOut midiInOut;
    public MidiFilePlayer midiFile;
    public string file;
    public int index;
    public MPTKEvent input = null;
    public Tutorial tutorial;
    
    void Start()
    {
        //midiInOut.GetComponent<MidiInOut>();
        //MidiInOut midiInOut = new MidiInOut(midiFile, index, input);
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