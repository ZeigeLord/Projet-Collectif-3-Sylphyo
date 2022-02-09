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
    public string instrumentChosen;

    
    public Image note1, note2, note3, note4, note5, note6, note7, note8, myImageOctave;
    public Sprite octaveM3, octaveM2, octaveM1, octave0, octaveP1;
    public Image[] tabImage;
    public bool[] tabImageShouldUpdate;
    private bool M3, M2, M1, P1, oct0;


    void Start()
    {
        instrumentChosen = "fluteabec";
        tabImage = new Image[9];
        tabImageShouldUpdate = new bool[9];
        tabImage[0] = myImageOctave;
        tabImage[1] = note1;
        tabImage[2] = note2;
        tabImage[3] = note3;
        tabImage[4] = note4;
        tabImage[5] = note5;
        tabImage[6] = note6;
        tabImage[7] = note7;
        tabImage[8] = note8;
        for (int i = 0; i < 9; i++)
            tabImage[i].enabled = false;
        myInstrumentData = new InstrumentData(instrumentChosen);
        AssignFingeringChart(instrumentChosen);
    }

    private void Update()
    {
        if (M3)
            myImageOctave.sprite = octaveM3;
        else if (M2)
            myImageOctave.sprite = octaveM2;
        else if (M1)
            myImageOctave.sprite = octaveM1;
        else if (oct0)
            myImageOctave.sprite = octave0;
        else if (P1)
            myImageOctave.sprite = octaveP1;
        for (int i = 0; i < 9; i++)
        {
            tabImage[i].enabled = tabImageShouldUpdate[i];
        }
    }

    private void AssignFingeringChart(string instrument)
    {
        myInstrumentData.AssignFingeringChart(instrument);
    }

    public void ShowFingering(int midiValue)
    {
        int[] fingeringCurrent = myInstrumentData.MidiToFingering(midiValue);

        if (fingeringCurrent[0] == 0)
            tabImageShouldUpdate[0] = false;

        else if (fingeringCurrent[0] == 1)
        {
            tabImageShouldUpdate[0] = true;
            M3 = true;
            M2 = false;
            M1 = false;
            P1 = false;
            oct0 = false;
        }

        else if (fingeringCurrent[0] == 2)
        {
            tabImageShouldUpdate[0] = true;
            M2 = true;
            M3 = false;
            M1 = false;
            P1 = false;
            oct0 = false;
        }

        else if (fingeringCurrent[0] == 3)
        {
            tabImageShouldUpdate[0] = true;
            M1 = true;
            M2 = false;
            M3 = false;
            P1 = false;
            oct0 = false;
        }

        else if (fingeringCurrent[0] == 4)
        {
            tabImageShouldUpdate[0] = true;
            oct0 = true;
            P1 = false;
            M1 = false;
            M2 = false;
            M3 = false;
        }

        else if (fingeringCurrent[0] == 5)
        {
            tabImageShouldUpdate[0] = true;
            P1 = true;
            oct0 = false;
            M1 = false;
            M2 = false;
            M3 = false;
        }


        for (int index = 1; index < 9; index++)
        {
            if (fingeringCurrent[index] == 1)
            {
                tabImageShouldUpdate[index] = true;
            }
            else
            {
                tabImageShouldUpdate[index] = false;
                
            }
        }
    }
}
