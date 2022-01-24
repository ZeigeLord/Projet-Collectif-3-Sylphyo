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

    //MPTKEvent midiEventCurrent, midiEventRef;

    InstrumentData() instrumentData;
    public int[9] fingeringCurrent;

    // FOR ANALYSIS //
    private int nuanceTolerance, tangageTolerance, roulisTolerance, sliderUpTolerance, sliderMidTolerance, sliderLowTolerance;
    private int timeBufferSizeInFrames = 12;
    private int[] timeBuffer = new int[timeBufferSizeInFrames];

    ////////////////METHODS////////////////

    public Computing()
    {
        nuanceTolerance = ;
        tangageTolerance = ;
        roulisTolerance = ;
        sliderUpTolerance = ;
        sliderMidTolerance = ;
        sliderLowTolerance = ;
    }

    public bool TestingAccuracy( MPTKEvent midiEventCurrent, MPTKEvent midiEventRef )
    {

        if ( midiEventCurrent.Command == MPTKCommand.ControlChange && midiEventRef.Command == MPTKCommand.ControlChange )
        {

        }
    }

    private bool NuanceAccuracy( MPTKEvent midiEventCurrent, MPTKEvent midiEventRef)
    {
        if ( midiEventCurrent.Controller == MPTKController.Expression && midiEventRef.Controller == MPTKController.Expression )
        {
            if ( Math.Abs( midiEventCurrent.Value - midiEventRef.Value) <= nuanceTolerance )
                return true;
            else
            {
                return false;
                Debug.Log(" Attention aux nuances ! ");
            }
        }
    }
    private bool TangageAccuracy( MPTKEvent midiEventCurrent, MPTKEvent midiEventRef )
    {
        if ( midiEventCurrent.Controller == MPTKController. && midiEventRef.Controller == MPTKController. )
        {

        }
    }

    private bool RoulisAccuracy( MPTKEvent midiEventCurrent, MPTKEvent midiEventRef )
    {

    }

    private bool SliderUpAccuracy( MPTKEvent midiEventCurrent, MPTKEvent midiEventRef )
    {

    }

    private bool SliderMidAccuracy( MPTKEvent midiEventCurrent, MPTKEvent midiEventRef )
    {
        if (midiEventCurrent.Controller == MPTKController.Modulation && midiEventRef.Controller == MPTKController.Modulation)
        {
            if (Math.Abs(midiEventCurrent.Value - midiEventRef.Value) <= nuanceTolerance)
                return true;
            else
            {
                return false;
                Debug.Log(" Attention au Slider du milieu ! ");
            }
        }
    }

    private bool SliderLowAccuracy( MPTKEvent midiEventCurrent, MPTKEvent midiEventRef )
    {

    }

    public bool AccuracyNote( MPTKEvent midiEventCurrent, MPTKEvent midiEventRef, int id )
    {
        if( midiEventCurrent.Command == MPTKCommand.NoteOn && midiEventRef.Command==MPTKCommand.NoteOn )
        {
            if( midiEventCurrent.Value == midiEventRef.Value )
                return true;
            else
                return false;
        }
        else
            if ( IntervalTuto( id ) == true || IntervalExercice( id ) ==true )
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
 
    public void AssignFingeringChart (string instrumentChosen)
    {
        InstrumentData( instrumentChosen ) instrumentDataLoaded;
        instrumentData = instrumentDataLoaded;
    }

    public void MidiToFingering( MPTKEvent midiEventCurrent ){
        if ( midiEventCurrent.Command == MPTKCommand.NoteOn )
        {
            for ( int i = 0; i < 9; i++ )
                fingeringCurrent[i] = instrumentData.GetFingeringChart[midiEventCurrent.Value, i];
        }
    }
}
