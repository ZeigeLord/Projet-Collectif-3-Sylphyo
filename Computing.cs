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

    MPTKEvent midiEventCurrent, midiEventRef;

    public string instrumentChosen;
    InstrumentData( instrumentChosen ) instrumentData;
    public int[9] fingeringCurrent;

    ////////////////METHODS////////////////
     
    public bool AccuracyNote( MPTKEvent midiEventCurrent, MPTKEvent midiEventRef, int id )
    {
        if( midiEventCurrent.Command==MPTKCommand.NoteOn && midiEventRef.Command==MPTKCommand.NoteOn )
        {
            if( midiEventCurrent.Value==midiEventRef.Value )
                return true;
            else
                return false;
        }
        else
            if ( IntervalTuto( id ) == true || IntervalExercice( id )==true )
                return true;
            else
                return false;
    }

    public bool IntervalTuto( int id )
    {

        switch( id )
        {
            case 1:
                if( midiEventCurrent.Value == midiEventRef.Value -15 || midiEventCurrent.Value == midiEventRef.Value + 15 )
                    return true;
                else
                    return false;
            case 2:
                if( midiEventCurrent.Value == midiEventRef.Value -10 || midiEventCurrent.Value == midiEventRef.Value + 10 )
                    return true;
                else
                    return false;
            case 3:
                if( midiEventCurrent.Value == midiEventRef.Value -15 || midiEventCurrent.Value == midiEventRef.Value + 15 )
                    return true;
                else
                    return false;
            case 4: 
                if( midiEventCurrent.Value == midiEventRef.Value -15 || midiEventCurrent.Value == midiEventRef.Value + 15 )
                    return true;
                else
                    return false;
            default:
                return false;
        }
    }

    public bool IntervalExercice( int id )
    {
        switch( id )
        {
            case 1:
                if( midiEventCurrent.Value == midiEventRef.Value -15 || midiEventCurrent.Value == midiEventRef.Value + 15 )
                    return true;
                else
                    return false;
            case 2:
                if( midiEventCurrent.Value == midiEventRef.Value -8 || midiEventCurrent.Value == midiEventRef.Value + 8 )
                    return true;
                else
                    return false;
            case 3:
                if( midiEventCurrent.Value == midiEventRef.Value -7 || midiEventCurrent.Value == midiEventRef.Value + 15 )
                    return true;
                else
                    return false;
            case 4: 
                if( midiEventCurrent.Value == midiEventRef.Value -14 || midiEventCurrent.Value == midiEventRef.Value + 7 )
                    return true;
                else
                    return false;
            default:
                return false;
        }
    }

    public bool Score( float score, float score_max )
    {
        if( score >= score_max )
            return true;
        else
            return false;
    }

    public bool HighScore( float score, float score_max )
    {
        if ( score > score_max )
            return true;
        else
            return false;
    }
 
    public void MidiToFingering( midiEventCurrent ){
        if ( midiEventCurrent.Command == MPTKCommand.NoteOn )
        {
            for ( int i = 0; i < 9; i++ )
                fingeringCurrent[i] = instrumentData.GetFingeringChart[midiEventCurrent.Value, i];
        }
    }
}