using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class Computing : MonoBehaviour
{
    /// <summary>
    /// Processes all computing and analyzing tasks
    /// <summary>
    

    ////////////////MEMBERS////////////////

    MPTKEvent midiEvent_jouer, midiEvent_ref;


    ////////////////METHODS////////////////

    public bool accuracy_note(MPTKEvent midiEvent_jouer, MPTKEvent midiEvent_ref, int id)
    {
        if(midiEvent_jouer.Command==MPTKCommand.NoteOn && midiEvent_ref.Command==MPTKCommand.NoteOn)
        {
            if(midiEvent_jouer.Value==midiEvent_ref.Value)
                return true;
            else
                return false;
        }
        else
            if (intervall_tuto(id) == true || intervall_exercice(id)==true)
                return true;
            else
                return false;
    }

    public bool intervall_tuto(int id)
    {

        switch(id)
        {
            case 1:
                if(midiEvent_jouer.Value == midiEvent_ref.Value -15 || midiEvent_jouer.Value == midiEvent_ref.Value + 15)
                    return true;
                else
                    return false;
            case 2:
                if(midiEvent_jouer.Value == midiEvent_ref.Value -10 || midiEvent_jouer.Value == midiEvent_ref.Value + 10)
                    return true;
                else
                    return false;
            case 3:
                if(midiEvent_jouer.Value == midiEvent_ref.Value -15 || midiEvent_jouer.Value == midiEvent_ref.Value + 15)
                    return true;
                else
                    return false;
            case 4: 
                if(midiEvent_jouer.Value == midiEvent_ref.Value -15 || midiEvent_jouer.Value == midiEvent_ref.Value + 15)
                    return true;
                else
                    return false;
            default:
                return false;
        }
    }

    public bool intervall_exercice(int id)
    {
        switch(id)
        {
            case 1:
                if(midiEvent_jouer.Value == midiEvent_ref.Value -15 || midiEvent_jouer.Value == midiEvent_ref.Value + 15)
                    return true;
                else
                    return false;
            case 2:
                if(midiEvent_jouer.Value == midiEvent_ref.Value -8 || midiEvent_jouer.Value == midiEvent_ref.Value + 8)
                    return true;
                else
                    return false;
            case 3:
                if(midiEvent_jouer.Value == midiEvent_ref.Value -7 || midiEvent_jouer.Value == midiEvent_ref.Value + 15)
                    return true;
                else
                    return false;
            case 4: 
                if(midiEvent_jouer.Value == midiEvent_ref.Value -14 || midiEvent_jouer.Value == midiEvent_ref.Value + 7)
                    return true;
                else
                    return false;
            default:
                return false;
        }
    }

    public bool score (float score, float score_max)
    {
        if(score >= score_max)
            return true;
        else
            return false;
    }

    public bool meilleur_score(float score, float score_max)
    {
        if (score > score_max)
            return true;
        else
            return false;
    }
 
}
