using System.Collections;
using System.Collections.Generic;
//using System.IO;
//using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using MidiPlayerTK;

public class Doigte : MonoBehaviour
{
    public InstrumentData myInstrumentData;
    public TestMidi myMidiTest;
    public string instrumentChosen;
    public int[] fingeringCurrent;
    
    public Image note1, note2, note3, note4, note5, note6, note7, note8, myImageOctave;
    public Sprite octaveM3, octaveM2, octaveM1, octave0, octaveP1;
    int index;
    int ind;
    Image[] tabImage = new Image[9];
    
    // Start is called before the first frame update
    public Doigte()
    {
        myInstrumentData.AssignFingeringChart(instrumentChosen);

        tabImage[1] = note1;
        tabImage[2] = note2;
        tabImage[3] = note3;
        tabImage[4] = note4;
        tabImage[5] = note5;
        tabImage[6] = note6;
        tabImage[7] = note7;
        tabImage[8] = note8;
    }

    // Update is called once per frame
    public void UpdateUI(MPTKEvent midiEvent)
    {
        fingeringCurrent = myInstrumentData.MidiToFingering(midiEvent);
        ShowFingering();
        ChangeOctave();
    }

    public void ShowFingering()
    {
        for (index = 1; index < 9; index++)
        {
            if (fingeringCurrent[index] == 1)
            {
                tabImage[index].enabled = true;
            }
            else
                tabImage[index].enabled = false;
        }
    }

    public void ChangeOctave()
    {
        switch (fingeringCurrent[0])
        {
            case 0:
                myImageOctave.enabled = true;
                break;
            case 1:
                myImageOctave.transform.position = new Vector2(-317, 120);
                myImageOctave.sprite = octaveM3;
                break;
            case 2:
                myImageOctave.transform.position = new Vector2(-317, 120);
                myImageOctave.sprite = octaveM2;
                break;
            case 3:
                myImageOctave.transform.position = new Vector2(-317, 120);
                myImageOctave.sprite = octaveM1;
                break;
            case 4:
                myImageOctave.transform.position = new Vector2(-317, 120);
                myImageOctave.sprite = octave0;
                break;
            case 5:
                myImageOctave.transform.position = new Vector2(-317, 120);
                myImageOctave.sprite = octaveP1;
                break;
            default:
                break;
        }
    }
}
