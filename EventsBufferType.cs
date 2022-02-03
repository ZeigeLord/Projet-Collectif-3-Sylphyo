using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class EventsBufferType : MonoBehaviour
{
    private int timeBufferSizeInFrames = 6;
    public int[] pitchEvents, nuanceEvents, tangageEvents, roulisEvents, sliderUpEvents, sliderMidEvents, sliderLowEvents;
    private bool noteBeingPlayed = false;


    public EventsBufferType()
    {
        pitchEvents     = new int[timeBufferSizeInFrames];
        nuanceEvents    = new int[timeBufferSizeInFrames];
        tangageEvents   = new int[timeBufferSizeInFrames];
        roulisEvents    = new int[timeBufferSizeInFrames];
        sliderUpEvents  = new int[timeBufferSizeInFrames];
        sliderMidEvents = new int[timeBufferSizeInFrames];
        sliderLowEvents = new int[timeBufferSizeInFrames];

        for (int i = 0; i < timeBufferSizeInFrames; i++)
        {
            pitchEvents[i] = 0;
            nuanceEvents[i] = 0;
            tangageEvents[i] = 0;
            roulisEvents[i] = 0;
            sliderUpEvents[i] = 0;
            sliderMidEvents[i] = 0;
            sliderLowEvents[i] = 0;
        }
    }

    public void FillBuffers(MPTKEvent midiEventCurrent)
    {
        /////////// PITCH ///////////
        ///
        if (noteBeingPlayed == true)
            pitchEvents[0] = pitchEvents[1];

        if (midiEventCurrent.Command == MPTKCommand.NoteOn)
        {
            pitchEvents[0] = midiEventCurrent.Value;
            noteBeingPlayed = true;
        }

        if (midiEventCurrent.Command == MPTKCommand.NoteOff)
            noteBeingPlayed = false;

        //////// PITCH WHEEL = SLIDER HAUT & SHAKE VIBRATO ////////
        ///
        if (midiEventCurrent.Command == MPTKCommand.PitchWheelChange) //Comprend aussi les données envoyées par le shake vibrato
            sliderUpEvents[0] = midiEventCurrent.Value;

        /////////// CONTROL CHANGES ///////////
        ///
        if (midiEventCurrent.Command == MPTKCommand.ControlChange)
        {
            /////////// NUANCE ///////////
            if (midiEventCurrent.Controller == MPTKController.Expression)
            {
                nuanceEvents[0] = midiEventCurrent.Value;
                Debug.Log("Valeur de nuance reçue");
            }
            /////////// TANGAGE ///////////
            if (midiEventCurrent.Controller == MPTKController.SOUND_CTRL6)
            {
                tangageEvents[0] = midiEventCurrent.Value;
                Debug.Log("Valeur de tangage reçue");
            }
            /////////// ROULIS ///////////
            if (midiEventCurrent.Controller == MPTKController.SOUND_CTRL7)
            {
                roulisEvents[0] = midiEventCurrent.Value;
                Debug.Log("Valeur de roulis reçue");
            }
            /////////// SLIDER MID ///////////
            if (midiEventCurrent.Controller == MPTKController.Modulation)
            {
                sliderMidEvents[0] = midiEventCurrent.Value;
                Debug.Log("Valeur de slider central reçue");
            }
            /////////// SLIDER LOW ///////////
            if (midiEventCurrent.Controller == MPTKController.EFFECTS2_MSB)
                sliderLowEvents[0] = midiEventCurrent.Value;
        }

    }

    public void UpdateBuffers()
    {
        for (int i = 1; i < timeBufferSizeInFrames; i++)
        {
            int data = pitchEvents[i - 1];
            pitchEvents[i] = data;
            data = nuanceEvents[i - 1];
            nuanceEvents[i] = data;
            data = tangageEvents[i - 1];
            tangageEvents[i] = data;
            data = roulisEvents[i - 1];
            roulisEvents[i] = data;
            data = sliderUpEvents[i - 1];
            sliderUpEvents[i] = data;
            data = sliderMidEvents[i - 1];
            sliderMidEvents[i] = data;
            data = sliderLowEvents[i - 1];
            sliderLowEvents[i] = data;
        }
    }

    public void ClearBuffers()
    {
        for (int i = 0; i < timeBufferSizeInFrames; i++)
        {
            pitchEvents[i]      = 0;
            nuanceEvents[i]     = 0;
            tangageEvents[i]    = 0;
            roulisEvents[i]     = 0;
            sliderUpEvents[i]   = 0;
            sliderMidEvents[i]  = 0;
            sliderLowEvents[i]  = 0;
        }
    }
}
