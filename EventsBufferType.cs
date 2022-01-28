using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class EventsBufferType : MonoBehaviour
{
    private int timeBufferSizeInFrames = 12;
    public int[] pitchEvents, nuanceEvents, tangageEvents, roulisEvents, sliderUpEvents, sliderMidEvents, sliderLowEvents;

    public void FillBuffers(MPTKEvent midiEventCurrent)
    {
        if (midiEventCurrent.Command == MPTKCommand.NoteOn)
            pitchEvents[0] = midiEventCurrent.Value;
        /*else
            pitchEvents[0] = 0;*/

        if (midiEventCurrent.Command == MPTKCommand.ControlChange)
        {
            if (midiEventCurrent.Controller == MPTKController.Expression)
            {
                nuanceEvents[0] = midiEventCurrent.Value;
                Debug.Log("Valeur de nuance reçue")
            }
            else
                nuanceEvents[0] = 0;

            if (midiEventCurrent.Controller == MPTKController.SOUND_CTRL6)
            {
                tangageEvents[0] = midiEventCurrent.Value;
                Debug.Log("Valeur de tangage reçue");
            }
            else
                tangageEvents[0] = 0;

            if (midiEventCurrent.Controller == MPTKController.SOUND_CTRL7)
            {
                roulisEvents[0] = 0;
                Debug.Log("Valeur de roulis reçue");
            }
            else
                roulisEvents[0] = 0;
            /*
             if (midiEventCurrent.Controller == MPTKController.???)
                sliderUpEvents[0] = 0;
            else
                sliderUpEvents[0] = 0;
             
            */
            if (midiEventCurrent.Controller == MPTKController.MODULATION_WHEEL_LSB)
            {
                sliderMidEvents[0] = 0;
                Debug.Log("Valeur de slider central reçue")
            }
            else
                sliderMidEvents[0] = 0;
            /*
             if (midiEventCurrent.Controller == MPTKController.???)
                sliderLowEvents[0] = 0;
            else
                sliderLowEvents[0] = 0;
             
            */

            // Manque SLIDER UP et SLIDER LOW : effect controller?
        }

        /*else
        {
            nuanceEvents[0]     = 0;
            tangageEvents[0]    = 0;
            roulisEvents[0]     = 0;
            sliderUpEvents[0]   = 0;
            sliderMidEvents[0]  = 0;
            sliderLowEvents[0]  = 0;
        }*/

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
