using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Nuance : Tutoriel
{
    public Slider referenceSlider, playerSlider;
    public Text textField;
    public float[] valeurs = new float[] {25, 56, 120};
    private int myInt;
    bool crescendo;
    public MidiInOut midiInOut;
    public MidiFilePlayer midiFilePlayer;
    public string fileName;
    public int indexOutput;
    public MPTKEvent inputMidiEvent = null;
    
    void Start()
    {
        referenceSlider.GetComponent<Slider>();
        playerSlider.GetComponent<Slider>();
        textField.GetComponent<Text>();
        midiInOut.GetComponent<MidiInOut>();
        MidiInOut midiInOut = new MidiInOut(midiFile, file, index, input);
        myInt = 1;
        referenceSlider.value = valeurs[0];
    }

    // Update is called once per frame
    void Update()
    {
        referenceSlider.GetComponent<Slider>();
        playerSlider.GetComponent<Slider>();
        textField.GetComponent<Text>();
        midiInOut.GetComponent<MidiInOut>();
        MidiInOut midiInOut = new MidiInOut(midiFile, file, index, input);
    }

    public void ChangeValue()
    {

    }

    public void Message_good()
    {

            
    }

        
}