using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class Computing : MonoBehaviour
{
    public MidiInOut myMidiInOut;
    public Exercice myExercice;
    public GraphicInterface myGrapicInterface;
    public UserData myUserData;
    public bool finished;


    public void accuracy_note(MPTKEvent midiEvent_jouer, MPTKEvent midiEvent_ref)
    {
        if (midiEvent_jouer.Command == MPTKCommand.NoteOn && midiEvent_ref.Command == MPTKCommand.NoteOn)
        {
            if (midiEvent_jouer.Value == midiEvent_ref.Value)
                finished = true;
            else
                finished = false;
        }
        else
            if (intervall_tuto(id) == true || intervall_exercice(id) == true)
            finished = true;
        else
            finished = false;
    }

    public bool intervall_tuto(int id)
    {

        switch (id)
        {
            case 1:
                if (midiEvent_jouer.Value == midiEvent.Value - 15 || midiEvent_jouer.Value == midiEvent.Value + 15)
                    return true;
                else
                    return false;
                break;
            case 2:
                if (midiEvent_jouer.Value == midiEvent.Value - 10 || midiEvent_jouer.Value == midiEvent.Value + 10)
                    return true;
                else
                    return false;
            case 3:
                if (midiEvent_jouer.Value == midiEvent.Value - 15 || midiEvent_jouer.Value == midiEvent.Value + 15)
                    return true;
                else
                    return false;
            case 4:
                if (midiEvent_jouer.Value == midiEvent.Value - 15 || midiEvent_jouer.Value == midiEvent.Value + 15)
                    return true;
                else
                    return false;
        }
    }

    public bool accuracy_effet_exercice(int id)
    {
        switch (id)
        {
            case 1:
                if (midiEvent_jouer.Value == midiEvent.Value - 15 || midiEvent_jouer.Value == midiEvent.Value + 15)
                    return true;
                else
                    return false;
                break;
            case 2:
                if (midiEvent_jouer.Value == midiEvent.Value - 8 || midiEvent_jouer.Value == midiEvent.Value + 8)
                    return true;
                else
                    return false;
            case 3:
                if (midiEvent_jouer.Value == midiEvent.Value - 7 || midiEvent_jouer.Value == midiEvent.Value + 15)
                    return true;
                else
                    return false;
            case 4:
                if (midiEvent_jouer.Value == midiEvent.Value - 14 || midiEvent_jouer.Value == midiEvent.Value + 7)
                    return true;
                else
                    return false;
        }
    }

    public void score(float score, float score_max)
    {
        if (score >= score_max)
            finished = true;
        else
            finished = false;
    }

    public void meilleur_score(float score, float score_max)
    {
        if (score > score_max)
            score = score_max;
    }

}