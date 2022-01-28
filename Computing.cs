using System;
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

    // FOR ANALYSIS //
    private int nuanceTolerance, tangageTolerance, roulisTolerance, sliderUpTolerance, sliderMidTolerance, sliderLowTolerance;
    private int timeBufferSizeInFrames = 12;

    ////////////////METHODS////////////////

    public Computing(int nuanceWind, int tangageWind, int roulisWind, int sliderUpWind, int sliderMidWind, int sliderLowWind)
    {
        //timeBuffer = new int[timeBufferSizeInFrames];
        nuanceTolerance     = nuanceWind;
        tangageTolerance    = tangageWind;
        roulisTolerance     = roulisWind;
        sliderUpTolerance   = sliderUpWind;
        sliderMidTolerance  = sliderMidWind;
        sliderLowTolerance  = sliderLowWind;
    }

    public bool AccuracyAnalysis(EventsBufferType midiEventsCurrent, EventsBufferType midiEventsRef)
    {

        bool pitchTest      = TestingAccuracy(midiEventsCurrent.pitchEvents,        midiEventsRef.pitchEvents,      0);
        bool nuanceTest     = TestingAccuracy(midiEventsCurrent.nuanceEvents,       midiEventsRef.nuanceEvents,     nuanceTolerance);
        bool tangageTest    = TestingAccuracy(midiEventsCurrent.tangageEvents,      midiEventsRef.tangageEvents,    tangageTolerance);
        bool roulisTest     = TestingAccuracy(midiEventsCurrent.roulisEvents,       midiEventsRef.roulisEvents,     roulisTolerance);
        bool sliderUpTest   = TestingAccuracy(midiEventsCurrent.sliderUpEvents,     midiEventsRef.sliderUpEvents,   sliderUpTolerance);
        bool sliderMidTest  = TestingAccuracy(midiEventsCurrent.sliderMidEvents,    midiEventsRef.sliderMidEvents,  sliderMidTolerance);
        bool sliderLowTest  = TestingAccuracy(midiEventsCurrent.sliderLowEvents,    midiEventsRef.sliderLowEvents,  sliderLowTolerance);

        if (pitchTest == true && nuanceTest == true && tangageTest == true && roulisTest == true && sliderUpTest == true && sliderMidTest == true && sliderLowTest == true)
            return true;
        else
            return false;
    }

    private bool TestingAccuracy(int[] midiEventCurrent, int[] midiEventRef, int tolerance)
    {
        float midiEventCurrentMean, midiEventRefMean;
        

        for ( int i = 0 ; i < timeBufferSizeInFrames ; i++)
        {
            midiEventCurrentMean += (float)midiEventCurrent[i];
            midiEventRefMean += (float)midiEventRef[i];
        }

        int midiEventCurrentMeanInt, midiEventRefMeanInt;

        midiEventCurrentMeanInt = (int)Math.Round( midiEventCurrentMean/timeBufferSizeInFrames );
        midiEventRefMeanInt = (int)Math.Round( midiEventRefMean/timeBufferSizeInFrames );

        if ( Math.Abs( midiEventRefMeanInt - midiEventCurrentMeanInt ) <= tolerance )
            return true;
        else
            return false;
    }
    /*
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
    }*/
   

    public void End()
    {

    }
}