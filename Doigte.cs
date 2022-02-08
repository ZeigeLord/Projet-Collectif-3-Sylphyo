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
        ChangeOctave(fingeringCurrent);
    }

    public void ChangeOctave(int[] fingeringCurrent)
    {
        //int index = 0;
        // switch (fingeringCurrent[index])
        //{
        if (fingeringCurrent[0] == 0)
            tabImageShouldUpdate[0] = false;
        //break;
        else if (fingeringCurrent[0] == 1)
        {
            //myImageOctave.transform.position = new Vector2(-317, 120);
            myImageOctave.sprite = octaveM3;
            tabImageShouldUpdate[0] = true;

        }
        // break;
        else if (fingeringCurrent[0] == 2)
        {
            // myImageOctave.transform.position = new Vector2(-317, 120);
            myImageOctave.sprite = octaveM2;
            tabImageShouldUpdate[0] = true;
        }
        //break;
        else if (fingeringCurrent[0] == 3)
        {
            //myImageOctave.transform.position = new Vector2(-317, 120);
            myImageOctave.sprite = octaveM1;
            tabImageShouldUpdate[0] = true;
        }
        else if (fingeringCurrent[0] == 4)
        {
            // myImageOctave.transform.position = new Vector2(-317, 120);
            myImageOctave.sprite = octave0;
            tabImageShouldUpdate[0] = true;
        }
        else if (fingeringCurrent[0] == 5)
        {
            //myImageOctave.transform.position = new Vector2(-317, 120);
            myImageOctave.sprite = octaveP1;
            tabImageShouldUpdate[0] = true;
        }
    }
}
